using System.Collections.Generic;
using System.Web.Http;
using ObjectsManager.Model;
using WebApplicationLab4.Models;
using WebApplicationLab4.ServiceReference1;

//@Path /api/Author
namespace WebApplicationLab4.Controllers
{
    public class AuthorController : ApiController
    {
        ObjectsServiceClient client = new ObjectsServiceClient();
        // GET api/values
        public IEnumerable<Author> Get()
        {
            return client.GetAllAuthors();
        }

        // GET api/values/5
        public Author Get(int id)
        {
            return client.GetAuthor(id);
        }

        // POST api/values
        public int Post([FromBody]AuthorModel author)
        {
            Author newAuthor = new Author()
            {
                Id = author.Id,
                AuthorName = author.AuthorName,
                AuthorSurname = author.AuthorSurname
            };
            return client.AddAuthor(newAuthor);
        }

        // PUT api/values/id
        public void Put(int id, [FromBody]AuthorModel author)
        {
            client.UpdateAuthor(new Author
            {
                Id = id,
                AuthorName = author.AuthorName,
                AuthorSurname = author.AuthorSurname
            });
        }
    }
}
