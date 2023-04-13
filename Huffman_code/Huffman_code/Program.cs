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

class MinHeapNode
{
    public string Value;
    public int SymbolCount;
    public MinHeapNode LeftNode, RightNode;

    public MinHeapNode(string value, int symbolCount)
    {
        this.Value = value;
        this.SymbolCount = symbolCount;
        LeftNode = null;
        RightNode = null;
    }
}