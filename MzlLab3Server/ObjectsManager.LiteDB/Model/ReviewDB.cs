namespace ObjectsManager.LiteDB.Model
{
    public class ReviewDB
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public PersonDB Author { get; set; }
        public int MovieId { get; set; }
    }
}
