using AllGames.DataBase.Entity;

namespace AllGames.DataBase.CRUDOperations
{
    internal class DeleteAll
    {
        private GameData _gameData;

        public DeleteAll(GameData gameData)
        {
            _gameData = gameData;
        }

        public void DeleteGame()
        {
            using (var context = new DataContext())
            {
                Games? game = context.Games.FirstOrDefault(i => i.Id == _gameData.Id);

                if (game != null)
                {
                    context.Games.Remove(game);
                    context.SaveChanges();
                }
            }
        }

        public void DeleteCategory()
        {
            using (var context = new DataContext())
            {
                Category? category = context.Categories.FirstOrDefault(i => i.Id == _gameData.CategoryId);

                if (category != null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }
            }
        }
    }
}
