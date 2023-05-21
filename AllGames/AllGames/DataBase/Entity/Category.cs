using System.ComponentModel.DataAnnotations;

namespace AllGames.DataBase.Entity
{
    internal class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Games> Games { get; set; } = new();
    }
}
