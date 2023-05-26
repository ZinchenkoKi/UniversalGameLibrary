using AllGames.DataBase.Entity;

namespace AllGames.DataBase.CRUDOperations
{
    internal class UpdateData
    {
        private GameData _gameData;

        public UpdateData(GameData gameData)
        {
            _gameData = gameData;
        }

        public void Update()
        {
            using (var context = new DataContext())
            {
                Games? game = context.Games.FirstOrDefault(i => i.Id == _gameData.Id);

                if (game != null)
                {
                    if (_gameData.Name != null)
                    {
                        game.Name = _gameData.Name;
                    }

                    if (_gameData.Path != null)
                    {
                        game.Path = _gameData.Path;
                    }

                    if (_gameData.CategoryId != game.CategoryId)
                    {
                        game.CategoryId = _gameData.CategoryId;
                    }

                    if (_gameData.LauncherPath != null)
                    {
                        game.LauncherPath = _gameData.LauncherPath;
                    }

                    game.RequiresLauncher = _gameData.RequiresLauncher;
                    context.SaveChanges();
                }
            }
        }
    }
}
