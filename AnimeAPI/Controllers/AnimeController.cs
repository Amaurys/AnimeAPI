using AnimeAPI.Models;
using AnimeAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeService _animeService;

        public AnimeController(IAnimeService animeService)
        {
            _animeService = animeService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] bool? IsActive = null, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(_animeService.GetAllAnimes(IsActive, page, pageSize));
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public IActionResult Get(Guid id)
        {
            var anime = _animeService.GetAnimeById(id);
            if (anime == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(anime);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(AddUpdateAnime animeObject)
        {
            var anime = _animeService.AddAnime(animeObject);

            if (anime == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Anime created successfully.",
                id = anime.Id
            });
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public IActionResult Put([FromRoute] Guid id, [FromBody] AddUpdateAnime animeObj)
        {
            var anime = _animeService.UpdateAnime(id, animeObj);
            if (anime == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Anime updated successfully.",
                id = anime.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var anime = _animeService.DeleteAnime(id);
            if (anime == false)
            {
                return BadRequest(new
                {
                    message = "Anime couldn't be deleted."
                });
            }
            return Ok(new
            {
                message = "Anime deleted successfully."
            });
        }
    }
}