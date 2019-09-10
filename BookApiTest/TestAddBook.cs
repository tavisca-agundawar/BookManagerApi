using Xunit;
using WebApiTraining.Model;
using FluentAssertions;

namespace BookApiTest
{
    public class TestAddBook
    {
        [Fact]
        public void Test_Add_Book()
        {
            //Arrange
            BookService bookService = new BookService();
            Book testBook = new Book() { Title = "Wavelets", Author = "Jaidev", Category = "Education", Price = 200 };

            //Act
            var result = bookService.AddBook(testBook).Book;
            
            //Assert
            result.Should().BeEquivalentTo(testBook);
        }
    }
}
