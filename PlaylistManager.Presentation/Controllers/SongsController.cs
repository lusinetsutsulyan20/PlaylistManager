using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Service.Interfaces;
using PlaylistManager.Shared;
using System.Threading.Tasks;

namespace PlaylistManager.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var songs = await _songService.GetAllAsync();
            return Ok(songs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);
            if (song == null) return NotFound();
            return Ok(song);
        }

        [HttpGet("by-artist/{artist}")]
        public async Task<IActionResult> GetByArtist(string artist)
        {
            var songs = await _songService.GetSongsByArtistAsync(artist);
            return Ok(songs);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SongCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var song = new Song
            {
                Title = dto.Title,
                Artist = dto.Artist
            };

            await _songService.AddSongAsync(song);
            return CreatedAtAction(nameof(GetById), new { id = song.Id }, song);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SongUpdateDto dto)
        {
            var song = await _songService.GetSongByIdAsync(id);
            if (song == null) return NotFound();

            song.Title = dto.Title;
            song.Artist = dto.Artist;

            await _songService.UpdateSongAsync(song);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _songService.DeleteSongAsync(id);
            return NoContent();
        }
    }
}
