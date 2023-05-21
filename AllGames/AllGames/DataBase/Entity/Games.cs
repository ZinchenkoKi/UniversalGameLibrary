using System.ComponentModel.DataAnnotations;

namespace AllGames.DataBase.Entity
{
    internal class Games
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Path { get; set; }
        public bool RequiresLauncher { get; set; }
        public string LauncherPath { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
