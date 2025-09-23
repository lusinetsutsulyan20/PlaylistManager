using Core.Models;

namespace Core.Interfaces
{
    public interface IPlaylistSongRepository : IGenericRepository<PlaylistSong>
    {
        Task<IEnumerable<PlaylistSong>> GetByPlaylistIdAsync(int playlistId);
    }
}
