using AllGames.DataBase.Entity;

namespace AllGames.DataBase.CRUDOperations
{
    internal class CreateData
    {
        private GameData _gameData;

        public CreateData(GameData gameData)
        {
            _gameData = gameData;
        }

        public void Create()
        {
            using (var context = new DataContext())
            {
                var game = new Games() 
                {
                    Id = _gameData.Id
                    , Name = _gameData .Name
                    , Path = _gameData.Path
                    , CategoryId = _gameData.CategoryId
                    , LauncherPath = _gameData.LauncherPath
                    , RequiresLauncher = _gameData.RequiresLauncher
                };
                context.Games.Add(game);
                context.SaveChanges();
            }
        }

        public void CreateAutomaticId()
        {
            using (var context = new DataContext())
            {
                var game = new Games()
                {
                    Name = _gameData.Name
                    ,
                    Path = _gameData.Path
                    ,
                    CategoryId = _gameData.CategoryId
                    ,
                    LauncherPath = _gameData.LauncherPath
                    ,
                    RequiresLauncher = _gameData.RequiresLauncher
                };
                context.Games.Add(game);
                context.SaveChanges();
            }
        }

        public void CreateCategory()
        {
            using (var context = new DataContext())
            {
                var category = new Category() { Name = _gameData.CategoryName };
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
    }
}
