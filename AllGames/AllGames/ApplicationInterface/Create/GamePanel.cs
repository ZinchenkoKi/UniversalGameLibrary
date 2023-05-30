using AllGames.DataBase.Entity;
using System.Diagnostics;

namespace AllGames.ApplicationInterface.Create
{
    internal class GamePanel
    {
        private Games _games;

        public GamePanel(Games games)
        {
            _games = games;
        }
        public Button Create()
        {
            Button button = new Button();
            button.Width = 170;
            button.Height = 250;
            button.Font = new Font("Microsoft Sans Serif", 20);
            button.TextAlign = ContentAlignment.BottomLeft;
            button.Text = $"Id: {_games.Id} \n{_games.Name}";
            button.Click += (s, e) =>
            {
                if (_games.RequiresLauncher)
                {
                    Process.Start(_games.LauncherPath);
                }
                Process.Start(_games.Path);
            };
            return button;
        }
    }
}
