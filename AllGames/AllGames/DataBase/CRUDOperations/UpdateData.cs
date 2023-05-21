using AllGames.DataBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGames.DataBase.EntityOperations
{
    internal class UpdateData
    {
        public void Update(int id, string name, string path, int category)
        {
            using (DataContext context = new DataContext())
            {
                var game = context.Games.FirstOrDefault(i => i.Id == id);

                if (game != null)
                {
                    game.Name = name;
                    game.Path = path;
                    game.CategoryId = category;
                    context.Games.Update(game);
                    context.SaveChanges();
                }
            }
        }
    }
}
