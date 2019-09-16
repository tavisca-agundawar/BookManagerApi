using System;
using System.Collections.Generic;
using System.IO;
using log4net;

namespace WebApiTraining.Model
{
    public class BookService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BookService));
        private static readonly BookData _bookData = new BookData();
        private readonly List<ErrorModel> _errors = new List<ErrorModel>();
        
        public BookResponseModel GetBooks()
        {
            _errors.Clear();
            var Books = _bookData.GetBooks();
            if (Books != null)
            {
                log.DebugFormat("Returned book list", Books.ToString());
                return new BookResponseModel(Books, null);
            }
            else
            {
                var error = new ErrorModel(101, ErrorMessage.BookNotFound);
                log.ErrorFormat("Error retrieving list", error);
                return new BookResponseModel(null, error);
            }
                
        }

        public BookResponseModel GetBookById(int id)
        {
            _errors.Clear();
            if (!Validate.IsPositiveInt(id))
            {
                log.ErrorFormat("Invalid Id encountered", id);
                return new BookResponseModel(null, new List<ErrorModel>() { new ErrorModel(102, ErrorMessage.InvalidId) });
            }

            Book foundBook = _bookData.GetBookById(id);


            if (foundBook != null)
            {
                log.DebugFormat("Book found", foundBook);
                return new BookResponseModel(foundBook, null);
            }
            log.ErrorFormat("Book not found!", id);
            return new BookResponseModel(null, new List<ErrorModel>() { new ErrorModel(101, ErrorMessage.BookNotFound) });
        }

        public BookResponseModel GetBookByTitle(string title)
        {
            if (title.IsBlankOrWhiteSpace())
            {
                var error = new ErrorModel(103, ErrorMessage.MissingTitle);
                log.Error(error);
                return new BookResponseModel(null, error);
            }
            Book foundBook = _bookData.GetBookByTitle(title);
            if(foundBook != null)
            {
                log.DebugFormat("Book found", foundBook);
                return new BookResponseModel(foundBook, null);
            }
            log.ErrorFormat("Book not found", title);
            return new BookResponseModel(null, new List<ErrorModel>() { new ErrorModel(101, ErrorMessage.BookNotFound) });
        }

        public BookResponseModel AddBook(Book newBook)
        {
            _errors.Clear();
            if (ValidateBookDetails(newBook) && !(newBook.Title == null))
            {
                log.DebugFormat("Book details validated", newBook);
                _bookData.AddBook(newBook);
                return new BookResponseModel(GetBookById(newBook.Id).Book,null);
            }
            else
            {
                if (newBook.Title == null)
                {
                    log.Error("Missing title");
                    _errors.Add(new ErrorModel(103, ErrorMessage.MissingTitle));
                }

                log.ErrorFormat("Error(s) occured", _errors);
                return new BookResponseModel(null, _errors);
            }
        }

        public BookResponseModel UpdateBookDetails(int id, Book updateBook)
        {
            _errors.Clear();
            if (GetBookById(id).Book != null)
            {
                log.DebugFormat("Book to update found", id);

                if (ValidateBookDetails(updateBook))
                {
                    log.DebugFormat("Update details validated", updateBook);
                    _bookData.UpdateBookDetails(id, updateBook);
                    return new BookResponseModel(GetBookById(id).Book, null);
                }
                else
                {
                    log.ErrorFormat("Error(s) occured", _errors);
                    return new BookResponseModel(null, _errors);
                }
            }
            else
            {
                log.ErrorFormat("Book to update not found!", id);
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
