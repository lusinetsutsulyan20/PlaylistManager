using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Service.Interfaces;
using System.Threading.Tasks;

namespace PlaylistManager.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistsController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var playlists = await _playlistService.GetAllAsync(); // Add GetAllAsync in service
            return Ok(playlists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var playlist = await _playlistService.GetPlaylistByIdAsync(id);
            if (playlist == null) return NotFound();
            return Ok(playlist);
        }

        [HttpGet("{id}/with-songs")]
        public async Task<IActionResult> GetWithSongs(int id)
        {
            var playlist = await _playlistService.GetPlaylistWithSongsAsync(id);
            if (playlist == null) return NotFound();
            return Ok(playlist);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Playlist playlist)
        {
            await _playlistService.AddPlaylistAsync(playlist);
            return CreatedAtAction(nameof(GetById), new { id = playlist.Id }, playlist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Playlist playlist)
        {
            if (id != playlist.Id) return BadRequest();
            await _playlistService.UpdatePlaylistAsync(playlist);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _playlistService.DeletePlaylistAsync(id);
            return NoContent();
        }
    }
}
