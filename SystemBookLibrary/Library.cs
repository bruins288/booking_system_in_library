namespace SystemBookLibrary;
/// <summary>
/// Класс описывает библиотеку
/// </summary>
public class Library(int countOfBooks = 10)
{
    /// <summary>
    /// Создание библиотеки
    /// </summary>
    private readonly Book[] _books = new Book[countOfBooks];
    private int index = 0;
    /// <summary>
    /// Количество книг в библиотеке
    /// </summary>
    public int CountOfBooks
    {
        get => _books.Length;
    }
    public void AddBook(Book book)
    {
        if (index > countOfBooks - 1)
        {
            throw new InvalidOperationException($"Книгу {book.Title} нельзя добавить в библиотеку - нет свободных мест.");
        }
        if (FindBook(book.Title) is not null)
        {
            throw new ArgumentException($"Такая книга уже есть в библиотеке.");            
        }
        _books[index] = book;
        index++;
    }
    public string? FindBook(string title)
    {
        foreach (var book in _books)
        {
            if (book.Title == title)
            {
                return book.Title;
            }
        }
        return null;
    }
}
