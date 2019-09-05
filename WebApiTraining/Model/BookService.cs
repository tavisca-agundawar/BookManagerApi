using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTraining.Model
{
    public class BookService
    {
        private static readonly BookData _bookData = new BookData();

        public IEnumerable<Book> GetBooks()
        {
            return _bookData.GetBooks();
        }

        public string GetBookById(int id)
        {
            if (!Validate.IsPositiveInt(id))
            {
                return ErrorMessage.InvalidId;
            }

            Book foundBook = _bookData.GetBookById(id);

            if (foundBook != null)
            {
                return $"Title: {foundBook.Title}\nAuthor: {foundBook.Author}\nCategory: {foundBook.Category}\nPrice: {foundBook.Price}\nId:{foundBook.Id}";
            }
            return ErrorMessage.BookNotFound;
        }

        public string AddBook(Book newBook)
        {
            try
            {
                if(_bookData.AddBook(newBook,out string result))
                {
                    return result + GetBookById(newBook.Id);
                }
                else
                {
                    return result;
                }
                
            }
            catch (Exception)
            {
                return ErrorMessage.Unknown;
            }
        }

        public string UpdateBookDetails(int id, Book updateBook)
        {
            if (_bookData.UpdateBookDetails(id, updateBook, out string result))
                return result + GetBookById(id);
            else
                return result;
        }

        public bool DeleteBookById(int id)
        {
            _bookData.DeleteBookById(id, out bool response);
            return response;
        }
    }
}
