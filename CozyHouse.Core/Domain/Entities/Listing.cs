namespace CozyHouse.Core.Domain.Entities
{
    public class Listing
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Topic { get; set; }
    }
}
