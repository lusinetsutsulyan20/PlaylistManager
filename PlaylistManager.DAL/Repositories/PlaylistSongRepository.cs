using Core.Interfaces;
using Core.Models;
using PlaylistManager.DB;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PlaylistSongRepository : GenericRepository<PlaylistSong>, IPlaylistSongRepository
    {
        public PlaylistSongRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<PlaylistSong>> GetByPlaylistIdAsync(int playlistId) =>
            await _context.PlaylistSongs
                .Include(ps => ps.Song)
                .Where(ps => ps.PlaylistId == playlistId)
                .ToListAsync();
    }
}
