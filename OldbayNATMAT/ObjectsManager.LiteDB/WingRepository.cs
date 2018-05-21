using System.Collections.Generic;
using System.Linq;
using LiteDB;
using ObjectsManager.LiteDB.Model;
using ObjectsManager.Interfaces;
using ObjectsManager.Model;

namespace ObjectsManager.LiteDB
{
    public class WingRepository: IWingRepository
    {
        private readonly string _wingConnection = DatabaseConnection.WingConnection;

        public List<Wing> GetAllWings()
        {
            using (var db = new LiteDatabase(this._wingConnection))
            {
                var repository = db.GetCollection<WingDB>("wings");
                var results = repository.FindAll();
                return results.Select(x => Map(x)).ToList();
            }
        }

        public Wing Get(string name)
        {
            using (var db = new LiteDatabase(this._wingConnection))
            {
                var repository = db.GetCollection<WingDB>("wings");
                var results = repository.FindAll();
                foreach (var wingDb in results)
                {
                    if (wingDb.Name == name)
                        return Map(wingDb);
                }

                return null;
            }
        }

        public Wing Get(int id)
        {
            using (var db = new LiteDatabase(this._wingConnection))
            {
                var repository = db.GetCollection<WingDB>("wings");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Wing Update(Wing wing)
        {
            using (var db = new LiteDatabase(this._wingConnection))
            {
                var dbObject = InverseMap(wing);

                var repository = db.GetCollection<WingDB>("wings");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._wingConnection))
            {
                var repository = db.GetCollection<WingDB>("wings");
                return repository.Delete(id);
            }
        }

        public int Add(Wing wing)
        {
            using (var db = new LiteDatabase(this._wingConnection))
            {
                var dbObject = InverseMap(wing);

                var repository = db.GetCollection<WingDB>("wings");
                if (repository.FindById(wing.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        internal Wing Map(WingDB dbWing)
        {
            if (dbWing == null)
                return null;
            return new Wing() { Id = dbWing.Id,
                Power = dbWing.Power, Shield = dbWing.Shield, Name = dbWing.Name };
        }

        internal WingDB InverseMap(Wing wing)
        {
            if (wing == null)
                return null;
            return new WingDB() { Id = wing.Id, Power = wing.Power,
                Shield = wing.Shield, Name = wing.Name };
        }

    }
}
