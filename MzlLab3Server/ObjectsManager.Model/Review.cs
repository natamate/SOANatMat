namespace ObjectsManager.Model
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public Person Author { get; set; }
        public int MovieId { get; set; }
    }
}
