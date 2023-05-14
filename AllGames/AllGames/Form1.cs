using AllGames.DataBase.Entity;
using System.Diagnostics;

namespace AllGames
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Click(object sender, EventArgs e)
        {

        }

        public class Gamess
        {
            public string Name;
            public string Path;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Gamess gamess = new Gamess();
            Gamess gamess1 = new Gamess();
            List<Gamess> gameNames = new List<Gamess>();
            gamess.Name = "Dota";
            gamess.Path = @"D:\SteamLibrary\steamapps\common\dota 2 beta\game\bin\win64\dota2.exe";
            gameNames.Add(gamess);
            gamess1.Name = "ACValhalla";
            gamess1.Path = @"D:\Games\Assassin's Creed Valhalla\ACValhalla.exe";
            gameNames.Add(gamess1);
            gamess1.Name = "ACValhalla";
            gamess1.Path = @"D:\Games\Assassin's Creed Valhalla\ACValhalla.exe";
            gameNames.Add(gamess1);
            gamess1.Name = "ACValhalla";
            gamess1.Path = @"D:\Games\Assassin's Creed Valhalla\ACValhalla.exe";
            gameNames.Add(gamess1);
            gamess1.Name = "ACValhalla";
            gamess1.Path = @"D:\Games\Assassin's Creed Valhalla\ACValhalla.exe";
            gameNames.Add(gamess1);
            gamess1.Name = "ACValhalla";
            gamess1.Path = @"D:\Games\Assassin's Creed Valhalla\ACValhalla.exe";
            gameNames.Add(gamess1);
            gamess1.Name = "ACValhalla";
            gamess1.Path = @"D:\Games\Assassin's Creed Valhalla\ACValhalla.exe";
            gameNames.Add(gamess1);
            gamess1.Name = "ACValhalla";
            gamess1.Path = @"D:\Games\Assassin's Creed Valhalla\ACValhalla.exe";
            gameNames.Add(gamess1);
            gamess1.Name = "ACValhalla";
            gamess1.Path = @"D:\Games\Assassin's Creed Valhalla\ACValhalla.exe";
            gameNames.Add(gamess1);
            gamess1.Name = "ACValhalla";
            gamess1.Path = @"D:\Games\Assassin's Creed Valhalla\ACValhalla.exe";
            gameNames.Add(gamess1);
            gamess1.Name = "ACValhalla";
            gamess1.Path = @"D:\Games\Assassin's Creed Valhalla\ACValhalla.exe";
            gameNames.Add(gamess1);
            gamess1.Name = "ACValhalla";
            gamess1.Path = @"D:\Games\Assassin's Creed Valhalla\ACValhalla.exe";
            gameNames.Add(gamess1);
            gamess1.Name = "ACValhalla";
            gamess1.Path = @"D:\Games\Assassin's Creed Valhalla\ACValhalla.exe";
            gameNames.Add(gamess1);
            gamess1.Name = "ACValhalla";
            gamess1.Path = @"D:\Games\Assassin's Creed Valhalla\ACValhalla.exe";
            gameNames.Add(gamess1);
            gamess1.Name = "ACValhalla";
            gamess1.Path = @"D:\Games\Assassin's Creed Valhalla\ACValhalla.exe";
            gameNames.Add(gamess1);
            gamess1.Name = "ACValhalla";
            gamess1.Path = @"D:\Games\Assassin's Creed Valhalla\ACValhalla.exe";
            gameNames.Add(gamess1);
            gamess1.Name = "ACValhalla";
            gamess1.Path = @"D:\Games\Assassin's Creed Valhalla\ACValhalla.exe";
            gameNames.Add(gamess1);
            foreach (var item in gameNames)
            {
                Button helloButton = new Button();
                helloButton.BackColor = Color.White;
                helloButton.ForeColor = Color.Black;
                helloButton.Width = 200;
                helloButton.Height = 30;
                helloButton.FlatStyle = FlatStyle.Flat;
                helloButton.Text = item.Name;
                helloButton.Font = new Font(helloButton.Text, 15);
                flowLayoutPanel1.Controls.Add(helloButton);
                helloButton.Click += (sender, e) =>
                {
                    Process.Start(item.Path);
                };
            }
        }
    }
}