using AllGames.DataBase.Entity;

namespace AllGames.DataBase.CRUDOperations
{
    internal class UpdateData
    {
        public void Update(TextBox id, bool requiresLauncher, ComboBox category, params TextBox[] parameters)
        {
            using (var context = new DataContext())
            {
                Games? game = context.Games.FirstOrDefault(i => i.Id == Convert.ToInt32(id.Text));

                if (game != null)
                {
                    game.Name = parameters[0].Text;
                    game.Path = parameters[1].Text;
                    game.CategoryId = Convert.ToInt32(category.Text);
                    game.LauncherPath = parameters[2].Text;
                    game.RequiresLauncher = requiresLauncher;
                    context.Games.Update(game);
                    context.SaveChanges();
                }
            }
        }
    }
}
