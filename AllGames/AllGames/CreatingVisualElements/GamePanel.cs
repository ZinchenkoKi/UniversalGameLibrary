using AllGames.DataBase.Entity;
using System.Diagnostics;

namespace AllGames.VisualElements.Buttons
{
    internal class GamePanel
    {
        private Games _game;

        public GamePanel(Games games)
        {
            _game = games;
        }

        public  Button Create()
        {
            var button = new Button();

            button.Width = 200;
            button.Height = 300;
            button.Text = _game.Name;
            button.FlatStyle = FlatStyle.Flat;
            button.ForeColor = Color.WhiteSmoke;
            button.BackColor = Color.CornflowerBlue;
            button.Margin = new Padding(10, 10, 10, 10);
            button.Font = new Font(button.Text, 25);
            button.Click += (sender, e) => Process.Start($@"{_game.Path}");
            return button;
        }
    }
}
