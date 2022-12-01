using var inputStream = new StreamReader(File.OpenRead(@"C:\temp\input.txt"));

int total = 0;
int maxTotal = 0;
string? line;
while((line = await inputStream.ReadLineAsync()) != null)
{
    if (string.IsNullOrEmpty(line))
    {
        if (total > maxTotal)
        {
            maxTotal = total;
        }
        total = 0;
    }
    else
    {
        total += int.Parse(line);
    }
}

if (total > 0)
{
    if (total > maxTotal)
    {
        maxTotal = total;
    }
}

Console.WriteLine($"Highest Total: {maxTotal}");