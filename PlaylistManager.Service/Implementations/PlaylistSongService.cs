using Core.Interfaces;
using Core.Models;
using Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class PlaylistSongService : IPlaylistSongService
    {
        private readonly IPlaylistSongRepository _repo;

        public PlaylistSongService(IPlaylistSongRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<PlaylistSong>> GetByPlaylistIdAsync(int playlistId) =>
            await _repo.GetByPlaylistIdAsync(playlistId);

        public async Task AddPlaylistSongAsync(PlaylistSong playlistSong)
        {
            await _repo.AddAsync(playlistSong);
            await _repo.SaveChangesAsync();
        }

    }
}
