using System.Collections.Generic;
using System.ServiceModel;
using ObjectsManager.Model;
using ObjectsManagerInterface;
using ObjectsManager.LiteDB;

namespace MzlLab3Server
{
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
        public class ObjectsService : IObjectsService
        {

            private readonly IPersonRepository _personRepository;
            private readonly IMovieRepository _movieRepository;
            private readonly IReviewRepository _reviewRepository;

            public ObjectsService()
            {
                this._personRepository = new PersonRepository();
                this._movieRepository = new MovieRepository();
                this._reviewRepository = new ReviewRepository();
            }

            public int AddMovie(Movie movie)
            {
                return this._movieRepository.Add(movie);
            }

            public Movie GetMovie(int id)
            {
                return this._movieRepository.Get(id);
            }

            public List<Movie> GetAllMovies()
            {
                return this._movieRepository.GetAll();
            }

            public Movie UpdateMovie(Movie movie)
            {
                return this._movieRepository.Update(movie);
            }

            public bool DeleteMovie(int id)
            {
                return this._movieRepository.Delete(id);
            }

            public int AddPerson(Person person)
            {
                return this._personRepository.Add(person);
            }

            public Person GetPerson(int id)
            {
                return this._personRepository.Get(id);
            }

            public List<Person> GetAllPersons()
            {
                return this._personRepository.GetAll();
            }

            public Person UpdatePerson(Person person)
            {
                return this._personRepository.Update(person);
            }

            public bool DeletePerson(int id)
            {
                return this._personRepository.Delete(id);
            }

            public int AddReview(Review review)
            {
                return this._reviewRepository.Add(review);
            }

            public Review GetReview(int id)
            {
                return this._reviewRepository.Get(id);
            }

            public List<Review> GetAllReviews(Person p)
            {
                return this._reviewRepository.GetAll(p);
            }

            public List<Review> GetAllReviewsForMovie(Movie m)
            {
                return this._reviewRepository.GetAll(m);
            }


            public Review UpdateReview(Review review)
            {
                return this._reviewRepository.Update(review);
            }

            public bool DeleteReview(int id)
            {
                return this._reviewRepository.Delete(id);
            }
        }
    }

