//using System;

//public class Osoba
//{
//    private string imię;
//    private string nazwisko;
//    private int wiek;
//    private string pesel;

//    public Osoba(string imię, string nazwisko, int wiek, string pesel)
//    {
//        this.imię = imię;
//        this.nazwisko = nazwisko;
//        Wiek = wiek;
//        this.pesel = pesel;
//    }

//    public string Imię
//    {
//        get { return imię; }
//        set { imię = value; }
//    }

//    public string Nazwisko
//    {
//        get { return nazwisko; }
//        set { nazwisko = value; }
//    }

//    public int Wiek
//    {
//        get { return wiek; }
//        set { wiek = value < 0 ? 0 : value; }
//    }

//    public string Pesel
//    {
//        get { return pesel; }
//    }

//    public string PrzedstawSie()
//    {
//        return $"Nazywam się {Imię} {Nazwisko} i mam {Wiek} lat";
//    }
//}

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        Osoba osoba = new Osoba("Jan", "Kowalski", 25, "123456789");

//        Console.WriteLine(osoba.PrzedstawSie());
//    }
//}






//zadanie 2 


//class Licz
//{
//    public int wartosc;
//    public void dodaj(int x)
//    {
//        wartosc = x + wartosc;
//    }
//    public void odejmij(int x)
//    {
//        wartosc = wartosc - x;
//    }
//    public Licz(int Wartosc)
//    {
//        wartosc = Wartosc;
//    }
//    public int Wartosc
//    {
//        get { return wartosc; }
//    }
//}



//zadanie 3


using System;
using System.Linq;

public class Sumator
{
    // Publiczne pole Liczby będące tablicą int
    public int[] Liczby { get; set; }

    // Konstruktor opcjonalny, aby umożliwić inicjalizację
    public Sumator(int[] liczby)
    {
        Liczby = liczby;
    }


    public int Suma()
    {
        return Liczby?.Sum() ?? 0; 
    }

   
    public int SumaPodziel3()
    {
        return Liczby?.Where(x => x % 3 == 0).Sum() ?? 0;
    }

   
    public void Wyswietl(int Low, int High)
    {
        if (Liczby == null || Liczby.Length == 0)
        {
            Console.WriteLine("Tablica Liczby jest pusta.");
            return;
        }

        if (Low < 0)
            Low = 0;
        if (High >= Liczby.Length)
            High = Liczby.Length - 1;

        for (int i = Low; i <= High; i++)
        {
            Console.WriteLine(Liczby[i]);
        }
    }
}

