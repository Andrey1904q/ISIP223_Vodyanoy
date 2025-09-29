using System;
using System.Collections.Generic;

// Класс для хранения статистики по обработанному тексту
class TextStatistics
{
    public int WordCount { get; set; }
    public string ShortestWord { get; set; }
    public int SentenceCount { get; set; }
    public int VowelCount { get; set; }
    public int ConsonantCount { get; set; }
    public string LongestWord { get; set; }
    public Dictionary<char, int> LetterFrequency { get; set; }

    // Конструктор для инициализации словаря частоты букв
    public TextStatistics()
    {
        LetterFrequency = new Dictionary<char, int>();
        ShortestWord = "";
        LongestWord = "";
    }
}

class Program
{
    static void Main()
    {
        List<TextStatistics> history = new List<TextStatistics>();

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Обработать новый текст");
            Console.WriteLine("2. Показать историю обработки");
            Console.WriteLine("3. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ProcessNewText(history);
                    break;
                case "2":
                    //                  ShowHistory(history);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
    // Метод для обработки нового текста
    static void ProcessNewText(List<TextStatistics> history)
    {
        string text;
        // Проверка длины текста (минимум 100 символов)
        do
        {
            Console.WriteLine("\nВведите текст (минимум 100 символов):");
            text = Console.ReadLine();
            if (text.Length < 100)
                Console.WriteLine("Ошибка: текст должен содержать не менее 100 символов!");
        } while (text.Length < 100);
    }
}

