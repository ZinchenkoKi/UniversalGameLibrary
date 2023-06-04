
namespace AllGames.Application_Logic
{
    internal class FilePath
    {
        public string GetPath()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            return dialog.FileName;
        }
    }
}
