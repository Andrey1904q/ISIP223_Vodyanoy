using System;

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
    public int Data { get; set; }
    public int Price { get; set; }
}
