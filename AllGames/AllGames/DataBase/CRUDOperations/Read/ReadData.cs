using AllGames.DataBase.Entity;

namespace AllGames.DataBase.CRUDOperations.Read
{
    internal class ReadData
    {
        private ReadCategory _readCategory;
        private ReadGame _readGame;

        public ReadData() 
        {
            _readCategory = new ReadCategory();
            _readGame = new ReadGame();
        }

        public List<Category> ReadCategory() 
        {
            return _readCategory.Read();
        }

        public List<Games> ReadGame() 
        {
            return _readGame.Read();
        }
    }
}
