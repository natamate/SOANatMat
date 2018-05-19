using System.Collections.Generic;
using System.Linq;
using LiteDB;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDB.Model;
using ObjectsManager.Model;

namespace ObjectsManager.LiteDB
{
    public class BookRepository : IBookRepository
    {
        private readonly string _bookConnection = DatabaseConnection.BooksConnection;
        public List<Book> GetAll()
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var repository = db.GetCollection<BookDB>("books");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Book book)
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var dbObject = InverseMap(book);

                var repository = db.GetCollection<BookDB>("books");
                if (repository.FindById(book.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Book Get(int id)
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var repository = db.GetCollection<BookDB>("books");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Book Update(Book book)
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var dbObject = InverseMap(book);

                var repository = db.GetCollection<BookDB>("books");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var repository = db.GetCollection<BookDB>("books");
                return repository.Delete(id);
            }
        }

        internal Book Map(BookDB dbBook)
        {
            if (dbBook == null)
                return null;
            return new Book() { Id = dbBook.Id, BookTitle = dbBook.BookTitle, ISBN = dbBook.ISBN };
        }

        internal BookDB InverseMap(Book book)
        {
            if (book == null)
                return null;
            return new BookDB() { Id = book.Id, BookTitle = book.BookTitle, ISBN = book.ISBN };
        }
    }
}
