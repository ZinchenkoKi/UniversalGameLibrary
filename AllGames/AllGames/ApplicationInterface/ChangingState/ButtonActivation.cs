namespace AllGames.ApplicationInterface.ChangingState
{
    internal class ButtonActivation
    {
        ICommand command;

        public ButtonActivation() { }

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void PressButton()
        {
            command.Execute();
        }

        public void PressUndo()
        {
            command.Undo();
        }
    }
}
