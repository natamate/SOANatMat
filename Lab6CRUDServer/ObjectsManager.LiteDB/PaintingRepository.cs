using ObjectsManager.Interfaces;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using ObjectsManager.LiteDB.Model;
using ObjectsManager.Model;

namespace ObjectsManager.LiteDB
{
    public class PaintingRepository : IPaintingsRepository
    {
        private readonly string _paintingConnection = DatabaseConnection.PaintingConnection;

        List<Painting> IPaintingsRepository.GetAll()
        {
            using (var db = new LiteDatabase(this._paintingConnection))
            {
                var repository = db.GetCollection<PaintingDB>("painting");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        Painting IPaintingsRepository.Get(int id)
        {
            using (var db = new LiteDatabase(this._paintingConnection))
            {
                var repository = db.GetCollection<PaintingDB>("painting");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Painting Update(Painting painting)
        {
            using (var db = new LiteDatabase(this._paintingConnection))
            {
                var dbObject = InverseMap(painting);

                var repository = db.GetCollection<PaintingDB>("painting");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public int Add(Painting painting)
        {
            using (var db = new LiteDatabase(this._paintingConnection))
            {
                var dbObject = InverseMap(painting);

                var repository = db.GetCollection<PaintingDB>("painting");
                if (repository.FindById(painting.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._paintingConnection))
            {
                var repository = db.GetCollection<PaintingDB>("painting");
                return repository.Delete(id);
            }
        }

        internal Painting Map(PaintingDB dbPainting)
        {
            if (dbPainting == null)
                return null;
            return new Painting() { Id = dbPainting.Id, Title = dbPainting.Title, Year = dbPainting.Year };
        }

        internal PaintingDB InverseMap(Painting painting)
        {
            if (painting == null)
                return null;
            return new PaintingDB() { Id = painting.Id, Title = painting.Title, Year = painting.Year };
        }

    }
}
