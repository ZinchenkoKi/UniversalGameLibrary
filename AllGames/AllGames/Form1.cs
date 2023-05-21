using AllGames.CreatingVisualElements;
using AllGames.CreatingVisualElements.Buttons;
using AllGames.DataBase.EntityOperations;
using AllGames.DataBase.Requests;
using AllGames.VisualElements;

namespace AllGames
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var allGames = new WithdrawAllGames();
            allGames.Withdrawal(panel1);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            var allGames = new WithdrawAllGames();
            allGames.Withdrawal(panel1);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            var label = new LabelFromLayoutPanel();
            var textBox = new TextBoxFromLayoutPanel();
            var comboBox = new CategoryBox();
            var buttonDel = new DeleteButton();
            var buttonUp = new UpdateButton();
            var buttonC = new CreateButton();
            var checkBox = new CheckBox();
            var id = textBox.Create(30, 70);
            var name = textBox.Create(30, 150);
            var path = textBox.Create(30, 230);
            var category = comboBox.Create(30, 310);
            var delete = buttonDel.Create(175, 385, id);
            var update = buttonUp.Create(id.Text, name, path, category);
            var create = buttonC.Create(469, 385, name, path, category);
            path.DoubleClick += (sender, e) =>
            {
                openFileDialog1.ShowDialog();
                path.Text = openFileDialog1.FileName;
            };

            var read = new ReadData();
            foreach (var item in read.Read())
            {
                category.Items.Add(item.Category);
            }

            checkBox.Location = new Point(135, 70);


            panel1.Controls.Add(id);
            panel1.Controls.Add(name);
            panel1.Controls.Add(path);
            panel1.Controls.Add(category);
            panel1.Controls.Add(label.Create(30, 30, "Id"));
            panel1.Controls.Add(label.Create(30, 110, "Название игры"));
            panel1.Controls.Add(label.Create(30, 190, "Путь"));
            panel1.Controls.Add(label.Create(30, 270, "Категория"));
            panel1.Controls.Add(delete);
            panel1.Controls.Add(update);
            panel1.Controls.Add(create);
            panel1.Controls.Add(checkBox);
        }

    }
}