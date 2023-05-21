using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGames.CreatingVisualElements
{
    internal class CategoryBox : ComboBox
    {
        public ComboBox Create(int x, int y)
        {
            var category = new ComboBox();

            category.Location = new Point(x, y);
            category.BackColor = Color.White;
            category.Width = 185;
            category.Font = new Font(category.Text, 10);
            return category;
        }
    }
}
