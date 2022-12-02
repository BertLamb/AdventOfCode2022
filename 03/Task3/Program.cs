
using var inputStream = new StreamReader(File.OpenRead(@"C:\temp\input2.txt"));

string? line;
var score = 0;
while ((line = inputStream.ReadLine()) != null)
{
    // A = X = Rock = 1
    // B = Y = Paper = 2
    // C = Z = Scissors = 3
    line = line.Replace("A", "1").Replace("B","2").Replace("C","3")
               .Replace("X","1").Replace("Y","2").Replace("Z","3");
    var round = line.Split(' ');
    score += int.Parse(round[1]);
    if (round[0] == round[1])
    {   // draw
        score += 3;
        Console.WriteLine("Draw.");
    }
    else if ((round[0] == "3" && round[1] == "1")
         || (round[0] == "2" && round[1] == "3")
         || (round[0] == "1" && round[1] == "2"))
    {   // we won
        score += 6;
        Console.WriteLine("Win!");
    }
    else
    {
        // loss
        Console.WriteLine("Loss :(");
    }
}

Console.WriteLine($"Total Score: {score}");


