using AllGames.DataBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGames.DataBase.EntityOperations
{
    internal class AddingData
    {
        public void Add(string Name, string Path)
        {
            using (DataContext context = new DataContext())
            {
                Games games = new Games() { Name = Name, Path = Path };
                context.SaveChanges();
            }
        }
    }
}
