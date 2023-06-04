namespace AllGames.ApplicationInterface.ChangingState
{
    internal class AutomaticIdOnCommand : ICommand
    {
        private AutomaticId _id;
        private Button _button;

        public AutomaticIdOnCommand(AutomaticId id, Button button)
        {
            _id = id;
            _button = button;
        }

        public void Execute()
        {
            _id.On(_button);
        }

        public void Undo()
        {
            _id.Off(_button);
        }
    }
}
