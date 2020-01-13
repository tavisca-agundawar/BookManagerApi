using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTraining.Model
{
    public class BookResponseModel
    {
        public Book Book { get; private set; } = null;
        public List<Book> Books { get; private set; } = null;
        public List<ErrorModel> Errors { get; private set; } = null;

        public BookResponseModel(Book responseBook, List<ErrorModel> errors)
        {
            Book = responseBook;
            Errors = errors;
        }

        public BookResponseModel(List<Book> responseBooks, ErrorModel error)
        {
            Books = responseBooks;
            if (error!=null)
            {
                Errors = new List<ErrorModel>
                {
                    error
                };
            }
            
        }

    }
}
