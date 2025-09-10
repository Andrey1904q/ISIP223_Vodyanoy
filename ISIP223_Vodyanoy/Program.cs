using System;
class Program
{
    static void Main(string[] args)
    {
        int count;
        do
        {
            Console.Write("Сколько покупок я сделал?: ");
        } while (!int.TryParse(Console.ReadLine(), out count) || count < 2 || count > 40);

        string[] names = new string[count];
        decimal[] prices = new decimal[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write($"{i + 1}. Что я купил и сколько?: ");
            string[] parts = Console.ReadLine().Split(';');

            if (parts.Length < 2)
            {
                Console.WriteLine("Формат: название; цена");
                i--;
                continue;
            }
            names[i] = parts[0].Trim();
            if (!decimal.TryParse(parts[1].Trim(), out prices[i]) || prices[i] <= 0)
            {
                Console.WriteLine("Цена должна быть числом > 0");
                i--;
            }
        }

        while (true)
        {
            Console.WriteLine("\n---1. Все покупки ---\n---2. Статистика ---\n---3. Сортировка --- \n--- 4.Конвертация --- \n---5. Поиск\n---0. Выход ---");
            Console.Write("Выбор: ");
            switch (Console.ReadLine())
            {
                case "0": return;

                case "1":
                    for (int i = 0; i < count; i++)
                        Console.WriteLine($"{names[i]} - {prices[i]} руб.");
                    break;

                case "2":
                    decimal total = 0, min = prices[0], max = prices[0];
                    for (int i = 0; i < count; i++)
                    {
                        total += prices[i];
                        if (prices[i] < min) min = prices[i];
                        if (prices[i] > max) max = prices[i];
                    }
                    Console.WriteLine($"Всего: {total} руб.");
                    Console.WriteLine($"В среднем: {total / count} руб.");
                    Console.WriteLine($"От {min} до {max} руб.");
                    break;

                case "3":
                    for (int i = 0; i < count - 1; i++)
                    {
                        for (int j = 0; j < count - i - 1; j++)
                        {
                            if (prices[j] > prices[j + 1])
                            {
                                (prices[j], prices[j + 1]) = (prices[j + 1], prices[j]);
                                (names[j], names[j + 1]) = (names[j + 1], names[j]);
                            }
                        }
                    }
                    Console.WriteLine("Готово!");
                    break;

                case "4":
                    Console.WriteLine("\nВыберите валюту для конвертации:");
                    Console.WriteLine("1. Баксы (курс: 87 руб.)");
                    Console.WriteLine("2. Беларус (курс: 27 руб.)");
                    Console.WriteLine("3. Свой курс");
                    Console.Write("Ваш выбор: ");

                    string currencyChoice = Console.ReadLine();
                    decimal rate = 0;
                    string currencyName = "";

                    switch (currencyChoice)
                    {
                        case "1":
                            rate = 87m;
                            currencyName = "доллар курс";
                            break;

                        case "2":
                            rate = 27m;
                            currencyName = "беларусы курс";
                            break;

                        case "3":
                            Console.Write("Введите свой курс конвертации : ");
                            if (!decimal.TryParse(Console.ReadLine(), out rate) || rate <= 0)
                            {
                                Console.WriteLine("Неверный курс");
                                continue;
                            }
                            currencyName = "валюта";
                            break;

                        default:
                            Console.WriteLine("Неверный выбор");
                            continue;
                    }

                    Console.WriteLine($"\n--- Товары после конвертации ---");
                    for (int i = 0; i < count; i++)
                    {
                        decimal convertedPrice = prices[i] / rate;
                        Console.WriteLine($"{names[i]} - {convertedPrice:F2} {currencyName} (было {prices[i]} руб.)");
                    }
                    break;

                case "5":
                    Console.Write("Что ищем?: ");
                    string search = Console.ReadLine().ToLower();
                    bool found = false;

                    for (int i = 0; i < count; i++)
                    {
                        if (names[i].ToLower().Contains(search))
                        {
                            Console.WriteLine($"{names[i]} - {prices[i]} руб.");
                            found = true;
                        }
                    }

                    if (!found) Console.WriteLine("Не найдено");
                    break;

                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }
        }
    }
}