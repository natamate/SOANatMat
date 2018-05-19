using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using ObjectsManager.Interfaces;
using ObjectsManager.Model;

namespace WebApplicationLab6.DAL
{
    public class PaintingRepositoryPostgreSQL:IPaintingsRepository
    {
        private MuseumContext db = new MuseumContext();

        public List<Painting> GetAll()
        {
            return db.Paintings.ToList();
        }

        public int Add(Painting painting)
        {
            db.Paintings.Add(painting);
            db.SaveChanges();
            return painting.Id;
        }

        public Painting Get(int id)
        {
            return db.Paintings.Find(id);
        }

        public Painting Update(Painting painting)
        {
            db.Entry(painting).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaintingExists(painting.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return painting;
        }

        public bool Delete(int id)
        {
            Painting painting = db.Paintings.Find(id);
            if (painting == null)
            {
                return false;
            }

            db.Paintings.Remove(painting);
            db.SaveChanges();
            return true;
        }

        private bool PaintingExists(int id)
        {
            return db.Paintings.Count(e => e.Id == id) > 0;
        }
    }
}