namespace AllGames.ApplicationInterface.ChangingState
{
    internal class AutomaticId
    {
        public void On(Button button)
        {
            button.Text = "✔";
        }

        public void Off(Button button)
        {
            button.Text = "⬜";
        }
    }
}
