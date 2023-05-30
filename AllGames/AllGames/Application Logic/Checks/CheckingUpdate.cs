
namespace AllGames.Application_Logic.Checks
{
    internal class CheckingUpdate : CheckingFields
    {
        public CheckingUpdate() { }

        public bool Checking(TextBox id, TextBox name, TextBox path, ComboBox category)
        {
            if (id.Text == "" || name.Text == "" || path.Text == "" || category.Text == "")
            {
                return false;
            }
            return true;
        }
    }
}
