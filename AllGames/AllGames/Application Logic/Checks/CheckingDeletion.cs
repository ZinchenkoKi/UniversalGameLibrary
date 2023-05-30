
namespace AllGames.Application_Logic.Checks
{
    internal class CheckingDeletion : CheckingFields
    {
        public CheckingDeletion() { }

        public bool Checking(TextBox id) =>  id.Text != "";
    }
}
