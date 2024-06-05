namespace MrKoolApplication.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string? Email { get; set; }

        public byte[]? HashPassword { get; set; }
        public byte[]? SaltPassword { get; set; }

        public string? RoleName { get; set; }
    }
}
