namespace Models.Response
{
    public class UserResponse
    {
        public UserResponse(int id, string email, string username, DateTime createdAt)
        {
            Id = id;
            Email = email;
            Username = username;
            CreatedAt = createdAt;
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public DateTime CreatedAt { get; set; }
    }
    
}

