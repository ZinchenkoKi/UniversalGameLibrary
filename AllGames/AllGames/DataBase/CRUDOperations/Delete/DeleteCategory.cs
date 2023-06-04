using AllGames.DataBase.Entity;

namespace AllGames.DataBase.CRUDOperations.Delete
{
    internal class DeleteCategory : DeleteGame
    {
        public override void Delete(int id)
        {
            using (var context = new DataContext())
            {
                Category? category = context.Categories.FirstOrDefault(i => i.Id == id);

                if (category != null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }
            }
        }
    }
}
