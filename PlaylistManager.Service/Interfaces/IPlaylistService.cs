using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IPlaylistService
    {
        Task<Playlist?> GetPlaylistByIdAsync(int id);
        Task<IEnumerable<Playlist>> GetAllAsync(); 
        Task<Playlist?> GetPlaylistWithSongsAsync(int id);
        Task AddPlaylistAsync(Playlist playlist);
        Task UpdatePlaylistAsync(Playlist playlist);
        Task DeletePlaylistAsync(int id);
    }
}
