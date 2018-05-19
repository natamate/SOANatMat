using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using ObjectsManager.Interfaces;
using ObjectsManager.Model;

namespace WebApplicationLab6.DAL
{
    public class ArtistRepositoryPostgreSQL : IArtistRepository
    {
        private MuseumContext db = new MuseumContext();

        public List<Artist> GetAll()
        {
            return db.Artists.ToList();
        }

        public int Add(Artist artist)
        {
            db.Artists.Add(artist);
            db.SaveChanges();
            return artist.Id;
        }

        public Artist Get(int id)
        {
            return db.Artists.Find(id);
        }

        public Artist Update(Artist artist)
        {
            db.Entry(artist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(artist.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return artist;
        }

        public bool Delete(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return false;
            }

            db.Artists.Remove(artist);
            db.SaveChanges();
            return true;
        }

        private bool ArtistExists(int id)
        {
            return db.Artists.Count(e => e.Id == id) > 0;
        }
    }
}