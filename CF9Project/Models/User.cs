namespace CF9Project.Models
{
    public partial class User : BaseEntity
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;

        public Gamer? Gamer { get; set; }

        public GameCompany? GameCompany { get; set; }
    }
}
