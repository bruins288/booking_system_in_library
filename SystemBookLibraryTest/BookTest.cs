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
}
