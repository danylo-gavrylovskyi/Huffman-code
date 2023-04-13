Dictionary<char, int> symbolCount = new Dictionary<char, int>();
var code = new Dictionary<string, string>();
string text = File.ReadAllText("C:\\Users\\danya\\Huffman-code\\Huffman_code\\Huffman_code\\sherlock.txt");
foreach (char symbol in text)
{
    if (!symbolCount.ContainsKey(symbol))
    {
        symbolCount.Add(symbol, 1);
    }
    else
    {
        symbolCount[symbol]++;
    }
}