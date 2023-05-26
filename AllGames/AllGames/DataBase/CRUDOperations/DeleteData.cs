using AllGames.DataBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGames.DataBase.CRUDOperations
{
    internal class DeleteData
    {
        private GameData _gameData;

        public DeleteData(GameData gameData)
        {
            _gameData = gameData;
        }

        public void Delete()
        {
            using (var context = new DataContext())
            {
                Games? game = context.Games.FirstOrDefault(i => i.Id == _gameData.Id);

                if (game != null) 
                {
                    context.Games.Remove(game);
                    context.SaveChanges();
                }
            }
        }

        public void CategoryDelete()
        {
            using (var context = new DataContext())
            {
                Category? category = context.Categories.FirstOrDefault(i => i.Id == _gameData.CategoryId);

                if (category != null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }
            }
        }
    }
}
