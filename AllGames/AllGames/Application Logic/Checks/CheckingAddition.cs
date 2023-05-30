
namespace AllGames.Application_Logic.Checks
{
    internal class CheckingAddition : CheckingFields
    {
        public CheckingAddition() {}

        public bool Checking(TextBox name, TextBox path, ComboBox category)
        {
            if (name.Text == "" || path.Text == "" || category.Text == "")
            {
               return false;
            }
            return true;
        }
    }
}
