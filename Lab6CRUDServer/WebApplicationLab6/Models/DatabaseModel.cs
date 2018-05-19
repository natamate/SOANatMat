namespace WebApplicationLab6.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public string ArtistSurname { get; set; }
    }

    public class Painting
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
    }
}