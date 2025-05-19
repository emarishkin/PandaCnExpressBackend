namespace PandaApi.Dtos
{
    public class RegisterDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Status { get; set; } = "individual";
        public string Phone { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
