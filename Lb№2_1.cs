using System;

namespace Lab2_1
{
    // 1. РЕАЛІЗАЦІЯ СТЕКА НА ОСНОВІ МАСИВУ
    class ArrayStack
    {
        private int[] arr;
        private int capacity;
        private int topIndex;

        public ArrayStack(int size)
        {
            capacity = size;
            arr = new int[capacity];
            topIndex = -1;
        }

        // Операція PUSH
        public void Push(int value)
        {
            if (topIndex >= capacity - 1)
            {
                Console.WriteLine("Помилка: Стек переповнений!");
                return;
            }
            arr[++topIndex] = value;
        }

        // Операція POP
        public int Pop()
        {
            if (topIndex < 0)
            {
                Console.WriteLine("Помилка: Стек порожній!");
                return -1;
            }
            return arr[topIndex--];
        }

        // Друк залишку стека
        public void Print()
        {
            if (topIndex < 0)
            {
                Console.WriteLine("Стек порожній.");
                return;
            }
            for (int i = topIndex; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }

    // 2. РЕАЛІЗАЦІЯ СТЕКА НА ОСНОВІ СПИСКУ
    // Клас вузла однозв'язного списку
    class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    class ListStack
    {
        private Node topNode;

        public ListStack()
        {
            topNode = null;
        }

        // Операція PUSH
        public void Push(int value)
        {
            Node newNode = new Node(value);
            newNode.Next = topNode;
            topNode = newNode;
        }

        // Операція POP
        public int Pop()
        {
            if (topNode == null)
            {
                Console.WriteLine("Помилка: Стек порожній!");
                return -1;
            }
            int poppedValue = topNode.Data;
            topNode = topNode.Next;
            return poppedValue;     
        }

        // Друк залишку стека
        public void Print()
        {
            if (topNode == null)
            {
                Console.WriteLine("Стек порожній.");
                return;
            }
            Node current = topNode;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

    // ГОЛОВНИЙ КЛАС ДЕМОНСТРАЦІЇ
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- ДЕМОНСТРАЦІЯ СТЕКА НА ОСНОВІ МАСИВУ ---");
            ArrayStack arrayStack = new ArrayStack(10);

            Console.WriteLine("Введіть 5 цілих чисел для стека на основі масиву:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Елемент {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int val))
                {
                    arrayStack.Push(val);
                }
                else
                {
                    Console.WriteLine("Некоректне число, записуємо 0.");
                    arrayStack.Push(0);
                }
            }

            Console.WriteLine("\nВиштовхуємо 2 елементи зі стека...");
            Console.WriteLine($"Вилучено: {arrayStack.Pop()}");
            Console.WriteLine($"Вилучено: {arrayStack.Pop()}");

            Console.Write("Залишок стека на основі масиву (від вершини до дна): ");
            arrayStack.Print();


            Console.WriteLine("\n--- ДЕМОНСТРАЦІЯ СТЕКА НА ОСНОВІ СПИСКУ ---");
            ListStack listStack = new ListStack();

            Console.WriteLine("Введіть 5 цілих чисел для стека на основі списку:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Елемент {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int val))
                {
                    listStack.Push(val);
                }
                else
                {
                    Console.WriteLine("Некоректне число, записуємо 0.");
                    listStack.Push(0);
                }
            }

            Console.WriteLine("\nВиштовхуємо 2 елементи зі стека...");
            Console.WriteLine($"Вилучено: {listStack.Pop()}");
            Console.WriteLine($"Вилучено: {listStack.Pop()}");

            Console.Write("Залишок стека на основі списку (від вершини до дна): ");
            listStack.Print();

            Console.ReadLine();
        }
    }
}