namespace Core.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public int UserId { get; set; }           // One-to-Many User
        public User User { get; set; } = null!;

        public List<PlaylistSong> PlaylistSongs { get; set; } = new();  // Many-to-Many Song    
    }
}