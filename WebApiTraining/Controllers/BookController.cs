﻿using System;
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
        public ActionResult<IEnumerable<Book>> Get()
        {
            return Ok(_bookService.GetBooks().Books);
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Book> Get(int id)
        {
            var result = _bookService.GetBookById(id);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                return Ok(result.Book);
            }
            
        }

        // POST: api/Book
        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book newBook)
        {
            var result = _bookService.AddBook(newBook);
            if (result.Errors != null)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                return Ok(result.Book);
            }
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public ActionResult<Book> Put(int id, [FromBody] Book updateBook)
        {
            var response = _bookService.UpdateBookDetails(id, updateBook);

            if (response.Errors != null)
            {
                return BadRequest(response.Errors);
            }
            else
            {
                return Ok(response.Book);
            }
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_bookService.DeleteBookById(id))
            {
                return Ok("Deleted Successfully!");
            }
            else
            {
                return StatusCode(500,"Id not found!");
            }
            
        }
    }
}
