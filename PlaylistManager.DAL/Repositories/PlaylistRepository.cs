using Core.Interfaces;
using Core.Models;
using PlaylistManager.DB;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PlaylistRepository : GenericRepository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(AppDbContext context) : base(context) { }

        public async Task<Playlist?> GetWithSongsAsync(int id) =>
            await _context.Playlists
                .Include(p => p.PlaylistSongs)
                .ThenInclude(ps => ps.Song)
                .FirstOrDefaultAsync(p => p.Id == id);
    }
}
