using System;

namespace Lab2_2
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

        // Метод пошуку мінімуму/максимуму та їх обміну місцями
        public void SwapMinMax()
        {
            if (head == null || head.Next == null)
            {
                return;
            }

            Node minNode = head;
            Node maxNode = head;
            Node current = head.Next;

            // Пошук мінімального та максимального вузлів за один прохід списку
            while (current != null)
            {
                if (current.Data < minNode.Data)
                {
                    minNode = current;
                }
                if (current.Data > maxNode.Data)
                {
                    maxNode = current;
                }
                current = current.Next;
            }

            // Якщо мінімум і максимум — це один і той самий елемент (усі елементи однакові)
            if (minNode == maxNode)
            {
                Console.WriteLine("Усі елементи списку однакові. Обмін не потрібен.");
                return;
            }

            Console.WriteLine($"\n[INFO] Знайдено мінімум: {minNode.Data}");
            Console.WriteLine($"[INFO] Знайдено максимум: {maxNode.Data}");

            // Обмін значеннями між вузлами
            int temp = minNode.Data;
            minNode.Data = maxNode.Data;
            maxNode.Data = temp;
            
            Console.WriteLine("[SUCCESS] Елементи успішно поміняно місцями!");
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

            list.Add(25);
            list.Add(7);
            list.Add(12);
            list.Add(89);
            list.Add(43);
            list.Add(18);

            Console.WriteLine("--- ПОЧАТКОВИЙ СТАН СПИСКУ ---");
            list.Print();

            list.SwapMinMax();

            Console.WriteLine("\n--- СТАН СПИСКУ ПІСЛЯ ОБМІНУ ---");
            list.Print();

            Console.ReadLine();
        }
    }
}