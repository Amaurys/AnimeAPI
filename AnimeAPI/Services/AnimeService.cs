using AnimeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAPI.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly List<Anime> _animeList;

        public AnimeService()
        {
            _animeList =
            [
                new Anime()
                {
                    Id = Guid.NewGuid(),
                    Name = "Naruto",
                    Description = "Naruto is a Japanese manga series written and illustrated by Masashi Kishimoto. It tells the story of Naruto Uzumaki, a young ninja who seeks recognition from his peers and dreams of becoming the Hokage, the leader of his village.",
                    ReleaseDate = DateTime.Parse("2002/10/03"),
                    IsActive = true
                }
            ];
        }

        public Anime AddAnime(AddUpdateAnime anime)
        {
            var Addanime = new Anime()
            {
                Id = Guid.NewGuid(),
                Name = anime.Name,
                Description = anime.Description,
                ReleaseDate = anime.ReleaseDate,
                IsActive = true
            };

            _animeList.Add(Addanime);

            return Addanime;
        }

        public bool DeleteAnime(Guid AnimeId)
        {
            var animeIndex = _animeList.FindIndex(a => a.Id == AnimeId);
            if (animeIndex > 0)
            {
                var anime = _animeList[animeIndex];

                anime.IsActive = false;

                _animeList[animeIndex] = anime;

                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Anime> GetAllAnimes(bool? IsActive, int page, int pageSize)
        {
            var query = _animeList.AsQueryable();

            if(IsActive.HasValue)
            {
                query = query.Where(a => a.IsActive == IsActive.Value);
            }

            return query.Skip((page -1) * pageSize).Take(pageSize).ToList();
        }

        public Anime GetAnimeById(Guid AnimeId)
        {
            var anime = _animeList.FirstOrDefault(a => a.Id == AnimeId);
            return anime ?? throw new KeyNotFoundException($"No se encontró un anime con el ID: {AnimeId}");
        }

        public Anime? UpdateAnime(Guid id, AddUpdateAnime Obj)
        {
            var animeIndex = _animeList.FindIndex(a => a.Id == id);
            if (animeIndex > 0)
            {
                var anime = _animeList[animeIndex];

                anime.Name = Obj.Name;
                anime.Description = Obj.Description;
                anime.ReleaseDate = Obj.ReleaseDate;
                anime.IsActive = Obj.IsActive;

                _animeList[animeIndex] = anime;

                return anime;
            }
            else
            {
                return null;
            }
        }
    }
}