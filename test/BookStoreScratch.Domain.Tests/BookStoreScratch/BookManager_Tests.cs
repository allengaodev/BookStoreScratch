using System;
using FluentAssertions;
using Xunit;

namespace BookStoreScratch;

public class Book_Tests
{
    [Fact]
    public void Constructor_Should_Create_Book_With_Valid_Inputs()
    {
        // Arrange
        var id = Guid.NewGuid();
        var name = "Test Book";
        var bookType = BookType.Adventure;
        var publishDate = new DateTime(2024, 1, 1);
        var price = 19.99m;

        // Act
        var book = new Book(id, name, bookType, publishDate, price);

        // Assert
        book.Should().NotBeNull();
        book.Id.Should().Be(id);
        book.Name.Should().Be(name);
        book.BookType.Should().Be(bookType);
        book.PublishDate.Should().Be(publishDate);
        book.Price.Should().Be(price);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_Should_Throw_Exception_For_Invalid_Name(string invalidName)
    {
        // Arrange
        var id = Guid.NewGuid();
        var bookType = BookType.Adventure;
        var publishDate = new DateTime(2024, 1, 1);
        var price = 19.99m;

        // Act
        Action act = () => new Book(id, invalidName, bookType, publishDate, price);

        // Assert
        act.Should().Throw<Exception>();
    }

    [Fact]
    public void Constructor_Should_Throw_Exception_For_Default_BookType()
    {
        // Arrange
        var id = Guid.NewGuid();
        var name = "Test Book";
        var bookType = default(BookType); // Undefined
        var publishDate = new DateTime(2024, 1, 1);
        var price = 19.99m;

        // Act
        Action act = () => new Book(id, name, bookType, publishDate, price);

        // Assert
        act.Should().Throw<Exception>();
    }

    [Fact]
    public void Constructor_Should_Throw_ArgumentException_For_Negative_Price()
    {
        // Arrange
        var id = Guid.NewGuid();
        var name = "Test Book";
        var bookType = BookType.Adventure;
        var publishDate = new DateTime(2024, 1, 1);
        var price = -5m;

        // Act
        Action act = () => new Book(id, name, bookType, publishDate, price);

        // Assert
        act.Should().Throw<ArgumentException>()
           .WithMessage("Price must be greater than or equal to 0.");
    }
}