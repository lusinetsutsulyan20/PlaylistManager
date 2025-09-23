using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISongService
    {
        Task<Song?> GetSongByIdAsync(int id);
        Task<IEnumerable<Song>> GetAllAsync(); 
        Task<IEnumerable<Song>> GetSongsByArtistAsync(string artist);
        Task AddSongAsync(Song song);
        Task UpdateSongAsync(Song song);
        Task DeleteSongAsync(int id);
    }
}
