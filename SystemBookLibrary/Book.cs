namespace SystemBookLibrary;
/// <summary>
/// Описывает книгу в библиотеке
/// </summary>
public class Book
{
    /// <summary>
    /// Название книги
    /// </summary>
    public string Title { get; private set; }
    /// <summary>
    /// Автор книги
    /// </summary>
    public string Author { get; private set; }
    /// <summary>
    /// Показывает забронирована ли книга
    /// </summary>
    public bool IsAvailable { get; private set; }
    /// <summary>
    /// Конструктор используется для создания экземпляра книги
    /// </summary>
    /// <param name="title">Название книги</param>
    /// <param name="author">Автор книги</param>
    /// <param name="isAvailable">Доступна ли книга для бронирования</param>
    public Book(string title, string author, bool isAvailable = true)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(title, nameof(title));
        ArgumentNullException.ThrowIfNullOrWhiteSpace(author, nameof(author));

        Title = title;
        Author = author;
        IsAvailable = isAvailable;
    }
    /// <summary>
    /// Бронирование книги
    /// </summary>
    /// <exception cref="InvalidOperationException">Исключение за попытку забронировать книгу которая занята</exception>
    public void Borrow()
    {
        IsAvailable = IsAvailable ? false : throw new InvalidOperationException($"Книгу {Title} автора {Author} нельзя забронировать.");
    }
    /// <summary>
    /// Возвращает книгу в библиотеку
    /// </summary>
    public void Return()
    {
        IsAvailable = true;
    }
    /// <summary>
    /// Выводит статус книги
    /// </summary>
    public void DisplayStatus()
    {
        Console.WriteLine($"Книга {Title} автора {Author} доступна? {IsAvailable}");
    }  
}
