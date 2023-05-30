using AllGames.DataBase.Entity;

namespace AllGames.DataBase
{
    public class GameData
    {
        private int _id;
        private string _name;
        private string _path;
        private bool _requiresLauncher;
        private string _launcherPath;
        private int _categoryId;
        private string _categoryName;

        private GameData() { }

        public static GameDataBuilder With()
        {
            return new GameDataBuilder(new GameData());
        }

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string Path { get { return _path; } }
        public bool RequiresLauncher { get { return _requiresLauncher; } }
        public string LauncherPath { get { return _launcherPath; } }
        public int CategoryId { get { return _categoryId; } }
        public string CategoryName { get { return _categoryName; } }

        public class GameDataBuilder
        {
            private readonly GameData _gameData;
            internal GameDataBuilder(GameData gameData)
            {
                _gameData = gameData;
            }

            public GameDataBuilder Id(int id)
            {
                _gameData._id = id;
                return this;
            }

            public GameDataBuilder Name(string name)
            {
                _gameData._name = name;
                return this;
            }

            public GameDataBuilder Path(string path)
            {
                _gameData._path = path;
                return this;
            }

            public GameDataBuilder RequiresLauncher(bool requiresLauncher)
            {
                _gameData._requiresLauncher = requiresLauncher;
                return this;
            }

            public GameDataBuilder LauncherPath(string launcherPath)
            {
                _gameData._launcherPath = launcherPath;
                return this;
            }

            public GameDataBuilder CategoryId(int categoryId)
            {
                _gameData._categoryId = categoryId;
                return this;
            }

            public GameDataBuilder CategoryName(string name)
            {
                _gameData._categoryName = name;
                return this;
            }

            public GameData Build()
            {
                return _gameData;
            }
        }
    }
}
