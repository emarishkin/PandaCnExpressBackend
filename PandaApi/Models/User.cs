namespace PandaApi.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Status { get; set; } = "no"; // individual / company

        public string Phone { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;
    }
}
