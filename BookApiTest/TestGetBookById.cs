using Xunit;
using WebApiTraining.Model;
using FluentAssertions;

namespace BookApiTest
{
    public class TestGetBookById
    {
        [Fact]
        public void Test_Get_Book_By_Id()
        {
            //Arrange

            BookService bookService = new BookService();
            Book testBook = new Book() { Title = "The BFG", Author = "Roahld Dahl", Category = "Children", Id = 4, Price = 870 };

            //Act
            var result = bookService.GetBookById(4).Book;

            //Assert
            result.Should().BeEquivalentTo(testBook);
        }
    }
}
