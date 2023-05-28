using AllGames.DataBase.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllGames.VisualPart
{
    internal class GameElement
    {
        private Games _games;

        public GameElement(Games games) 
        {
            _games = games;
        }
        public Button Create()
        {
            Button button = new Button();
            button.Width = 170;
            button.Height = 250;
            button.Font = new Font("Microsoft Sans Serif",20);
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
