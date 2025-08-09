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
    /// <summary>
    /// Метод добавления книги в библиотеку
    /// </summary>
    /// <param name="book">книга</param>
    /// <exception cref="InvalidOperationException">Генерируется если в библиотеке нет мест</exception>
    /// <exception cref="ArgumentException">Генерируется если в библиотеке уже есть такая книга</exception>
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
    /// <summary>
    /// Метод поиска книги по названию.
    /// </summary>
    /// <param name="title">Название книги</param>
    /// <returns>ВВозвращает название книги, если книга не найдена возвращает null</returns>
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
