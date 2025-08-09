using SystemBookLibrary;

namespace SystemBookLibraryTest;

public class SystemBookLibraryTest
{
    [Fact]
    public void GetUnavailableBookGenerateExeption()
    {
        //Arrange
        Book book = new("Идиот", "Ф. М. Достоевский", false);
        //Act 
        var ex = Assert.Throws<InvalidOperationException>(() => book.Borrow());
        //Assert
        Assert.Equal("Книгу Идиот автора Ф. М. Достоевский нельзя забронировать.", ex.Message);
    }
    [Fact]
    public void GetNullIfNotFoundBook()
    {
        //Arrage
        Library library = new(countOfBooks: 3);
        library.AddBook(new Book("Бесы", " Ф. М. Достоевский"));
        library.AddBook(new Book("Война и мир", "Л. Н. Толстой"));
        library.AddBook(new Book("Мастер и Маргарита", "М. А. Булгаков"));
        //Act
        Book? book = library.FindBook("Лолита");
        //Assert
        Assert.Null(book);
    }
}
