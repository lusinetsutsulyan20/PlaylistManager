using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IPlaylistSongService
    {
        Task<IEnumerable<PlaylistSong>> GetByPlaylistIdAsync(int playlistId);
        Task AddPlaylistSongAsync(PlaylistSong playlistSong);
    }
}
