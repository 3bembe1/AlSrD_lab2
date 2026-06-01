using System;

namespace Lab2_4
{
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

    // Клас для керування однозв'язним списком
    class CustomLinkedList
    {
        private Node head;

        // Метод додавання елемента в кінець списку
        public void Add(int value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        // Метод сортування вибором
        public void SelectionSort()
        {
            if (head == null || head.Next == null)
            {
                return;
            }

            int swapCount = 0;
            Node current = head;

            // Зовнішній цикл: фіксує позицію, куди буде записано мінімальний елемент
            while (current != null)
            {
                Node minNode = current;
                Node runner = current.Next;

                // Внутрішній цикл: пошук мінімального елемента в невідсортованій частині
                while (runner != null)
                {
                    if (runner.Data < minNode.Data)
                    {
                        minNode = runner;
                    }
                    runner = runner.Next;
                }

                if (minNode != current)
                {
                    int temp = current.Data;
                    current.Data = minNode.Data;
                    minNode.Data = temp;
                    swapCount++;
                }

                current = current.Next;
            }

            Console.WriteLine($"\n[INFO] Сортування завершено. Виконано всього перестановок: {swapCount}");
        }

        // Метод для друку списку у консоль
        public void Print()
        {
            if (head == null)
            {
                Console.WriteLine("Список порожній.");
                return;
            }

            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data);
                if (current.Next != null)
                {
                    Console.Write(" -> ");
                }
                current = current.Next;
            }
            Console.WriteLine(" -> NULL");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            CustomLinkedList list = new CustomLinkedList();

            list.Add(45);
            list.Add(12);
            list.Add(85);
            list.Add(32);
            list.Add(9);
            list.Add(60);

            Console.WriteLine("--- СПИСОК ДО СОРТУВАННЯ ---");
            list.Print();

            list.SelectionSort();

            Console.WriteLine("\n--- СПИСОК ПІСЛЯ СОРТУВАННЯ ---");
            list.Print();

            Console.ReadLine();
        }
    }
}