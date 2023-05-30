using AllGames.DataBase.CRUDOperations;
using AllGames.DataBase.Entity;

namespace AllGames.ApplicationInterface.Create
{
    internal class LibraryElements
    {
        public void Add(FlowLayoutPanel panel)
        {
            var read = new ReadData();
            var games = new List<Games>();

            games = read.ReadGame();

            foreach (Games game in games)
            {
                var element = new GamePanel(game);
                panel.Controls.Add(element.Create());
            }
        }
    }
}
