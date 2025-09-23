using Core.Interfaces;
using Core.Models;
using Service.Interfaces;

namespace Service.Implementations
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepo;

        public PlaylistService(IPlaylistRepository playlistRepo)
        {
            _playlistRepo = playlistRepo;
        }

        public async Task<Playlist?> GetPlaylistByIdAsync(int id) => await _playlistRepo.GetByIdAsync(id);

        public async Task<Playlist?> GetPlaylistWithSongsAsync(int id) => await _playlistRepo.GetWithSongsAsync(id);

        public async Task<IEnumerable<Playlist>> GetAllAsync()
        {
            return await _playlistRepo.GetAllAsync();
        }

        public async Task AddPlaylistAsync(Playlist playlist)
        {
            await _playlistRepo.AddAsync(playlist);
            await _playlistRepo.SaveChangesAsync();
        }

        public async Task UpdatePlaylistAsync(Playlist playlist)
        {
            _playlistRepo.Update(playlist);
            await _playlistRepo.SaveChangesAsync();
        }

        public async Task DeletePlaylistAsync(int id)
        {
            var playlist = await _playlistRepo.GetByIdAsync(id);
            if (playlist != null)
            {
                _playlistRepo.Delete(playlist);
                await _playlistRepo.SaveChangesAsync();
            }
        }
    }
}
