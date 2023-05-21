
namespace AllGames.VisualElements
{
    internal class TextBoxFromLayoutPanel
    {
        public TextBox Create(int x, int y)
        {
            var box = new TextBox();
            box.Location = new Point(x, y);
            box.BackColor = Color.White;
            box.Width = 80;
            box.Font = new Font(box.Text, 10);
            return box;
        }
    }
}
