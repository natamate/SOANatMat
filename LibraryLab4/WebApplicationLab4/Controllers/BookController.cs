using ObjectsManager.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApplicationLab4.Models;
using WebApplicationLab4.ServiceReference1;
using WebGrease.Css.Extensions;

//@Path= /api/Book/

namespace WebApplicationLab4.Controllers
{
    public class BookController : ApiController
    {
        ObjectsServiceClient client = new ObjectsServiceClient();
        // GET api/values
        public IEnumerable<Book> Get()
        {
            return client.GetAllBooks();
        }

        // GET api/values/5
        public Book Get(int id)
        {
            return client.GetBook(id);
        }

        //@Path= /api/Book?search=searchString
        // GET api/values
        public IEnumerable<Book> Get(string search)
        {
            Book[] books = client.GetAllBooks();
            List<Book> booksWithPartialTitle = new List<Book>();
            foreach (var book in books)
            {
                if (book.BookTitle != null &&
                book.BookTitle.Contains(search))
                {
                    booksWithPartialTitle.Add(book);
                }
            }

            return booksWithPartialTitle;
        }

        // POST api/values
        public int Post([FromBody] BookModel book)
        {

        Book newBook = new Book();
            newBook.BookTitle = book.BookTitle;
            newBook.ISBN = book.ISBN;
            newBook.Id = book.Id;
            return client.AddBook(newBook);
        }
    
        // PUT api/values/id
        public void Put(int id, [FromBody]BookModel book)
        {
            client.UpdateBook(new Book
            {
                Id = id,
                BookTitle = book.BookTitle,
                ISBN = book.ISBN
            });
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            client.DeleteBook(id);
        }
    }
}
