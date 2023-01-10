using System;
public class Heap
{
    private int[] data; // tablica przechowująca dane kopca
    private int count; // liczba elementów w kopcu
    private int capacity; // maksymalna pojemność kopca
    private bool isMinHeap; // czy jest to kopiec min-first czy max-first

    // Konstruktor, który tworzy pusty kopiec o podanej pojemności
    // isMin: czy jest to kopiec min-first czy max-first
    public Heap(int capacity, bool isMin = true)
    {
        this.data = new int[capacity];
        this.capacity = capacity;
        this.count = 0;
        this.isMinHeap = isMin;
    }
    // Metoda polegająca na przesuwaniu elementu ku górze, tak aby spełnić warunki kopca​
    private void HeapifyUp(int i)
    {
        int parent = Parent(i);
        if (parent != -1 && this.data[i] < this.data[parent])
        {
            Swap(i, parent);
            HeapifyUp(parent);
        }
    }
    private void HeapifyDown(int i)
    {
        int minIndex = i;
        if (LeftChild(i) != -1 && this.data[LeftChild(i)] < this.data[minIndex])
            minIndex = LeftChild(i);
        if (RightChild(i) != -1 && this.data[RightChild(i)] < this.data[minIndex])
            minIndex = RightChild(i);

        if (i != minIndex)
        {
            Swap(i, minIndex);
            HeapifyDown(minIndex);
        }
    }

    // Metoda do dodawania nowego elementu do kopca​
    public void Insert(int value)
    {
        if (IsFull())
            return; // nie można dodać nowego elementu, jeśli kopiec jest pełny​

        this.data[this.count] = value;
        this.count++;
        HeapifyUp(this.count - 1);
    }

    public bool IsEmpty()
    {
        return this.count == 0;
    }

    // Metoda do sprawdzenia, czy kopiec jest pełny​
    public bool IsFull()
    {
        return this.count == this.capacity;
    }


    // Metoda do wymiany dwóch elementów w tablicy po indeksach​

    private void Swap(int i, int j)
    {

        int temp = this.data[i];
        this.data[i] = this.data[j];
        this.data[j] = temp;
    }
    // Metoda zwracająca indeks rodzica dla podanego indeksu dziecka​
    private int Parent(int i)
    {
        if (i <= 0 || i >= this.count)
            return -1;
        return (i - 1) / 2;
    }

    // Metoda zwracająca indeks lewego dziecka dla podanego indeksu rodzica​
    private int LeftChild(int i)
    {
        int left = 2 * i + 1;
        if (left >= this.count)
            return -1;
        return left;
    }
    // Metoda zwracająca indeks prawego dziecka dla podanego indeksu rodzica​
    private int RightChild(int i)
    {
        int right = 2 * i + 2;
        if (right >= this.count)
            return -1;
        return right;
    }
    public int Extract()
    {
        if (IsEmpty())
            return -1; // kopiec jest pusty, więc nie ma co usunąć​
        int value = this.data[0];
        this.count--;
        this.data[0] = this.data[this.count];
        HeapifyDown(0);
        return value;
    }

    public void PrintAsTree()
    {
        for (int i = 0; i < this.count; i++)
        {
            Console.Write(this.data[i]);
            if (LeftChild(i) != -1)
                Console.Write(" => left: " + this.data[LeftChild(i)]);
            if (RightChild(i) != -1)
                Console.Write(" => right: " + this.data[RightChild(i)]);
            Console.WriteLine();
        }
    }
}

class Hello
{
    static void Main(string[] args)
    {
        Heap heap = new Heap(10);
        heap.Insert(5);
        heap.PrintAsTree();
        Console.WriteLine();
        heap.Insert(3);
        heap.PrintAsTree();
        Console.WriteLine();
        heap.Insert(8);
        heap.PrintAsTree();
        Console.WriteLine();
        heap.Insert(1);
        heap.PrintAsTree();
        Console.WriteLine();
        heap.Insert(2);
        heap.PrintAsTree();
        Console.WriteLine();
        heap.Insert(20);
        // Wypisanie elementów kopca (od najmniejszego do największego) 
        heap.PrintAsTree();
    }
}
