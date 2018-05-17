using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ObjectsManager.LiteDB.Model;
using ObjectsManager.Model;
using ObjectsManagerInterface;

namespace ObjectsManager.LiteDB
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly string _reviewConnection = DatabaseConnections.ReviewConnection;

        public int Add(Review review)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var dbObject = InverseMap(review);

                var repository = db.GetCollection<ReviewDB>("reviews");
                repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Review Update(Review review)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var dbObject = InverseMap(review);

                var repository = db.GetCollection<ReviewDB>("reviews");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");
                return repository.Delete(id);
            }
        }

        Review IReviewRepository.Get(int id)
        {
            throw new NotImplementedException();
        }

        List<Review> IReviewRepository.GetAll(Person person)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");
                var results = repository.FindAll();
                PersonDB dbPerson = Map(person);
                List <ReviewDB> reviews = results.ToList();
                foreach (var review in reviews)
                {
                    if (review.Author != dbPerson)
                    {
                        reviews.Remove(review);
                    }
                }

                return reviews.Select(x => Map(x)).ToList();
            }
        }

        List<Review> IReviewRepository.GetAll(Movie movie)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviews");
                var results = repository.FindAll();
                List<ReviewDB> reviews = results.ToList();
                foreach (var review in reviews)
                {
                    if (review.MovieId != movie.Id)
                    {
                        reviews.Remove(review);
                    }
                }

                return reviews.Select(x => Map(x)).ToList();
            }
        }

        private ReviewDB InverseMap(Review review)
        {
            if (review == null)
                return null;

            return new ReviewDB()
            {
                Id = review.Id,
                Content = review.Content,
                Author = Map(review.Author),
                Score = review.Score,
                MovieId = review.MovieId
            };
        }

        private PersonDB Map(Person person)
        {
            return new PersonDB() {Name = person.Name, Id = person.Id, Surname = person.Surname};
        }

        private Person Map(PersonDB dbPerson)
        {
            return new Person() { Name = dbPerson.Name, Id = dbPerson.Id, Surname = dbPerson.Surname };
        }

        private Review Map(ReviewDB dbReview)
        {
            if (dbReview == null)
                return null;
            return new Review()
            {
                Id = dbReview.Id, Content = dbReview.Content, Author = Map(dbReview.Author),
                MovieId = dbReview.MovieId, Score = dbReview.Score
            };
        }
    }

}
