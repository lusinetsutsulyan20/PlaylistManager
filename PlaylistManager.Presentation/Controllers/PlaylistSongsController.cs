using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Service.Interfaces;
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
        public async Task<IActionResult> Add([FromBody] PlaylistSong playlistSong)
        {
            await _service.AddPlaylistSongAsync(playlistSong);
            return Ok(playlistSong);
        }
    }
}
