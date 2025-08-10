using System.Text;
using SystemBookLibrary;

internal partial class Program
{
    private static readonly Library library = new();
    private static void DisplayMessage(string message, ConsoleColor color = ConsoleColor.DarkGray, bool isNewLine = true)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.ForegroundColor = color;
        if (isNewLine)
        {
            Console.WriteLine(message);
        }
        else
        {
            Console.Write(message);
        }
        Console.ResetColor();

    }
    private static void GenerateLibraryOfTenBooks()
    {
        try
        {
            library.AddBook(new("Идиот", "Ф. М. Достоевский"));
            library.AddBook(new("Бесы", "Ф. М. Достоевский"));
            library.AddBook(new("Война и мир", "Л. Н. Толстой"));
            library.AddBook(new("Мастер и Маргарита", "М. А. Булгаков"));
            library.AddBook(new("Лолита", "В. Набоков"));
            library.AddBook(new("Леди Макбет Мценского уезда", "Н. Лесков"));
            library.AddBook(new("Гранатовый браслет", "А. Куприн"));
            library.AddBook(new("Раковый корпус", "А. Солженицын"));
            library.AddBook(new("Пикник на обочине", "братья Стругацкие"));
            library.AddBook(new("Голубое сало", "В. Сорокин"));
        }
        catch (ArgumentException ex)
        {
            DisplayMessage(ex.Message, ConsoleColor.Red);
        }        
        catch (InvalidOperationException ex)
        {
            DisplayMessage(ex.Message, ConsoleColor.Red);
        }
    }
    private static void BorrowBook(string? title)
    {

        Book? foundedBook = FindBookByTitle(title) ?? throw new KeyNotFoundException("Книга не найдена");
        if (!foundedBook.IsAvailable)
        {
            throw new InvalidOperationException("Книга уже занята");
        }
        foundedBook.Borrow();
        DisplayMessage("Книга забронирована.", ConsoleColor.Green);
    }
    private static void ReturnBook(string? title)
    {
        Book? foundedBook = FindBookByTitle(title) ?? throw new KeyNotFoundException("Книга не найдена");
        foundedBook.Return();
        DisplayMessage("Книга возвращена", ConsoleColor.Green);

    }
    private static Book? FindBookByTitle(string? title)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        return library.FindBook(title);
    }
}
