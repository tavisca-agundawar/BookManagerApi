#define MyDebug
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTraining.Model
{
    public class BookData
    {
        private static readonly List<Book> _books = new List<Book>();
        private static int _idCounter = 0;
        //private static int _untitledCounter = 0;
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

        public bool AddBook(Book newBook, out string result)
        {
            bool valid = ValidateTitle(newBook, out string validationResult);
            if (!valid)
            {
                result = validationResult;
                return false;
            }

            valid = ValidateBookDetails(newBook, out validationResult);

            if (!valid)
            {
                result = validationResult;
                return false;
            }

            newBook = AddMissingBookDetails(newBook);
            result = "Succesfully added:\n";

            if (newBook != null)
            {
                _books.Add(newBook);
                return true;
            }
            else
            {
                result = "No book entered";
                return false;
            }
                            
        }

        private bool ValidateTitle(Book book, out string validationResult)
        {
            validationResult = "";
            if (book.Title == null || book.Title.All(char.IsWhiteSpace) || book.Title == "")
            {
                validationResult = ErrorMessage.MissingTitle;
                return false;
            }
            else
                return true;
        }

        internal bool UpdateBookDetails(int id, Book updateBook, out string result)
        {
            var book = GetBookById(id);
            bool valid = ValidateBookDetails(updateBook, out string validationResult);

            if (!valid)
            {
                result = validationResult;
                return false;
            }

            if (book != null)
            {
                if (updateBook.Title != null)
                    book.Title = updateBook.Title;

                if (updateBook.Category != null)
                    book.Category = updateBook.Category;

                if (updateBook.Author != null)
                    book.Author = updateBook.Author;
                    
                if(updateBook.Price > 0)
                    book.Price = updateBook.Price;

                result = "Book updated successfully:\n";
                if (updateBook.Id != book.Id && updateBook.Id != 0)
                    result += "Id is auto assigned and cannot be updated.\n";
                return true;
            }
            else
            {
                result = ErrorMessage.BookNotFound;
                return false;
            }
                
        }

        private bool ValidateBookDetails(Book book, out string validationResult)
        {
            validationResult = "";

            if (book.Author != null)
            {
                if (Validate.ContainsNumbers(book.Author))
                {
                    validationResult = ErrorMessage.AuthorNameViolation;
                    return false;
                }
            }

            if (book.Category != null)
            {
                if (Validate.ContainsNumbers(book.Category))
                {
                    validationResult = ErrorMessage.CategoryNameViolation;
                    return false;
                }
            }

            if (!Validate.IsPositiveInt(book.Price))
            {
                validationResult = ErrorMessage.InvalidPrice;
                return false;
            }

            return true;
        }

        internal void DeleteBookById(int id, out bool response)
        {

            response =_books.Remove(GetBookById(id));
        }

        private Book AddMissingBookDetails(Book newBook)
        {
            //if(newBook.Title == null)
            //    newBook.Title = "Untitled Book " + ++_untitledCounter;

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
