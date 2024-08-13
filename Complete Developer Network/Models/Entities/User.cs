namespace Complete_Developer_Network.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public string? Skillsets { get; set; }
        public string? Hobby { get; set; }


    }
}
