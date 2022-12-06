using System.Text.RegularExpressions;

using var input = new StreamReader(File.OpenRead(@"c:\temp\input5.txt"));
//    [W]         [J]     [J]        

var setupLines = new List<string>();
bool setupComplete = false;
var commandRegex = new Regex(@"move (\d+) from (\d+) to (\d+)");
var stacks = new Stack<char>[] { };
while (await input.ReadLineAsync() is { } line)
{
    if (setupComplete == false)
    {
        if (String.IsNullOrEmpty(line))
        { // finished reading setup
            setupComplete= true;
            stacks = ParseSetup(setupLines);
        }
        else
        {
            setupLines.Add(line);
        }
    }
    else
    {   // commands
        var match = commandRegex.Match(line);
        int count = int.Parse(match.Groups[1].Value);
        int from = int.Parse(match.Groups[2].Value) - 1;
        int to = int.Parse(match.Groups[3].Value) - 1;
        var items = new LinkedList<char>();

        for (int i = 0; i < count; i++)
        {
            items.AddLast(stacks[from].Pop());
        }

        while(items.Count > 0)
        {
            stacks[to].Push(items.Last());
            items.RemoveLast();
        }

    }
}

for (int i = 0; i < stacks.Length; i++)
{
    Console.Write(stacks[i].Peek());
}

Console.WriteLine();



Stack<char>[] ParseSetup(List<string> setup)
{
    var numStacks = int.Parse(setup.Last().Split(" ",StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Last());
    var stacks = new Stack<char>[numStacks];
    for (var i = 0; i < numStacks; i++)
    {
        stacks[i] = new Stack<char>();
    }
    for (var i = setup.Count - 2; i >= 0; i--)
    {
        var line = setup[i];
        for (var j = 0; j < numStacks; j++)
        {
            var item = line.Substring(4 * j + 1, 1).ToCharArray().First();
            if (char.IsLetterOrDigit(item))
            {
                stacks[j].Push(item);
            }
        }
    }

    return stacks;
}