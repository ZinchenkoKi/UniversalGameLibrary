using AllGames.DataBase.Entity;
using AllGames.DataBase.EntityOperations;
using AllGames.VisualElements.Buttons;

namespace AllGames.VisualElements
{
    internal class LayoutPanel
    {
        private FlowLayoutPanel _flowLayoutPanel;

        public LayoutPanel(FlowLayoutPanel flowLayoutPanel) 
        {
            this._flowLayoutPanel = flowLayoutPanel;
        }

        public void Add()
        {
            var data = new ReadData();
            var gameNames = new List<Games>();

            foreach (var item in data.Read())
            {
                var button = new GamePanel(item);

                _flowLayoutPanel.Controls.Add(button.Create());
            }
        }
    }
}
