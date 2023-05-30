using AllGames.Application_Logic;
using AllGames.Application_Logic.Checks;
using AllGames.ApplicationInterface.ChangingState;
using AllGames.ApplicationInterface.Create;
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
            var filePath = new FilePath();
            Path.Text = filePath.Get();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var filePath = new FilePath();
            LauncherPath.Text = filePath.Get();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var status = new ButtonStatus();
            var checking = new CheckingAddition();
            var launcherNeeded = status.Check(requiresLauncher);
            var fieldsFilled = checking.Checking(NameBox, Path, Category);

            if (fieldsFilled)
            {
                if (launcherNeeded)
                {
                    var gameData = GameData.With()
                     .Id(Convert.ToInt32(Id.Text))
                     .Name(NameBox.Text)
                     .Path(Path.Text)
                     .LauncherPath(LauncherPath.Text)
                     .RequiresLauncher(launcherNeeded)
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
                     .RequiresLauncher(launcherNeeded)
                     .CategoryId(Convert.ToInt32(Category.Text.Split('.')[0]))
                     .CategoryName(Category.Text.Split('.')[1])
                     .Build();

                    var data = new CreateData(gameData);
                    data.CreationWithoutId();
                }

                Id.Clear();
                Path.Clear();
                NameBox.Clear();
                LauncherPath.Clear();
            }
            else
            {
                checking.ErrorMessage();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var activation = new ButtonActivation();
            var automaticId = new AutomaticId();
            var status = new ButtonStatus();
            var IdNeeded = status.Check(button1);
            activation.SetCommand(new AutomaticIdOnCommand(automaticId, button1));

            if (IdNeeded)
            {
                activation.PressUndo();
                Id.Enabled = true;
            }
            else
            {
                activation.PressButton();
                Id.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var checking = new CheckingDeletion();
            var fieldsFilled = checking.Checking(Id);
            if (fieldsFilled)
            {
                var gameData = GameData.With().Id(Convert.ToInt32(Id.Text)).Build();
                var data = new DeleteAll(gameData);
                data.DeleteGame();
                Id.Clear();
            }
            else
            {
                checking.ErrorMessage();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var status = new ButtonStatus();
            var checking = new CheckingUpdate();
            var fieldsFilled = checking.Checking(Id, NameBox, Path, Category);
            var launcherNeeded = status.Check(requiresLauncher);

            if (fieldsFilled)
            {
                var gameData = GameData.With()
                    .Id(Convert.ToInt32(Id.Text))
                    .Name(NameBox.Text)
                    .Path(Path.Text)
                    .LauncherPath(LauncherPath.Text)
                    .RequiresLauncher(launcherNeeded)
                    .CategoryId(Convert.ToInt32(Category.Text.Split('.')[0]))
                    .CategoryName(Category.Text.Split('.')[1])
                    .Build();
                var update = new UpdateData(gameData);
                update.Update();

                Id.Clear();
                Path.Clear();
                NameBox.Clear();
                LauncherPath.Clear();
            }
            else
            {
                checking.ErrorMessage();
            }
        }

        private void requiresLauncher_Click(object sender, EventArgs e)
        {
            var activation = new ButtonActivation();
            var automaticId = new AutomaticId();
            var status = new ButtonStatus();
            var launcherNeeded = status.Check(requiresLauncher);

            activation.SetCommand(new AutomaticIdOnCommand(automaticId, requiresLauncher));

            if (launcherNeeded)
            {
                activation.PressUndo();
                LauncherPath.Enabled = false;
            }
            else
            {
                activation.PressButton();
                LauncherPath.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var read = new ReadData();
            var category = new List<Category>();
            var elements = new LibraryElements();

            category = read.ReadCategory();

            var box = new ComboBoxItems(category);

            box.Create(Category);
            box.Create(comboBox1);

            elements.Add(flowLayoutPanel1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var read = new ReadData();
            var category = new List<Category>();

            var gameData = GameData.With().CategoryName(Category.Text).Build();

            var data = new CreateData(gameData);
            data.CreateCategory();

            category = read.ReadCategory();
            Category.Items.Clear();

            foreach (Category item in category)
            {
                Category.Items.Add($"{item.Id}.{item.Name}");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var read = new ReadData();
            var category = new List<Category>();

            var gameData = GameData.With().CategoryId(Convert.ToInt32(Category.Text.Split('.')[0])).Build();

            var data = new DeleteAll(gameData);
            data.DeleteCategory();

            category = read.ReadCategory();
            Category.Items.Clear();

            foreach (Category item in category)
            {
                Category.Items.Add($"{item.Id}.{item.Name}");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            var read = new ReadData();
            var games = new List<Games>();
            var category = new List<Category>();
            var categoryId = Convert.ToInt32(comboBox1.Text.Split('.')[0]);

            games = read.ReadGame();
            category = read.ReadCategory();

            foreach (Games game in games)
            {
                if (game.CategoryId == categoryId)
                {
                    var element = new GamePanel(game);
                    flowLayoutPanel1.Controls.Add(element.Create());
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            var read = new ReadData();
            var games = new List<Games>();
            var gameName = textBox1.Text;

            games = read.ReadGame();

            foreach (Games game in games)
            {
                if (game.Name.Contains(gameName))
                {
                    var element = new GamePanel(game);
                    flowLayoutPanel1.Controls.Add(element.Create());
                }
            }
        }
    }
}
