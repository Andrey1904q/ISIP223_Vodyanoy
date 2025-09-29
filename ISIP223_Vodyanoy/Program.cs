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

        // Обработка текста и сохранение статистики
        TextStatistics stats = AnalyzeText(text);
        history.Add(stats);

        // Вывод результатов для текущего текста
        Console.WriteLine("\nСтатистика по текущему тексту:");
        PrintStatistics(stats);
    }
    // Метод анализа текста
    static TextStatistics AnalyzeText(string text)
    {
        TextStatistics stats = new TextStatistics();
        string currentWord = "";
        bool inWord = false;
        string vowels = "аеёиоуыэюя"; // Русские гласные буквы

        // Проход по каждому символу текста
        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            char lowerC = char.ToLower(c);

            // Подсчёт предложений (по знакам завершения)
            if (c == '.' || c == '!' || c == '?')
                stats.SentenceCount++;

            // Проверка является ли символ буквой
            if (char.IsLetter(c))
            {
                // Обработка текущего слова
                if (!inWord)
                {
                    inWord = true;
                    currentWord = c.ToString();
                }
                else
                {
                    currentWord += c;
                }

                // Подсчёт гласных и согласных
                if (vowels.Contains(lowerC))
                    stats.VowelCount++;
                else
                    stats.ConsonantCount++;

                // Статистика частоты букв
                if (stats.LetterFrequency.ContainsKey(lowerC))
                    stats.LetterFrequency[lowerC]++;
                else
                    stats.LetterFrequency[lowerC] = 1;
            }
            else
            {
                // Завершение текущего слова
                if (inWord)
                {
                    inWord = false;
                    stats.WordCount++;

                    // Обновление данных о самом коротком слове
                    if (stats.ShortestWord == "" || currentWord.Length < stats.ShortestWord.Length)
                        stats.ShortestWord = currentWord;

                    // Обновление данных о самом длинном слове
                    if (currentWord.Length > stats.LongestWord.Length)
                        stats.LongestWord = currentWord;
                }
            }
        }
        // Проверка на случай, если текст заканчивается словом
        if (inWord)
        {
            stats.WordCount++;
            if (stats.ShortestWord == "" || currentWord.Length < stats.ShortestWord.Length)
                stats.ShortestWord = currentWord;
            if (currentWord.Length > stats.LongestWord.Length)
                stats.LongestWord = currentWord;
        }

        return stats;
    }