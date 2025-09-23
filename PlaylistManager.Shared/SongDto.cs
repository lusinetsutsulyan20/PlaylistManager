namespace PlaylistManager.Shared
{
    public class SongDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Artist { get; set; } = "";
    }
    public class SongCreateDto
    {
        public string Title { get; set; } = "";
        public string Artist { get; set; } = "";
    }
    public class SongUpdateDto
    {
        public string Title { get; set; } = "";
        public string Artist { get; set; } = "";
    }
}
