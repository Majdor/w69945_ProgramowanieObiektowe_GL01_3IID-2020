//zadanie 1

using System;

public abstract class Shape
{
    public abstract double CalculateArea();
}
public class Circle : Shape
{
    public double Radius { get; }
    public Circle(double radius) => Radius = radius;
    public override double CalculateArea() => Math.PI * Radius * Radius;
}
public class Square : Shape
{
    public double SideLength { get; }
    public Square(double sideLength) => SideLength = sideLength;
    public override double CalculateArea() => SideLength * SideLength;
}
class Program
{
    static void Main()
    {
        Shape circle = new Circle(5);
        Shape square = new Square(4);

        Console.WriteLine("Area of circle: " + circle.CalculateArea());
        Console.WriteLine("Area of square: " + square.CalculateArea());
    }
}

//zadanie 2


public interface IVehicle
{
    void Start();
    void Stop();
    int MaxSpeed { get; set; }
}

public class Car : IVehicle
{
    public int MaxSpeed { get; set; }
    public string Model { get; set; }

    public void Start()
    {
        Console.WriteLine("Samochód uruchamia się.");
    }

    public void Stop()
    {
        Console.WriteLine("Samochód zatrzymuje się.");
    }

    public void Honk()
    {
        Console.WriteLine("Samochód trąbi.");
    }
}

public class Bike : IVehicle
{
    public int MaxSpeed { get; set; }
    public string Type { get; set; }
    public void Start()
    {
        Console.WriteLine("Rower uruchamia się.");
    }
    public void Stop()
    {
        Console.WriteLine("Rower zatrzymuje się.");
    }
    public void RingBell()
    {
        Console.WriteLine("Dzwonek roweru dzwoni.");
    }
}
class Program2
{
    static void Main(string[] args)
    {
        IVehicle myCar = new Car { MaxSpeed = 200, Model = "Sedan" };
        IVehicle myBike = new Bike { MaxSpeed = 50, Type = "Mountain" };

        myCar.Start();
        myCar.Stop();
        ((Car)myCar).Honk();
        myBike.Start();
        myBike.Stop();
        ((Bike)myBike).RingBell();
    }
}

//zadanie 3

public interface IEntity<T>
{
    T Id { get; set; }
}
public interface ICreated
{
    DateTime CreatedDate { get; set; }
}
public class Book : IEntity<int>, ICreated
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
}
public class Person : IEntity<int>, ICreated
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public List<Book> BorrowedBooks { get; set; } = new List<Book>();
}
public interface IBaseRepository<T, TEntity> where T : IEntity<TEntity>
{
    void Create(T entity);
    void Update(T entity);
    IEnumerable<T> GetAll();
    T Get(TEntity id);
    void Delete(TEntity id);
}
public interface IBookRepository : IBaseRepository<Book, int>
{
    IEnumerable<Book> GetBooksByAuthor(string author);
    IEnumerable<Book> GetBooksByYear(int year);
}
public interface IPersonRepository : IBaseRepository<Person, int>
{
    IEnumerable<Book> GetBorrowedBooksByPerson(int personId);
    void AddBookToBorrowedList(int personId, Book book);
}
public class BookRepository : IBookRepository
{
    private readonly List<Book> books = new List<Book>();
    public void Create(Book book)
    {
        books.Add(book);
    }
    public void Update(Book book)
    {
        var existingBook = Get(book.Id);
        if (existingBook != null)
        {
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Year = book.Year;
        }
    }
    public IEnumerable<Book> GetAll()
    {
        return books;
    }
    public Book Get(int id)
    {
        return books.Find(book => book.Id == id);
    }
    public void Delete(int id)
    {
        var book = Get(id);
        if (book != null)
        {
            books.Remove(book);
        }
    }
    public IEnumerable<Book> GetBooksByAuthor(string author)
    {
        return books.Where(book => book.Author == author);
    }
    public IEnumerable<Book> GetBooksByYear(int year)
    {
        return books.Where(book => book.Year == year);
    }
}
public class PersonRepository : IPersonRepository
{
    private readonly List<Person> people = new List<Person>();
    public void Create(Person person)
    {
        people.Add(person);
    }
    public void Update(Person person)
    {
        var existingPerson = Get(person.Id);
        if (existingPerson != null)
        {
            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;
            existingPerson.Age = person.Age;
            existingPerson.BorrowedBooks = person.BorrowedBooks;
        }
    }
    public IEnumerable<Person> GetAll()
    {
        return people;
    }
    public Person Get(int id)
    {
        return people.Find(person => person.Id == id);
    }
    public void Delete(int id)
    {
        var person = Get(id);
        if (person != null)
        {
            people.Remove(person);
        }
    }
    public IEnumerable<Book> GetBorrowedBooksByPerson(int personId)
    {
        var person = Get(personId);
        return person != null ? person.BorrowedBooks : new List<Book>();
    }
    public void AddBookToBorrowedList(int personId, Book book)
    {
        var person = Get(personId);
        if (person != null)
        {
            person.BorrowedBooks.Add(book);
        }
    }
}
public class Program3
{
    public static void Main(string[] args)
    {
        IBookRepository bookRepository = new BookRepository();
        bookRepository.Create(new Book { Id = 1, CreatedDate = DateTime.Now, Title = "C# Programming", Author = "Autor 1", Year = 2024 });
        bookRepository.Create(new Book { Id = 2, CreatedDate = DateTime.Now, Title = "Learning C#", Author = "Autor 1", Year = 2023 });
        bookRepository.Create(new Book { Id = 3, CreatedDate = DateTime.Now, Title = "Advanced C#", Author = "Autor 2", Year = 2024 });
        IPersonRepository personRepository = new PersonRepository();
        personRepository.Create(new Person { Id = 1, CreatedDate = DateTime.Now, FirstName = "Kacper", LastName = "Majda", Age = 30 });
        personRepository.AddBookToBorrowedList(1, bookRepository.Get(1));
        personRepository.AddBookToBorrowedList(1, bookRepository.Get(3));
        foreach (var book in bookRepository.GetBooksByAuthor("Autor 1"))
        {
            Console.WriteLine($"Książka autora 1: {book.Title}");
        }
        foreach (var book in bookRepository.GetBooksByYear(2024))
        {
            Console.WriteLine($"Opublikowana w 2024: {book.Title}");
        }
        foreach (var book in personRepository.GetBorrowedBooksByPerson(1))
        {
            Console.WriteLine($"Books borrowed by Jan Kowalski: {book.Title}");
        }
    }
}
