using System.Text.RegularExpressions;

using var inputStream = new StreamReader(File.OpenRead(@"C:\temp\input4.txt"));

var regex = new Regex(@"(\d+)-(\d+),(\d+)-(\d+)");
var total = 0;
while (inputStream.ReadLine() is { } line)
{
    var match = regex.Match(line);
    var range1 = new Range(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
    var range2 = new Range(int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value));

    if (range1.Contains(range2))
    {
        Console.WriteLine($"{range1} contains {range2}");
        total++;
    }
    else if (range2.Contains(range1))
    {
        Console.WriteLine($"{range2} contains {range1}");
        total++;
    }
}

Console.WriteLine($"{total} fully contained ranges");

public record Range(int Start, int End)
{
    public bool Contains(Range r)
    {
        return r.Start >= Start && r.End <= End;
    }

    public bool Overlaps(Range r)
    {
        return r.Start <= End || r.End >= Start;
    }
}