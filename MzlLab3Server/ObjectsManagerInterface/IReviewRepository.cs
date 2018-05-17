using System.Collections.Generic;
using ObjectsManager.Model;

namespace ObjectsManagerInterface
{
    public interface IReviewRepository
    {
        List<Review> GetAll(Person person);
        List<Review> GetAll(Movie movie);
        int Add(Review review);
        Review Get(int id);
        Review Update(Review review);
        bool Delete(int id);
    }
}
