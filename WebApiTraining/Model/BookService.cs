using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTraining.Model
{
    public class BookService
    {
        private static readonly BookData _bookData = new BookData();
        private readonly List<ErrorModel> _errors = new List<ErrorModel>();

       
        public BookResponseModel GetBooks()
        {
            _errors.Clear();
            var Books = _bookData.GetBooks();
            if (Books != null)
            {
                return new BookResponseModel(Books, null);
            }
            else
                return new BookResponseModel(null, new ErrorModel(101, ErrorMessage.BookNotFound));
        }

        public BookResponseModel GetBookById(int id)
        {
            _errors.Clear();
            if (!Validate.IsPositiveInt(id))
            {
                return new BookResponseModel(null, new List<ErrorModel>() { new ErrorModel(102, ErrorMessage.InvalidId) });
            }

            Book foundBook = _bookData.GetBookById(id);


            if (foundBook != null)
            {
                return new BookResponseModel(foundBook, null);
            }
            return new BookResponseModel(null, new List<ErrorModel>() { new ErrorModel(101, ErrorMessage.BookNotFound) });
        }

        public BookResponseModel AddBook(Book newBook)
        {
            _errors.Clear();
            if (ValidateBookDetails(newBook) && !(newBook.Title == null))
            {
                _bookData.AddBook(newBook);
                return new BookResponseModel(GetBookById(newBook.Id).Book,null);
            }
            else
            {
                if (newBook.Title == null)
                {
                    _errors.Add(new ErrorModel(103, ErrorMessage.MissingTitle));
                }
                return new BookResponseModel(null, _errors);
            }
        }

        public BookResponseModel UpdateBookDetails(int id, Book updateBook)
        {
            _errors.Clear();
            if (GetBookById(id).Book != null)
            {
                if (ValidateBookDetails(updateBook))
                {
                    _bookData.UpdateBookDetails(id, updateBook);
                    return new BookResponseModel(GetBookById(id).Book, null);
                }
                else
                    return new BookResponseModel(null, _errors);
            }
            else
            {
                return new BookResponseModel(null, new ErrorModel(101, ErrorMessage.BookNotFound));
            }
        }

        public bool DeleteBookById(int id)
        {
            return _bookData.DeleteBookById(id);
        }

        private bool ValidateBookDetails(Book book)
        {
            bool valid = true;

            if (book.Title!=null)
            {
                if (Validate.IsBlankOrWhiteSpace(book.Title))
                {
                    _errors.Add(new ErrorModel(103, ErrorMessage.MissingTitle));
                    valid = false;
                }
            }
            if (book.Author != null)
            {
                if (Validate.ContainsNumbers(book.Author) || Validate.IsBlankOrWhiteSpace(book.Author))
                {
                    _errors.Add(new ErrorModel(104,ErrorMessage.AuthorNameViolation));
                    valid = false;
                }
            }

            if (book.Category != null)
            {
                if (Validate.ContainsNumbers(book.Category) || Validate.IsBlankOrWhiteSpace(book.Category))
                {
                    _errors.Add(new ErrorModel(105, ErrorMessage.CategoryNameViolation));
                    valid = false;
                }
            }

            if (!Validate.IsPositiveInt(book.Price))
            {
                _errors.Add(new ErrorModel(106, ErrorMessage.InvalidPrice));
                valid = false;
            }

            return valid;
        }
    }
}
