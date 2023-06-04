using AllGames.Application_Logic;
using AllGames.Application_Logic.Checks;
using AllGames.ApplicationInterface.ChangingState;
using AllGames.ApplicationInterface.Create;
using AllGames.DataBase.CRUDOperations;
using AllGames.DataBase.CRUDOperations.Delete;
using AllGames.DataBase.CRUDOperations.Read;
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
            Path.Text = filePath.GetPath();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var filePath = new FilePath();
            LauncherPath.Text = filePath.GetPath();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var status = new ButtonStatus();
            var checking = new CheckingAddition();
            var launcherNeeded = status.Check(requiresLauncher);
            var fieldsFilled = checking.Checking(NameBox, Path, Category);
            var categoryId = Category.Text.Split('.')[0];

            if (fieldsFilled)
            {
                if (launcherNeeded)
                {
                    var data = new CreateData();
                    data.Create(
                        Convert.ToInt32(Id.Text)
                        , launcherNeeded
                        , NameBox.Text
                        , Path.Text
                        , categoryId
                        , LauncherPath.Text);
                }
                else
                {
                    var data = new CreateData();
                    data.Create(
                        launcherNeeded
                        , NameBox.Text
                        , Path.Text
                        , categoryId
                        , LauncherPath.Text);
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

            if (checking.Checking(Id))
            {
                var data = new DeleteGame();
                data.Delete(Convert.ToInt32(Id.Text));
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
                var update = new UpdateData();
                update.Update(Id, launcherNeeded, Category, NameBox, Path, LauncherPath);

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
            var data = new CreateData();
            var categoryName = Category.Text.Split('.')[1];

            data.Create(categoryName);
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
            var data = new DeleteCategory();
            var category = new List<Category>();
            var categoryId = Convert.ToInt32(Category.Text.Split('.')[0]);

            data.Delete(categoryId);
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
            var categories = new List<Category>();
            var categoryId = Convert.ToInt32(comboBox1.Text.Split('.')[0]);

            games = read.ReadGame();
            categories = read.ReadCategory();

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
