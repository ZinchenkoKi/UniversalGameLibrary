using AllGames.DataBase.Entity;

namespace AllGames.DataBase.CRUDOperations
{
    internal class ReadData
    {
        public List<Games> ReadGame()
        {
            using (var context = new DataContext())
            {
                var games = context.Games.ToList();
                return games;
            }
        }

        public List<Category> ReadCategory()
        {
            using (var context = new DataContext())
            {
                var categories = context.Categories.ToList();
                return categories;
            }
        }
    }
}
