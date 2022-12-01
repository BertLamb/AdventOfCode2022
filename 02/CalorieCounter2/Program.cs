using var inputStream = new StreamReader(File.OpenRead(@"C:\temp\input.txt"));

var calorieTotals = new List<int>();
int total = 0;
string? line;
while((line = await inputStream.ReadLineAsync()) != null)
{
    if (string.IsNullOrEmpty(line))
    {
        calorieTotals.Add(total);
        total = 0;
    }
    else
    {
        total += int.Parse(line);
    }
}

if (total > 0)
{
    calorieTotals.Add(total);
}

var sortedTotals = calorieTotals.OrderByDescending(i => i).ToList();
var max = sortedTotals.First();
var topThreeTotal = sortedTotals.Take(3).Aggregate((a, b) => a + b); 

Console.WriteLine($"Highest Total: {max}");
Console.WriteLine($"Top 3 Total: {topThreeTotal}");
