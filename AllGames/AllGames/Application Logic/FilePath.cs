
namespace AllGames.Application_Logic
{
    internal class FilePath
    {
        public string Get()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            return dialog.FileName;
        }
    }
}
