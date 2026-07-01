namespace CF9Project.Models
{
    public class Game : BaseEntity
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;

        public int Price { get; set; }

        public string Genre { get; set; } = null!;

        public int? GameCompanyId { get; set; }

        public GameCompany? GameCompany { get; set; }

        public ICollection<Gamer> Gamers { get; set; } = new HashSet<Gamer>();
    }
}
