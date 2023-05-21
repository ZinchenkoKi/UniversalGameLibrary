using AllGames.DataBase.EntityOperations;

namespace AllGames.CreatingVisualElements.Buttons
{
    internal class CreateButton
    {
        public Button Create(int x, int y, TextBox name, TextBox path, ComboBox category)
        {
            var create = new Button();
            create.Location = new Point(x, y);
            create.BackColor = Color.White;
            create.Width = 120;
            create.Height = 40;
            create.Text = "Добавить";
            create.Click += (sender, e) =>
            {
                var delete = new CreateData();
                delete.Create(name.Text, path.Text, Convert.ToInt32(category.Text));
            };
            return create;
        }
    }
}
