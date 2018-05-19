using System.Collections.Generic;
using System.ServiceModel;
using ObjectsManager.Model;

namespace LibraryLab4
{
    [ServiceContract]
    public interface IObjectsService
    {
        [OperationContract]
        int AddBook(Book books);

        [OperationContract]
        Book GetBook(int id);

        [OperationContract]
        List<Book> GetAllBooks();

        [OperationContract]
        Book UpdateBook(Book book);

        [OperationContract]
        bool DeleteBook(int id);


        [OperationContract]
        int AddAuthor(Author author);

        [OperationContract]
        Author GetAuthor(int id);

        [OperationContract]
        List<Author> GetAllAuthors();

        [OperationContract]
        Author UpdateAuthor(Author author);

        //we don't want to serve delete authors method for client (more logic needed for comics authors changes etc.
        //[OperationContract]
        //bool DeleteAuthor(int id);


    }
}
