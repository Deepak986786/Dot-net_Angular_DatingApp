namespace API.Entities
{
    public class AppUser
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
