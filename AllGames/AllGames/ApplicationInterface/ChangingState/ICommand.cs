namespace AllGames.ApplicationInterface.ChangingState
{
    internal interface ICommand
    {
        void Execute();
        void Undo();
    }
}
