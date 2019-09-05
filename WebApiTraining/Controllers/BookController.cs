using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTraining.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApiTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static BookService _bookService = new BookService();

        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookService.GetBooks();
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return _bookService.GetBookById(id);
        }

        // POST: api/Book
        [HttpPost]
        public string Post([FromBody] Book newBook)
        {
            return _bookService.AddBook(newBook);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Book updateBook)
        {
            return _bookService.UpdateBookDetails(id, updateBook);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _bookService.DeleteBookById(id).ToString();
        }
    }
}
