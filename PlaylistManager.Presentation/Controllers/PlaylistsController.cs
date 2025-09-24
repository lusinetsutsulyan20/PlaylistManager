using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Service.Interfaces;
using PlaylistManager.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace PlaylistManager.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;
        private readonly IUserService _userService;
        private readonly ISongService _songService;

        public PlaylistsController(
            IPlaylistService playlistService,
            IUserService userService,
            ISongService songService)
        {
            _playlistService = playlistService;
            _userService = userService;
            _songService = songService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var playlists = await _playlistService.GetAllAsync();
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
        public async Task<IActionResult> Create([FromBody] PlaylistCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Validate User
            var user = await _userService.GetUserByIdAsync(dto.UserId);
            if (user == null) return BadRequest($"User with Id {dto.UserId} not found.");

            // Validate Songs
            var validSongIds = (await _songService.GetAllAsync()).Select(s => s.Id).ToHashSet();
            var invalidSongs = dto.SongIds.Where(id => !validSongIds.Contains(id)).ToList();
            if (invalidSongs.Any())
                return BadRequest($"Invalid SongIds: {string.Join(", ", invalidSongs)}");

            var playlist = new Playlist
            {
                Name = dto.Name,
                UserId = dto.UserId,
                PlaylistSongs = dto.SongIds.Select(sid => new PlaylistSong { SongId = sid }).ToList()
            };

            await _playlistService.AddPlaylistAsync(playlist);
            return CreatedAtAction(nameof(GetById), new { id = playlist.Id }, playlist);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PlaylistUpdateDto dto)
        {
            var playlist = await _playlistService.GetPlaylistByIdAsync(id);
            if (playlist == null) return NotFound();

            playlist.Name = dto.Name;

            if (dto.SongIds != null)
            {
                var validSongIds = (await _songService.GetAllAsync()).Select(s => s.Id).ToHashSet();
                var invalidSongs = dto.SongIds.Where(sid => !validSongIds.Contains(sid)).ToList();
                if (invalidSongs.Any())
                    return BadRequest($"Invalid SongIds: {string.Join(", ", invalidSongs)}");

                playlist.PlaylistSongs = dto.SongIds.Select(sid => new PlaylistSong { SongId = sid, PlaylistId = id }).ToList();
            }

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
