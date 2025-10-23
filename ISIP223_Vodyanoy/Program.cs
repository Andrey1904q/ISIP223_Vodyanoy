using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;
using System.Linq;

public enum Genre
{
    Detective,
    Novel,
    Story,
    Comedy,
    Tragedy,
    Fantasy,
    Prose,
    Classic,
    Antiutopia
}

class Book
{
    public string ID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Date { get; set; }
    public int Price { get; set; }

public Book (string id, string title, string author, string genre, int date, int price)
{
        if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID не может быть пустым");
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("название не может быть пустым");
        if (string.IsNullOrWhiteSpace(author)) throw new ArgumentException("книга не может быть без автора");
        if (price < 0) throw new ArgumentException("цена не может быть отрицательной");
        if (date < 0 || date > DateTime.Now.Year + 1) throw new ArgumentException("Год изддания неккоректен");

        ID = id;
        Title = title;
        Author = author;
        Genre = genre;
        Date = date;
        Price = price;
}
    public override string ToString()
    {
        return $"Код: {ID}\n" +
               $"Название: {Title}\n" +
               $"Автор: {Author}\n" +
               $"Жанр: {Genre}\n" +
               $"Дата Издания: {Date}\n" +
               $"Цена: {Price}\n" +
               new string('-', 40);
    }
}
class Program
{
    private static List<Book> products = new List<Book>();
    private static int NextCodeNumber = 1;
    static void Main(string[] args)
    {
        InitializeTestData();

        while (true)
        {
            ShowMenu();
            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Add();
                        break;
                    case "2":
                        Delete();
                        break;
                    case "3":
                        Research();
                        break;
                    case "4":
                        Sort();
                        break;
                    case "5":
                        ShowCheapExpensive();
                        break;
                    case "6":
                        GroupBooksByAuthor();
                        break;
                    case "0":
                        Console.WriteLine("Выход из программы. До свидания!");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите пункт от 0 до 6.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }

        static void InitializeTestData()
    }
}
