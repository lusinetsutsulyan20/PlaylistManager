using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Service.Interfaces;
using PlaylistManager.Shared;
using System.Threading.Tasks;

namespace PlaylistManager.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistSongsController : ControllerBase
    {
        private readonly IPlaylistSongService _service;

        public PlaylistSongsController(IPlaylistSongService service)
        {
            _service = service;
        }

        [HttpGet("{playlistId}")]
        public async Task<IActionResult> GetByPlaylist(int playlistId)
        {
            var items = await _service.GetByPlaylistIdAsync(playlistId);
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PlaylistSong dto)
        {
            // Optional: validate PlaylistId and SongId exist before adding
            await _service.AddPlaylistSongAsync(dto);
            return Ok(dto);
        }
    }
}
