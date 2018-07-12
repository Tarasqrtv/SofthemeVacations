using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Vacations.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public class Book
        {
            public string id;
            public string title;
            public string author;
            public bool isFavorite;
            public string imageUrl;
            public int price;
        }

        public Book[] books = new Book[] {
            new Book()
            {
                id = "1",
                title = "The Universe in a Nutshell",
                author = "Stephen Hawkin",
                isFavorite = true,
                imageUrl = "assets/images/1.jpg",
                price = 50
            },
            new Book()
            {
                id = "2",
                title = "JavaScript Patterns",
                author = "Stoyan Stefanov",
                isFavorite = true,
                imageUrl = "assets/images/2.jpg",
                price = 38
            },

            new Book()
            {
                id = "3",
                title = "Angular: Up and Running: Learning Angular, Step by Step",
                author = "Shyam Seshadri",
                isFavorite = false,
                imageUrl = "assets/images/3.jpg",
                price = 47
            },
        };
        // GET api/values
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return books[id];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
