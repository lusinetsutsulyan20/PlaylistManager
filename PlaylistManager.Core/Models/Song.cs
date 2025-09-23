namespace Core.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Artist { get; set; } = "";

        public List<PlaylistSong> PlaylistSongs { get; set; } = new();
    }
}