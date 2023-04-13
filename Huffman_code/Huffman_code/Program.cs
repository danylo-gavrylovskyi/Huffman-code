﻿Dictionary<char, int> symbolCount = new Dictionary<char, int>();
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
HuffmanCoding(symbolCount);
void CodeGenerator(MinHeapNode heapStart, string str)
{
    if (heapStart == null)return;

    if (heapStart.Value != null)
    {
        code[heapStart.Value] = str;
        Console.WriteLine(heapStart.Value + ": " + str);
    }

    CodeGenerator(heapStart.LeftNode, str + "0");
    CodeGenerator(heapStart.RightNode, str + "1");
}

void HuffmanCoding(Dictionary<char, int> frequencies)
{
    var minHeap = new MinHeap(frequencies.Count);
    foreach (var symbol in frequencies)
    {
        minHeap.Add(new MinHeapNode(symbol.Key.ToString(), symbol.Value));
    }

    while (!(minHeap.Capacity == 1))
    {
        var left = minHeap.Pop();
        var right = minHeap.Pop();

        var top = new MinHeapNode(null, left.SymbolCount + right.SymbolCount)
        {
            LeftNode = left,
            RightNode = right
        };

        minHeap.Add(top);

    }
    CodeGenerator(minHeap.Peek(), null);
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

class MinHeap
{
    private MinHeapNode[] Objects;
    public int Capacity;

    public MinHeap(int capacity)
    {
        Objects = new MinHeapNode[capacity];
    }

    private int LeftChildIndex(int index)
    {
        return 2 * index + 1;
    }
    private MinHeapNode LeftChild(int index)
    {
        return Objects[2 * index + 1];
    }
    private int RightChildIndex(int index)
    {
        return 2 * index + 2;
    }
    private MinHeapNode RightChild(int index)
    {
        return Objects[2 * index + 2];
    }
    private int ParentIndex(int index)
    {
        return (index - 1) / 2;
    }
    private MinHeapNode Parent(int index)
    {
        return Objects[(index - 1) / 2];
    }

    private void Swap(int firstIndex, int secondIndex)
    {
        (Objects[firstIndex], Objects[secondIndex]) = (Objects[secondIndex], Objects[firstIndex]);
    }

    public void Add(MinHeapNode node)
    {
        if (Capacity == Objects.Length) return;

        Objects[Capacity] = node;
        Capacity++;

        int index = Capacity - 1;
        while (index != 0 && Objects[index].SymbolCount < Parent(index).SymbolCount)
        {
            int parentInd = ParentIndex(index);
            Swap(parentInd, index);
            index = parentInd;
        }
    }

    public MinHeapNode Peek()
    {
        if (Capacity != 0)
        {
            return Objects[0];
        }
        else
        {
            throw new Exception("There are no objects in heap");
        }
    }

    public MinHeapNode Pop()
    {
        if (Capacity == 0) return null;

        var result = Objects[0];
        Objects[0] = Objects[Capacity - 1];
        Capacity--;

        int index = 0;
        while (LeftChildIndex(index) < Capacity)
        {
            int min = LeftChildIndex(index);
            if (LeftChild(index).SymbolCount > RightChild(index).SymbolCount)
            {
                min = RightChildIndex(index);
            }

            if (Objects[min].SymbolCount >= Objects[index].SymbolCount)
            {
                break;
            }

            Swap(min, index);
            index = min;
        }

        return result;
    }
}