using System;
using library_demo;

class Program
{
    static void Main(string[] args)
    {
        Book book1 = new Book();
        book1.SetAuthor("Sukuna");
        book1.SetTitle("Malevolent Shrine");

        Console.WriteLine(book1.GetBookInfo());


        PictureBook book2 = new PictureBook();
        book2.SetAuthor("Gojo");
        book2.SetTitle("Infinite Void");
        book2.SetIllustrator("Satoru");

        Console.WriteLine(book2.GetBookInfo());
        Console.WriteLine(book2.GetPictureBook());

        Book book3 = new Book("Dante", "Another book");
        Console.WriteLine(book3.GetBookInfo());

        PictureBook book4 = new PictureBook();
        book4.SetIllustrator("??");
        Console.WriteLine(book4.GetBookInfo());
        Console.WriteLine(book4.GetPictureBook());

        PictureBook book5 = new PictureBook("Itadori", "Black Flash", "Yuji");
        Console.WriteLine(book5.GetPictureBook());
    }
}