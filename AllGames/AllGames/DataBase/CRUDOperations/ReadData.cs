using AllGames.DataBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGames.DataBase.EntityOperations
{
    internal class ReadData
    {
        public List<Games> Read()
        {
            using (DataContext context = new DataContext())
            {
                var allGames = context.Games.ToList();
                return allGames;
            }  
        }
    }
}
