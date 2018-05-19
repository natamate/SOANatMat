using System.Collections.Generic;
using System.Linq;
using LiteDB;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDB.Model;
using ObjectsManager.Model;

namespace ObjectsManager.LiteDB
{
    public class ArtistRepository:IArtistRepository
    {
        private readonly string _artistConnection = DatabaseConnection.ArtistConnection;

        public int Add(Artist artist)
        {
            using (var db = new LiteDatabase(this._artistConnection))
            {
                var dbObject = InverseMap(artist);

                var repository = db.GetCollection<ArtistDB>("artist");
                if (repository.FindById(artist.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Artist Get(int id)
        {
            using (var db = new LiteDatabase(this._artistConnection))
            {
                var repository = db.GetCollection<ArtistDB>("artist");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Artist Update(Artist artist)
        {
            using (var db = new LiteDatabase(this._artistConnection))
            {
                var dbObject = InverseMap(artist);

                var repository = db.GetCollection<ArtistDB>("artist");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public List<Artist> GetAll()
        {
            using (var db = new LiteDatabase(this._artistConnection))
            {
                var repository = db.GetCollection<ArtistDB>("artist");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }
        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._artistConnection))
            {
                var repository = db.GetCollection<ArtistDB>("artist");
                return repository.Delete(id);
            }
        }

        internal Artist Map(ArtistDB dbArtist)
        {
            if (dbArtist == null)
                return null;
            return new Artist() { Id = dbArtist.Id, ArtistName = dbArtist.ArtistName, ArtistSurname = dbArtist.ArtistSurname };
        }

        internal ArtistDB InverseMap(Artist artist)
        {
            if (artist == null)
                return null;
            return new ArtistDB() { Id = artist.Id, ArtistName = artist.ArtistName, ArtistSurname = artist.ArtistSurname };
        }
    }
}
