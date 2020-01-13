#define MyDebug
using System;
using System.Collections.Generic;

namespace WebApiTraining.Model
{
    public class BookData
    {
        private static readonly List<Book> _books = new List<Book>();
        private static int _idCounter = 0;
        private const int _defaultMinimumPrice = 200;

        public BookData()
        {
#if MyDebug
            _books.Add(new Book { Title = "Fundamentals of Wavelets", Author = "Jaideva Goswami", Category = "Education", Id = ++_idCounter, Price = 200 });
            _books.Add(new Book { Title = "Let us C", Author = "Yashavant Kanetkar", Category = "Education", Id = ++_idCounter, Price = 500 });
            _books.Add(new Book { Title = "1984", Author = "George Orwell", Category = "Dystopian", Id = ++_idCounter, Price = 2000 });
            _books.Add(new Book { Title = "The BFG", Author = "Roahld Dahl", Category = "Children", Id = ++_idCounter, Price = 870 });
#endif
        }

        public List<Book> GetBooks()
        {
            return _books;
        }

        public bool AddBook(Book newBook)
        {
            
            if (newBook != null)
            {
                newBook = AddMissingBookDetails(newBook);
                _books.Add(newBook);
                return true;
            }
            else
            {
                return false;
            }
                            
        }

        internal void UpdateBookDetails(int id, Book updateBook)
        {
            var book = GetBookById(id);

            if (updateBook.Title != null)
                book.Title = updateBook.Title;

            if (updateBook.Category != null)
                book.Category = updateBook.Category;

            if (updateBook.Author != null)
                book.Author = updateBook.Author;
                    
            if(updateBook.Price > 0)
                book.Price = updateBook.Price;
        }

        internal Book GetBookByTitle(string title)
        {
            return _books.Find(book => book.Title.StartsWith(title));
        }

        internal bool DeleteBookById(int id)
        { 
            return _books.Remove(GetBookById(id));
        }

        private Book AddMissingBookDetails(Book newBook)
        {
            if (newBook.Author == null)
                newBook.Author = "Unknown Author";

            if (newBook.Price == 0)
                newBook.Price = _defaultMinimumPrice;

            if (newBook.Category == null)
                newBook.Category = "Unknown Category";

            newBook.Id = ++_idCounter;

            return newBook;
        }

        public Book GetBookById(int id)
        {
            Book foundBook = _books.Find(book => book.Id == id);
            if (foundBook != null)
                return foundBook;
            else
                return null;
        }
    }
}
