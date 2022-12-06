var input = File.ReadAllText(@"C:\temp\input6.txt").AsSpan();

var index = IndexOfFirstPacket(input);
Console.WriteLine($"Index of first packet: {index}");
Console.WriteLine($"Characters processed to identify packet: {index + 4}");


int IndexOfFirstPacket(ReadOnlySpan<char> input)
{
    for (int i = 0; i < input.Length - 4; i++)
    {
        var packet = input.Slice(i, 4);
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
