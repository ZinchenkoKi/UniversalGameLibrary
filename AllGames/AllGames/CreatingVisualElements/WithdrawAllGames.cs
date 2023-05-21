using AllGames.VisualElements;

namespace AllGames.DataBase.Requests
{
    internal class WithdrawAllGames
    {
        public void Withdrawal(Panel panel1)
        {
            var flPanel = new FlowLayoutPanel();
            var lPanel = new LayoutPanel(flPanel);

            panel1.Controls.Clear();
            flPanel.Dock = DockStyle.Fill;
            panel1.Controls.Add(flPanel);
            lPanel.Add();
        }
    }
}