namespace AnimeAPI.Models
{
    public class AddUpdateAnime
    {
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public bool IsActive { get; set; }
    }
}