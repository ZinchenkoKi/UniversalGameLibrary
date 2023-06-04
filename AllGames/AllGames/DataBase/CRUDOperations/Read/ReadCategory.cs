using AllGames.DataBase.Entity;

namespace AllGames.DataBase.CRUDOperations.Read
{
    internal class ReadCategory
    {
        public List<Category> Read()
        {
            using (var context = new DataContext())
            {
                var categories = context.Categories.ToList();
                return categories;
            }
        }
    }
}
