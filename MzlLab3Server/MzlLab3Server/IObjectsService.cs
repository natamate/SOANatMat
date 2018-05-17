using ObjectsManager.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace MzlLab3Server
{
    [ServiceContract]
    interface IObjectsService
    {
            [OperationContract]
            int AddMovie(Movie movie);

            [OperationContract]
            Movie GetMovie(int id);

            [OperationContract]
            List<Movie> GetAllMovies();

            [OperationContract]
            Movie UpdateMovie(Movie movie);

            [OperationContract]
            bool DeleteMovie(int id);


            [OperationContract]
            int AddPerson(Person person);

            [OperationContract]
            Person GetPerson(int id);

            [OperationContract]
            List<Person> GetAllPersons();

            [OperationContract]
            Person UpdatePerson(Person person);

            [OperationContract]
            bool DeletePerson(int id);

            [OperationContract]
            int AddReview(Review review);

            [OperationContract]
            Review GetReview(int id);

            [OperationContract]
            List<Review> GetAllReviews(Person p);

            [OperationContract]
            List<Review> GetAllReviewsForMovie(Movie m);

            [OperationContract]
            Review UpdateReview(Review review);

            [OperationContract]
            bool DeleteReview(int id);
        }
    
}
