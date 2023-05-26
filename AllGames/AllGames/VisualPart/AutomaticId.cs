using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGames.VisualPart
{
    internal class AutomaticId
    {
        public void On(Button button)
        {
            button.Text = "✔";
        }

        public void Off(Button button)
        {
            button.Text = "⬜";
        }
    }
}
