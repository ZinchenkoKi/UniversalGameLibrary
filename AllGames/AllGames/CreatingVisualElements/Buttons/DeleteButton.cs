using AllGames.DataBase.Entity;
using AllGames.DataBase.EntityOperations;

namespace AllGames.CreatingVisualElements.Buttons
{
    internal class DeleteButton
    {
        public Button Create(int x, int y, TextBox textBox)
        {
            var delete = new Button();
            delete.Location = new Point(x, y);
            delete.BackColor = Color.White;
            delete.Width = 120;
            delete.Height = 40;
            delete.Text = "Удалить";
            delete.Click += (sender, e) =>
            {
                var delete = new DeleteData();
                delete.Delete(Convert.ToInt32(textBox.Text));
            };
            return delete;
        }
    }
}
