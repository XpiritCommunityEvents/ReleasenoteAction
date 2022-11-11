using CommandLine;

namespace DotNet.GitHubAction;

public class ActionInputs
{
    string _branchName = null!;

    public ActionInputs()
    {
        Console.WriteLine("Generating Release Notes");
    }

    [Option('e', "environment",
        Required = true,
        HelpText = "Reference to the environment data so we can generate release notes: . Assign from '${{ toJSON(env) }}'.")]
    public string Environment { get; set; } = null!;

    [Option('b', "branch",
        Required = true,
        HelpText = "The branch name, for example: \"refs/heads/main\". Assign from '${{ github.ref }}'.")]
    public string Branch
    {
        get => _branchName;
        set => ParseAndAssign(value, str => _branchName = str);
    }


    static void ParseAndAssign(string? value, Action<string> assign)
    {
        if (value is { Length: > 0 } && assign is not null)
        {
            assign(value.Split("/")[^1]);
        }
    }
}
