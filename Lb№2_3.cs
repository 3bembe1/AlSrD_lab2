using System;

namespace Lab2_3
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

    // Клас для керування динамічним однозв'язним списком
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

        // Метод для підрахунку кількості різних елементів
        public int CountDistinctElements()
        {
            if (head == null) return 0;

            int distinctCount = 0;
            Node current = head;

            // Зовнішній цикл: перебираємо кожен елемент списку
            while (current != null)
            {
                Node runner = head;
                bool alreadySeen = false;

                // Внутрішній цикл: перевіряємо, чи зустрічалося таке число ліворуч від current
                while (runner != current)
                {
                    if (runner.Data == current.Data)
                    {
                        alreadySeen = true;
                        break;
                    }
                    runner = runner.Next;
                }

                // Якщо елемент з'явився вперше
                if (!alreadySeen)
                {
                    distinctCount++;
                }

                current = current.Next;
            }

            return distinctCount;
        }

        // Метод для друку вмісту списку
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

            CustomLinkedList list1 = new CustomLinkedList();
            list1.Add(1);
            list1.Add(2);
            list1.Add(2);
            list1.Add(1);

            Console.WriteLine("--- ТЕСТ 1 (Приклад із завдання) ---");
            Console.Write("Вміст списку: ");
            list1.Print();
            Console.WriteLine($"Кількість різних чисел у списку: {list1.CountDistinctElements()}");

            CustomLinkedList list2 = new CustomLinkedList();
            list2.Add(5);
            list2.Add(5);
            list2.Add(10);
            list2.Add(5);
            list2.Add(20);
            list2.Add(10);
            list2.Add(30);

            Console.WriteLine("\n--- ТЕСТ 2 (Розширений список) ---");
            Console.Write("Вміст списку: ");
            list2.Print();
            Console.WriteLine($"Кількість різних чисел у списку: {list2.CountDistinctElements()}");

            Console.ReadLine();
        }
    }
}