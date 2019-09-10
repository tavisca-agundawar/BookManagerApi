using Xunit;
using WebApiTraining.Model;
using FluentAssertions;

namespace BookApiTest
{
    public class TestGetBookByTitle
    {
        [Fact]
        public void Test_Get_Book_By_Title()
        {
            //Arrange
            BookService bookService = new BookService();
            Book testBook = new Book() { Title = "The BFG", Author = "Roahld Dahl", Category = "Children", Id = 4, Price = 870 };

            //Act
            var result = bookService.GetBookByTitle("The BFG").Book;

            //Assert
            result.Should().BeEquivalentTo(testBook);
        }
    }
}
