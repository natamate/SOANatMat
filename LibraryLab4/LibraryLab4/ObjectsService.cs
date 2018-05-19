using System.Collections.Generic;
using System.ServiceModel;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDB;
using ObjectsManager.Model;

namespace LibraryLab4
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ObjectsService : IObjectsService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public ObjectsService()
        {
            this._authorRepository = new AuthorRepository();
            this._bookRepository = new BookRepository();
        }


        public int AddBook(Book books)
        {
            return this._bookRepository.Add(books);
        }

        public Book GetBook(int id)
        {
            return this._bookRepository.Get(id);
        }

        public List<Book> GetAllBooks()
        {
            return this._bookRepository.GetAll();
        }

        public Book UpdateBook(Book book)
        {
            return this._bookRepository.Update(book);
        }

        public bool DeleteBook(int id)
        {
            return this._bookRepository.Delete(id);
        }

        public int AddAuthor(ObjectsManager.Model.Author author)
        {
            return this._authorRepository.Add(author);
        }

        public ObjectsManager.Model.Author GetAuthor(int id)
        {
            return this._authorRepository.Get(id);
        }

        public List<ObjectsManager.Model.Author> GetAllAuthors()
        {
            return this._authorRepository.GetAll();
        }

        public ObjectsManager.Model.Author UpdateAuthor(ObjectsManager.Model.Author author)
        {
            return this._authorRepository.Update(author);
        }

        //public bool DeleteAuthor(int id)
        //{
        //    return this._authorRepository.Delete(id);
        //}
    }
}
