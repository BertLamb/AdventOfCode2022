using var inputStream = new StreamReader(File.OpenRead(@"C:\temp\input3.txt"));

int total = 0;
var groupSacks = new List<string>();
while (inputStream.ReadLine() is { } line)
{
    groupSacks.Add(line);
    if (groupSacks.Count == 3)
    {
        total += CalculateBadgePriority(groupSacks);

        groupSacks.Clear();
    }
}

Console.WriteLine(total);

int CalculateBadgePriority(List<string> list)
{
    foreach (char item in list[0])
    {
        if (list[1].Contains(item) && list[2].Contains(item))
        {
            Console.WriteLine($"Common Item: {item}:{ItemPriority(item)}");
            return ItemPriority(item);
        }
    }

    throw new ArgumentException("common item not found");
}


int ItemPriority(char c)
{
    if (Char.IsLower(c))
    {
        return c - 'a' + 1;
    }

    return c - 'A' + 27;
}