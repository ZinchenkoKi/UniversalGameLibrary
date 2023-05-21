using AllGames.DataBase.Entity;
using AllGames.DataBase.EntityOperations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AllGames.CreatingVisualElements.Buttons
{
    internal class UpdateButton
    {
        public Button Create(string id, TextBox name, TextBox path, ComboBox category)
        {
            var update = new Button();

            update.Location = new Point(321, 385);
            update.BackColor = Color.White;
            update.Width = 120;
            update.Height = 40;
            update.Text = "Изменить";
            update.Click += (sender, e) =>
            {
                var data = new UpdateData();
                data.Update(Convert.ToInt32(id), name.Text, path.Text, Convert.ToInt32(category.Text));
            };
            return update;
        }
    }
}
