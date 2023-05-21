using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGames.DataBase.EntityOperations
{
    internal class DeleteData
    {
        public void Delete(int id)
        {
            using (DataContext context = new DataContext())
            {
                var game = context.Games.FirstOrDefault(i => i.Id == id);

                if (game != null) 
                {
                    context.Games.Remove(game);
                    context.SaveChanges();
                }
            }
        } 
    }
}
