using AnimeAPI.Models;

namespace AnimeAPI.Services
{
    public interface IAnimeService
    {
        List<Anime> GetAllAnimes(bool? IsActive, int page, int pageSize);
        Anime GetAnimeById(Guid AnimeId);
        Anime AddAnime(AddUpdateAnime Anime);
        Anime? UpdateAnime(Guid id, AddUpdateAnime Obj);
        bool DeleteAnime(Guid AnimeId);
    }
}
