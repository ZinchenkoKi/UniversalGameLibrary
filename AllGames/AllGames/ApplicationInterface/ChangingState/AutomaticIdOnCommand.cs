namespace AllGames.ApplicationInterface.ChangingState
{
    internal class AutomaticIdOnCommand : ICommand
    {
        AutomaticId id;
        Button button;

        public AutomaticIdOnCommand(AutomaticId id, Button button)
        {
            this.id = id;
            this.button = button;
        }

        public void Execute()
        {
            id.On(button);
        }

        public void Undo()
        {
            id.Off(button);
        }
    }
}
