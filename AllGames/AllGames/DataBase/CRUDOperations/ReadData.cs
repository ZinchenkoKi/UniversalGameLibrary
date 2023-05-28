using AllGames.DataBase.Entity;

namespace AllGames.DataBase.CRUDOperations
{
    internal class ReadData
    {
        public List<Games> Read() 
        {
            using (var context = new DataContext())
            {
                var games = context.Games.ToList();
                return games;
            }
        }

        public List<Category> CategoryRead()
        {
            using (var context = new DataContext())
            {
                var categories = context.Categories.ToList();
                return categories;
            }
        }
    }
}
