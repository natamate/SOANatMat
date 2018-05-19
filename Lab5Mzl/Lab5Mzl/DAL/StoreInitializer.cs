using System.Collections.Generic;
using Lab5Mzl.Models;

namespace Lab5Mzl.DAL
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var books = new List<Book>
            {
                new Book() {BookTitle = "Zielona mila", ISBN = "123"},
                new Book() {BookTitle = "To", ISBN = "321"}

            };
            books.ForEach(i => context.Books.Add(i));
            context.SaveChanges();

            var authors = new List<Author>()
            {
                new Author() {AuthorName = "Andrzej", AuthorSurname = "Andrzej"},
                new Author() {AuthorName = "MaKota", AuthorSurname = "Ala"}
            };
            authors.ForEach(g => context.Authors.Add(g));
            context.SaveChanges();    
        }
    }
}