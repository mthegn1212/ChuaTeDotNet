namespace BatDongSan.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Ensure you hash the password before saving
        public DateTime CreatedAt { get; set; }
    }
}