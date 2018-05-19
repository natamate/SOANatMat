using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObjectsManager.Model;

namespace WebApplicationLab6.DAL
{
    public class MuseumInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MuseumContext>
    {
        protected override void Seed(MuseumContext context)
        {
            var paintings = new List<Painting>
            {
                new Painting() {Title = "Krzyk", Year = 1123},
                new Painting() {Title = "To", Year = 3211}

            };
            paintings.ForEach(i => context.Paintings.Add(i));
            context.SaveChanges();

            var artists = new List<Artist>()
            {
                new Artist() {ArtistName = "AAA", ArtistSurname = "Andrzej"},
                new Artist() {ArtistName = "MaKota", ArtistSurname = "Ala"}
            };
            artists.ForEach(g => context.Artists.Add(g));
            context.SaveChanges();
        }
    }
}