DisplayMessage("Система бронирования книг в библиотеке.\n", ConsoleColor.Yellow);
DisplayMessage("Создаем библиотеку из 10 книг.");
GenerateLibraryOfTenBooks();
DisplayMessage("Какая вас книга интересует: ", ConsoleColor.Blue, false);
var input = Console.ReadLine();
try
{
    BorrowBook(input);
    ReturnBook(input);
}
catch (ArgumentException ex)
{
    DisplayMessage(ex.Message, ConsoleColor.Red);
}
catch (InvalidOperationException ex)
{
    DisplayMessage(ex.Message, ConsoleColor.Red);
}
catch (KeyNotFoundException ex)
{
    DisplayMessage(ex.Message, ConsoleColor.Red);
}

Console.ReadKey();