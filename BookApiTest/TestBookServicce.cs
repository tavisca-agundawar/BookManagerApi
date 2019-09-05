using System;
using Xunit;
using WebApiTraining.Model;
using System.Collections.Generic;
using FluentAssertions;

namespace BookApiTest
{
    public class TestBookServicce
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
            var testList = bookService.GetBooks();

            //Assert
            testList.Should().BeEquivalentTo(compareList);
        }

        [Fact]
        public void Test_Get_Book_By_Id()
        {
            //Arrange
            
            BookService bookService = new BookService();
            Book testBook = new Book() { Title = "The BFG", Author = "Roahld Dahl", Category = "Children", Id = 4, Price = 870 };

            //Act
            var result =  bookService.GetBookById(4);
            var expected = $"Title: {testBook.Title}\nAuthor: {testBook.Author}\nCategory: {testBook.Category}\nPrice: {testBook.Price}\nId:{testBook.Id}";
            //Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Test_Add_Book()
        {
            //Arrange
            BookService bookService = new BookService();
            Book testBook = new Book() { Title = "Wavelets", Author = "Jaidev", Category = "Education", Price = 200 };

            //Act
            var result = bookService.AddBook(testBook);
            var expected = $"Succesfully added:\nTitle: {testBook.Title}\nAuthor: {testBook.Author}\nCategory: {testBook.Category}\nPrice: {testBook.Price}\nId:{testBook.Id}";
            //Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Test_Update_Book()
        {
            //Arrange
            BookService bookService = new BookService();
            Book testBook = new Book() { Title = "Wavelets", Author = "Jaidev", Id = 3, Category = "Education", Price = 200 };
            int id = 3;

            //Act
            var result = bookService.UpdateBookDetails(id,testBook);
            var expected = $"Book updated successfully:\nTitle: {testBook.Title}\nAuthor: {testBook.Author}\nCategory: {testBook.Category}\nPrice: {testBook.Price}\nId:{testBook.Id}";
            //Assert
            result.Should().BeEquivalentTo(expected);
        }

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
