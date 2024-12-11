// Завдання 1: Розбиття рядка на символи та числа
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Task1()
    {
        Console.WriteLine("Введіть рядок, що містить символи і числа:");
        string input = Console.ReadLine();

        Stack<char> charStack = new Stack<char>();
        Stack<int> numberStack = new Stack<int>();

        foreach (char c in input)
        {
            if (char.IsDigit(c))
                numberStack.Push(int.Parse(c.ToString()));
            else if (char.IsLetter(c))
                charStack.Push(c);
        }

        Console.WriteLine("Символи:");
        Console.WriteLine(string.Join(", ", charStack));

        Console.WriteLine("Числа:");
        Console.WriteLine(string.Join(", ", numberStack));
    }

    // Завдання 2: Розбиття рядка на голосні та приголосні літери
    static void Task2()
    {
        Console.WriteLine("Введіть рядок:");
        string input = Console.ReadLine();

        Stack<char> vowelsStack = new Stack<char>();
        Stack<char> consonantsStack = new Stack<char>();
        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                if (vowels.Contains(c))
                    vowelsStack.Push(c);
                else
                    consonantsStack.Push(c);
            }
        }

        Console.WriteLine("Голосні:");
        Console.WriteLine(string.Join(", ", vowelsStack));

        Console.WriteLine("Приголосні:");
        Console.WriteLine(string.Join(", ", consonantsStack));
    }

    // Завдання 3: Сортування масиву за допомогою стеку
    static void Task3()
    {
        int[] array = { 5, 3, 8, 6, 2, 7, 4, 1 };
        Console.WriteLine("Початковий масив:");
        Console.WriteLine(string.Join(", ", array));

        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < array.Length; i++)
        {
            int num = array[i];
            while (stack.Count > 0 && stack.Peek() > num)
            {
                array[i] = stack.Pop(); // Зберігаємо поточний стан
                i--; // Повертаємось до попереднього індексу
            }
            stack.Push(num);
        }

        // Копіюємо стек у відсортований масив
        for (int i = array.Length - 1; i >= 0; i--)
        {
            array[i] = stack.Pop();
        }

        Console.WriteLine("Відсортований масив:");
        Console.WriteLine(string.Join(", ", array));
    }

    // Завдання 4: Черга
    static void Task4()
    {
        Console.WriteLine("Введіть n (кількість елементів черги):");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Введіть k (кількість елементів для видалення):");
        int k = int.Parse(Console.ReadLine());

        if (n <= 0 || k < 0)
        {
            Console.WriteLine("Числа n і k повинні бути додатними.");
            return;
        }

        Queue<int> queue = new Queue<int>();
        Random rnd = new Random();

        // Заповнення черги
        for (int i = 0; i < n; i++)
        {
            queue.Enqueue(rnd.Next(1, 101));
        }

        Console.WriteLine("Вміст черги:");
        Console.WriteLine(string.Join(", ", queue));

        // Перевірка, чи k перевищує n
        if (k > n)
        {
            Console.WriteLine("Кількість елементів для видалення перевищує розмір черги. Видалено буде всі елементи.");
            k = n;
        }

        // Видалення перших k елементів
        Console.WriteLine($"Перші {k} елементів черги:");
        for (int i = 0; i < k; i++)
        {
            Console.WriteLine(queue.Dequeue());
        }

        // Виведення залишкової черги
        Console.WriteLine("Черга після видалення:");
        Console.WriteLine(queue.Count > 0 ? string.Join(", ", queue) : "Черга порожня.");
    }

    // Головний метод для запуску задач
    static void Main(string[] args)
    {
        Console.WriteLine("Оберіть задачу для виконання (1-4):");
        int task = int.Parse(Console.ReadLine());

        switch (task)
        {
            case 1:
                Task1();
                break;
            case 2:
                Task2();
                break;
            case 3:
                Task3();
                break;
            case 4:
                Task4();
                break;
            default:
                Console.WriteLine("Неправильний вибір задачі.");
                break;
        }
    }
}
