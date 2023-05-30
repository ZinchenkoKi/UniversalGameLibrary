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
                    game.Name = _gameData.Name;
                    game.Path = _gameData.Path;
                    game.CategoryId = _gameData.CategoryId;
                    game.LauncherPath = _gameData.LauncherPath;
                    game.RequiresLauncher = _gameData.RequiresLauncher;
                    context.Games.Update(game);
                    context.SaveChanges();
                }
            }
        }
    }
}
