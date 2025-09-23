using Core.Models;

namespace Core.Interfaces
{
    public interface IPlaylistRepository : IGenericRepository<Playlist>
    {
        Task<Playlist?> GetWithSongsAsync(int id);
    }
}
