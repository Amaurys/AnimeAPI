namespace AnimeAPI.Models
{
    public class Anime
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public bool IsActive { get; set; }
    }
}