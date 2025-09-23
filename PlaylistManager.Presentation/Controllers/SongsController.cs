using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Service.Interfaces;
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
            var songs = await _songService.GetAllAsync(); // Add GetAllAsync in service
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
        public async Task<IActionResult> Create([FromBody] Song song)
        {
            await _songService.AddSongAsync(song);
            return CreatedAtAction(nameof(GetById), new { id = song.Id }, song);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Song song)
        {
            if (id != song.Id) return BadRequest();
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

