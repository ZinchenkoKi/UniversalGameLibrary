using AllGames.DataBase;
using AllGames.DataBase.CRUDOperations;
using AllGames.DataBase.Entity;
using AllGames.VisualPart;

namespace AllGames
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            Path.Text = dialog.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            LauncherPath.Text = dialog.FileName;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var status = new ButtonStatus();

            if (button1.Text == "⬜")
            {
                var gameData = GameData.With()
                 .Id(Convert.ToInt32(Id.Text))
                 .Name(NameBox.Text)
                 .Path(Path.Text)
                 .LauncherPath(LauncherPath.Text)
                 .RequiresLauncher(status.Check(requiresLauncher))
                 .CategoryId(Convert.ToInt32(Category.Text.Split('.')[0]))
                 .CategoryName(Category.Text.Split('.')[1])
                 .Build();

                var data = new CreateData(gameData);
                data.Create();
            }
            else
            {
                var gameData = GameData.With()
                 .Name(NameBox.Text)
                 .Path(Path.Text)
                 .LauncherPath(LauncherPath.Text)
                 .RequiresLauncher(status.Check(requiresLauncher))
                 .CategoryId(Convert.ToInt32(Category.Text.Split('.')[0]))
                 .CategoryName(Category.Text.Split('.')[1])
                 .Build();

                var data = new CreateData(gameData);
                data.CreateAutomaticId();
            }

            MessageBox.Show($"Игра \"{NameBox.Text}\" добавлена.");
            Id.Clear();
            Path.Clear();
            NameBox.Clear();
            LauncherPath.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var activation = new ButtonActivation();
            var automaticId = new AutomaticId();
            activation.SetCommand(new AutomaticIdOnCommand(automaticId, button1));

            if (button1.Text == "⬜")
            {
                activation.PressButton();
                Id.Enabled = false;
            }
            else
            {
                activation.PressUndo();
                Id.Enabled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var gameData = GameData.With().Id(Convert.ToInt32(Id.Text)).Build();

            var data = new DeleteData(gameData);
            data.Delete();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В разработке");
        }

        private void requiresLauncher_Click(object sender, EventArgs e)
        {
            var activation = new ButtonActivation();
            var automaticId = new AutomaticId();
            activation.SetCommand(new AutomaticIdOnCommand(automaticId, requiresLauncher));

            if (requiresLauncher.Text == "⬜")
            {
                activation.PressButton();
                LauncherPath.Enabled = true;
            }
            else
            {
                activation.PressUndo();
                LauncherPath.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var read = new ReadData();
            var games = new List<Games>();
            var category = new List<Category>();

            games = read.Read();
            category = read.CategoryRead();

            foreach (Category item in category)
            {
                Category.Items.Add($"{item.Id}.{item.Name}");
                checkedListBox1.Items.Add(item.Name);
            }

            foreach (Games game in games)
            {
                var element = new GameElement(game);
                flowLayoutPanel1.Controls.Add(element.Create());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var read = new ReadData();
            var category = new List<Category>();

            var gameData = GameData.With().CategoryName(Category.Text).Build();

            var data = new CreateData(gameData);
            data.CreateCategory();

            category = read.CategoryRead();
            Category.Items.Clear();

            foreach (Category item in category)
            {
                Category.Items.Add($"{item.Id}.{item.Name}");
                checkedListBox1.Items.Add(item.Name);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var read = new ReadData();
            var category = new List<Category>();

            var gameData = GameData.With().CategoryId(Convert.ToInt32(Category.Text.Split('.')[0])).Build();

            var data = new DeleteData(gameData);
            data.CategoryDelete();

            category = read.CategoryRead();
            Category.Items.Clear();

            foreach (Category item in category)
            {
                Category.Items.Add($"{item.Id}.{item.Name}");
                checkedListBox1.Items.Add(item.Name);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            var read = new ReadData();
            var games = new List<Games>();
            var category = new List<Category>();

            games = read.Read();
            category = read.CategoryRead();

            foreach (Games game in games)
            {
                if (game.CategoryId == 9)
                {
                    var element = new GameElement(game);
                    flowLayoutPanel1.Controls.Add(element.Create());
                }
            }
        }
    }
}
