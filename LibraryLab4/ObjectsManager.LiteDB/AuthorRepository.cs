using System.Collections.Generic;
using System.Linq;
using LiteDB;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDB.Model;
using ObjectsManager.Model;

namespace ObjectsManager.LiteDB
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly string _authorConnection = DatabaseConnection.AuthorConnection;
        public List<Author> GetAll()
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var repository = db.GetCollection<AuthorDB>("authors");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Author author)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var dbObject = InverseMap(author);

                var repository = db.GetCollection<AuthorDB>("authors");
                if (repository.FindById(author.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Author Get(int id)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var repository = db.GetCollection<AuthorDB>("authors");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Author Update(Author author)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var dbObject = InverseMap(author);

                var repository = db.GetCollection<AuthorDB>("authors");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var repository = db.GetCollection<AuthorDB>("authors");
                return repository.Delete(id);
            }
        }

        internal List<AuthorDB> GetAuthors(int[] ids)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var repository = db.GetCollection<AuthorDB>("authors");
                var results = repository.FindAll().Where(x => ids.Contains(x.Id));

                return results.ToList();
            }
        }

        internal Author Map(AuthorDB dbAuthor)
        {
            if (dbAuthor == null)
                return null;
            return new Author() { Id = dbAuthor.Id, AuthorName = dbAuthor.AuthorName, AuthorSurname = dbAuthor.AuthorSurname };
        }

        internal AuthorDB InverseMap(Author author)
        {
            if (author == null)
                return null;
            return new AuthorDB() { Id = author.Id, AuthorName = author.AuthorName, AuthorSurname = author.AuthorSurname };
        }
    }
}
