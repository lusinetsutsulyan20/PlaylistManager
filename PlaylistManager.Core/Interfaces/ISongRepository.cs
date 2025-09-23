using Core.Models;

namespace Core.Interfaces
{
    public interface ISongRepository : IGenericRepository<Song>
    {
        Task<IEnumerable<Song>> GetByArtistAsync(string artist);
    }
}
