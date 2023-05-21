using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGames.VisualElements
{
    internal class LabelFromLayoutPanel
    {
        public Label Create(int x,int y, string text)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new Point(x, y);
            label.Width = 80;
            label.Font = new Font(label.Text, 10);
            return label;
        }
    }
}
