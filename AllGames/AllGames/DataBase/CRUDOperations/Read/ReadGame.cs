using AllGames.DataBase.Entity;

namespace AllGames.DataBase.CRUDOperations.Read
{
    internal class ReadGame
    {
        public List<Games> Read()
        {
            using (var context = new DataContext())
            {
                var games = context.Games.ToList();
                return games;
            }
        }
    }
}
