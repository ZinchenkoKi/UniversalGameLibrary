using AllGames.DataBase.Entity;


namespace AllGames.ApplicationInterface.Create
{
    internal class ComboBoxItems
    {
        private List<Category> _category;

        public ComboBoxItems(List<Category> category)
        {
            _category = category;
        }

        public void Create(ComboBox box)
        {
            foreach (Category item in _category)
            {
                box.Items.Add($"{item.Id}.{item.Name}");
            }
        }
    }
}
