using System.Collections.Generic;
using System.Linq;
using LiteDB;
using ObjectsManager.LiteDB.Model;
using ObjectsManager.Model;
using ObjectsManagerInterface;

namespace ObjectsManager.LiteDB
{
    public class MovieRepository : IMovieRepository
    {
        private readonly string _movieConnection = DatabaseConnections.MovieConnection;

        public List<Movie> GetAll()
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var repository = db.GetCollection<MovieDB>("movies");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Movie movie)
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var dbObject = InverseMap(movie);

                var repository = db.GetCollection<MovieDB>("movies");
                if (repository.FindById(movie.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Movie Get(int id)
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var repository = db.GetCollection<MovieDB>("movies");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Movie Update(Movie movie)
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var dbObject = InverseMap(movie);

                var repository = db.GetCollection<MovieDB>("movies");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._movieConnection))
            {
                var repository = db.GetCollection<MovieDB>("movies");
                return repository.Delete(id);
            }
        }

        internal Movie Map(MovieDB dbMovie)
        {
            if (dbMovie == null)
                return null;
            return new Movie() { Id = dbMovie.Id, Title = dbMovie.Title, ReleaseYear = dbMovie.ReleaseYear };
        }

        internal MovieDB InverseMap(Movie movie)
        {
            if (movie == null)
                return null;
            return new MovieDB() { Id = movie.Id, Title = movie.Title, ReleaseYear = movie.ReleaseYear };
        }

    }
}
