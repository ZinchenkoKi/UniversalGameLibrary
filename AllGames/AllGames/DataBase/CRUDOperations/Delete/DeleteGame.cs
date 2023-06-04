using AllGames.DataBase.Entity;

namespace AllGames.DataBase.CRUDOperations.Delete
{
    internal class DeleteGame
    {
        public virtual void Delete(int id)
        {
            using (var context = new DataContext())
            {
                Games? game = context.Games.FirstOrDefault(i => i.Id == id);

                if (game != null)
                {
                    context.Games.Remove(game);
                    context.SaveChanges();
                }
            }
        }
    }
}
