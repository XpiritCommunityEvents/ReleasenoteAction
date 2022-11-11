using CommandLine;

namespace DotNet.GitHubAction;

public class ActionInputs
{
    private string _Ownername;
    private string _Labelname;
    private string _Reponame;
    private string _Accesstoken;

    public ActionInputs()
    {
        Console.WriteLine("Generating Release Notes");
    }

    [Option('e', "environment",
        Required = true,
        HelpText = "Reference to the environment data so we can generate release notes: . Assign from '${{ toJSON(env) }}'.")]
    public string Environment { get; set; } = null!;

    [Option('t', "token",
        Required = true,
        HelpText = "Github token used to authenticate against API")]
    public string AccessToken
    {
        get => _Accesstoken;
        set => ParseAndAssign(value, str => _Accesstoken = str);
    }

    [Option('o', "ownername",
        Required = true,
        HelpText = "Owner of the repo, used to retrieve the issues we use for releasenotes")]
    public string Ownername
    {
        get => _Ownername;
        set => ParseAndAssign(value, str => _Ownername = str);
    }

    [Option('l', "labelname",
        Required = true,
        HelpText = "label name used at issues we want to retrieve as releasenotes")]
    public string Labelname
    {
        get => _Labelname;
        set => ParseAndAssign(value, str => _Labelname = str);
    }

    [Option('r', "reponame",
        Required = true,
        HelpText = "Name of the repo, used to pull the issues from")]
    public string Reponame
    {
        get => _Reponame;
        set => ParseAndAssign(value, str => _Reponame = str);
    }

    static void ParseAndAssign(string? value, Action<string> assign)
    {
        if (value is { Length: > 0 } && assign is not null)
        {
            assign(value.Split("/")[^1]);
        }
    }
}
