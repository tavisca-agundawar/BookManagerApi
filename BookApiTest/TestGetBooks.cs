using System;
using Xunit;
using WebApiTraining.Model;
using System.Collections.Generic;
using FluentAssertions;

namespace BookApiTest
{
    public class TestGetBooks
    {
        [Fact]
        public void Test_Get_Books()
        {
            //Arrange
            int _idCounter = 0;
            BookService bookService = new BookService();
            List<Book> compareList = new List<Book>
            {
                new Book { Title = "Fundamentals of Wavelets", Author = "Jaideva Goswami", Category = "Education", Id = ++_idCounter, Price = 200 },
                new Book { Title = "Let us C", Author = "Yashavant Kanetkar", Category = "Education", Id = ++_idCounter, Price = 500 },
                new Book { Title = "1984", Author = "George Orwell", Category = "Dystopian", Id = ++_idCounter, Price = 2000 },
                new Book { Title = "The BFG", Author = "Roahld Dahl", Category = "Children", Id = ++_idCounter, Price = 870 }
            };

            //Act
            var testList = bookService.GetBooks().Books;

            //Assert
            testList.Should().BeEquivalentTo(compareList);
        }
    }
}
