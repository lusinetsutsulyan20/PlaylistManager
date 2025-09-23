using System;
using System.Collections.Generic;
namespace PlaylistManager.Shared
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
    }

    public class UserCreateDto
    {
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
    }
    public class UserUpdateDto
    {
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
    }
}
