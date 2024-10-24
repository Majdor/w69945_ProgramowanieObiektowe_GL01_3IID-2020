//zad 1

//using System;

//public class Test
//{
//    public static void Main()
//    {
//        System.Console.WriteLine("Podaj liczbe...");
//        int n = int.Parse(Console.ReadLine());
//        if (n % 2 == 0) System.Console.WriteLine("Podana liczba jest parzysta.");
//        else System.Console.WriteLine("Podana liczba nie jest parzysta.");
//    }
//}















//zad 2

//using System;

//class Program
//{
//    static void Main()
//    {
//        System.Console.WriteLine("Podaj liczbe ");
//        int N =
//        int.Parse(Console.ReadLine());
//        Console.WriteLine("Liczby parzyste od 1 do" + N + ";");
//            for (int i = 1; 1 <= N; i++)
//            if (i % 2 == 0)
//            {
//                Console.WriteLine(i + "");
//            }
//    }
//}


//zad 3

using System;

class Program
{
    static void Main(string[] args)
    {
        string wybor;

        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1.Zrób 1");
            Console.WriteLine("2. Zrób 2");
            Console.WriteLine("3. Zrób 3");
            Console.WriteLine("4. Wyjście");
            Console.Write("Wybierz opcję: ");

            wybor = Console.ReadLine();

            if (wybor == "1")
            {
                Console.WriteLine("Zrobino 1.");
            }
            else if (wybor == "2")
            {
                Console.WriteLine("Zrobino 2.");
            }
            else if (wybor == "3")
            {
                Console.WriteLine("Zrobino 3.");
            }
            else if (wybor == "4")
            {
                Console.WriteLine("Zamykanie programu...");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy wybór, spróbuj ponownie.");
            }

            Console.WriteLine();
        }
        while (wybor != "4");
    }
}


//zad 4


//using System;

//class Program
//{
//    static void Main()
//    {
//        System.Console.WriteLine("Podaj liczbe ");
//        int Liczba =
//       int.Parse(Console.ReadLine());
//        long silnia = 1;
//        for (int i = 2; i <= Liczba; i++)
//        {
//            silnia *= i;
//        }
//        Console.WriteLine("Silnia Liczby" + Liczba + "to:" + silnia);
//    }
//}


//zad 5

//string x = Console.ReadLine();
//int l = int.Parse(x);

//Random rnd = new Random();
//int rand = rnd.Next(l);
//int tries = 0;
//while (true)
//{
//    Console.WriteLine("Zgadnij liczbe od 0 do " + l);
//    string t = Console.ReadLine();
//    int ti = int.Parse(t);
//    tries++;
//    if (ti != rand) { Console.WriteLine("sprobuj ponownie"); }
//    else { Console.WriteLine("Zgadles w " + tries + " prob!"); break; }
//}