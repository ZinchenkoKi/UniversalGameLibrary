using AllGames.DataBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGames.DataBase.EntityOperations
{
    internal class CreateData
    {
        public void Create(string name, string path, int category)
        {
            using (DataContext context = new DataContext())
            {
                var games = new Games()
                {
                    Name = name,
                    Path = path,
                    CategoryId = category
                };

                context.Games.Add(games);
                context.SaveChanges();
            }
        }
    }
}
