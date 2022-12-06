var input = File.ReadAllText(@"C:\temp\input6.txt").AsSpan();

var index = IndexOfFirstUniqueBlock(input, 14);
Console.WriteLine($"Index of first packet: {index}");
Console.WriteLine($"Characters processed to identify packet: {index + 14}");


int IndexOfFirstUniqueBlock(ReadOnlySpan<char> input, int uniqueChars)
{
    for (int i = 0; i < input.Length - uniqueChars; i++)
    {
        var packet = input.Slice(i, uniqueChars);
        if (IsUniqueSpan(packet))
        {
            return i;
        }
    }
    return -1;
}


bool IsUniqueSpan(ReadOnlySpan<char> span)
{
    for (int i = 0; i < span.Length - 1; i++)
    {
        for (int j = i + 1; j < span.Length; j++)
        {
            if (span[i] == span[j])
            {
                return false;
            }
        }
    }
    return true;
}