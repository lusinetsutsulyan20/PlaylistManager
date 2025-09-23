namespace PlaylistManager.Shared
{
    public class PlaylistDto
    { 
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<int> SongIds { get; set; } = new();
    }
    public class PlaylistCreateDto
    {
        public string Name { get; set; } = "";
        public int UserId { get; set; }        
        public List<int> SongIds { get; set; } = new();
    }

    public class PlaylistReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public UserDto User { get; set; }          
        public List<SongDto> Songs { get; set; } = new();
    }

    public class PlaylistUpdateDto
    {
        public string Name { get; set; } = "";
        public List<int>? SongIds { get; set; }  
    }

}
