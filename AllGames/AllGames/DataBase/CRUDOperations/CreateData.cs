using AllGames.DataBase.Entity;

namespace AllGames.DataBase.CRUDOperations
{
    internal class CreateData
    {
        public void Create(int id, bool RequiresLauncher, params string[] gameData)
        {
            using (var context = new DataContext())
            {
                var game = new Games()
                {
                    Id = id
                    ,Name = gameData[0]
                    ,Path = gameData[1]
                    ,CategoryId = Convert.ToInt32(gameData[2])
                    ,LauncherPath = gameData[3]
                    ,RequiresLauncher = RequiresLauncher
                };
                context.Games.Add(game);
                context.SaveChanges();
            }
        }

        public void Create(bool RequiresLauncher, params string[] gameData)
        {
            using (var context = new DataContext())
            {
                var game = new Games()
                {
                    Name = gameData[0]
                    ,Path = gameData[1]
                    ,CategoryId = Convert.ToInt32(gameData[2])
                    ,LauncherPath = gameData[3]
                    ,RequiresLauncher = RequiresLauncher
                };
                context.Games.Add(game);
                context.SaveChanges();
            }
        }

        public void Create(string name)
        {
            using (var context = new DataContext())
            {
                var category = new Category() { Name = name };
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
    }
}
