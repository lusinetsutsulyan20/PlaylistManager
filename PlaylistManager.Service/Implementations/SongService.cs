using Core.Interfaces;
using Core.Models;
using Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepo;

        public SongService(ISongRepository songRepo)
        {
            _songRepo = songRepo;
        }

        public async Task<Song?> GetSongByIdAsync(int id) => await _songRepo.GetByIdAsync(id);

        public async Task<IEnumerable<Song>> GetSongsByArtistAsync(string artist) =>
            await _songRepo.GetByArtistAsync(artist);

        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            return await _songRepo.GetAllAsync();
        }

        public async Task AddSongAsync(Song song)
        {
            await _songRepo.AddAsync(song);
            await _songRepo.SaveChangesAsync();
        }

        public async Task UpdateSongAsync(Song song)
        {
            _songRepo.Update(song);
            await _songRepo.SaveChangesAsync();
        }

        public async Task DeleteSongAsync(int id)
        {
            var song = await _songRepo.GetByIdAsync(id);
            if (song != null)
            {
                _songRepo.Delete(song);
                await _songRepo.SaveChangesAsync();
            }
        }
    }
}
