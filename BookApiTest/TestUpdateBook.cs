using Xunit;
using WebApiTraining.Model;
using FluentAssertions;

namespace BookApiTest
{
    public class TestUpdateBook
    {
        [Fact]
        public void Test_Update_Book()
        {
            //Arrange
            BookService bookService = new BookService();
            Book testBook = new Book() { Title = "Wavelets", Author = "Jaidev", Id = 3, Category = "Education", Price = 200 };
            int id = 3;

            //Act
            var result = bookService.UpdateBookDetails(id, testBook).Book;
            
            //Assert
            result.Should().BeEquivalentTo(testBook);
        }
    }
}
