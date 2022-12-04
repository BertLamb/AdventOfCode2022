
using System.Net.Sockets;

using var inputStream = new StreamReader(File.OpenRead(@"C:\temp\input2.txt"));


var score = 0;

while (inputStream.ReadLine() is { } line)
{
    // A = Rock = 1
    // B = Paper = 2
    // C = Scissors = 3
    var round = line.Split(' ');
    if (round[1] == "X")
    {   // loss
        score += LoseAgainst(round[0]);
        Console.WriteLine("Lose :(");
    }
    else if (round[1] == "Y")
    {
        score += DrawAgainst(round[0]) + 3;
        Console.WriteLine("Draw.");
    }
    else
    {
        score += WinAgainst(round[0]) + 6;
        Console.WriteLine("Win!");
    }
}

Console.WriteLine($"Total Score: {score}");

int LoseAgainst(string a)
{
    switch (a)
    {
        case "A":
            return 3;
        case "B":
            return 1;
        case "C":
            return 2;
    }

    return 0;
}

int WinAgainst(string a)
{
    switch (a)
    {
        case "A":
            return 2;
        case "B":
            return 3;
        case "C":
            return 1;
    }

    return 0;
}

int DrawAgainst(string a)
{
    switch (a)
    {
        case "A":
            return 1;
        case "B":
            return 2;
        case "C":
            return 3;
    }

    return 0;
}
