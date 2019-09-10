using Xunit;
using WebApiTraining.Model;
using FluentAssertions;

namespace BookApiTest
{
    public class TestDeleteBook
    { 
        [Fact]
        public void Test_Delete_Book()
        {
            //Arrange
            BookService bookService = new BookService();

            //Act
            bool result = bookService.DeleteBookById(2);

            //Assert
            result.Should().BeTrue();
        }
    }
}
