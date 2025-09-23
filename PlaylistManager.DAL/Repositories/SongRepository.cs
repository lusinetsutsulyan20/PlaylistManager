using Core.Interfaces;
using Core.Models;
using PlaylistManager.DB;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        public SongRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Song>> GetByArtistAsync(string artist) =>
            await _context.Songs.Where(s => s.Artist == artist).ToListAsync();
    }
}
