using System;
using FluentAssertions;
using Xunit;

namespace BookStoreScratch;

public class BookManager_Tests
{
    private readonly BookManager _bookManager;

    public BookManager_Tests()
    {
        _bookManager = new BookManager();
    }

    [Fact]
    public void CreateBook_Should_Create_Book_With_Valid_Inputs()
    {
        // Arrange
        var name = "Test Book";
        var bookType = BookType.Adventure;
        var publishDate = new DateTime(2024, 1, 1);
        var price = 19.99m;
    
        // Act
        var book = _bookManager.CreateBook(name, bookType, publishDate, price);
    
        // Assert
        book.Should().NotBeNull();
        book.Name.Should().Be(name);
        book.BookType.Should().Be(bookType);
        book.PublishDate.Should().Be(publishDate);
        book.Price.Should().Be(price);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void CreateBook_Should_Throw_ArgumentException_For_Invalid_Name(string invalidName)
    {
        // Arrange
        var bookType = BookType.Adventure;
        var publishDate = new DateTime(2024, 1, 1);
        var price = 19.99m;

        // Act
        Action act = () => _bookManager.CreateBook(invalidName, bookType, publishDate, price);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("*name*");
    }

    [Fact]
    public void CreateBook_Should_Throw_ArgumentException_For_Default_BookType()
    {
        // Arrange
        var name = "Test Book";
        var bookType = default(BookType);
        var publishDate = new DateTime(2024, 1, 1);
        var price = 19.99m;

        // Act
        Action act = () => _bookManager.CreateBook(name, bookType, publishDate, price);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("*bookType*");
    }

    [Fact]
    public void CreateBook_Should_Throw_ArgumentException_For_Default_PublishDate()
    {
        // Arrange
        var name = "Test Book";
        var bookType = BookType.Adventure;
        var publishDate = default(DateTime);
        var price = 19.99m;

        // Act
        Action act = () => _bookManager.CreateBook(name, bookType, publishDate, price);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("*publishDate*");
    }

    [Fact]
    public void CreateBook_Should_Throw_ArgumentException_For_Negative_Price()
    {
        // Arrange
        var name = "Test Book";
        var bookType = BookType.Adventure;
        var publishDate = new DateTime(2024, 1, 1);
        var price = -5m;

        // Act
        Action act = () => _bookManager.CreateBook(name, bookType, publishDate, price);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("Price must be greater than or equal to 0.");
    }
}