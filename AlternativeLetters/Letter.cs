using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternativeLetters
{
    internal class Letter
    {
        public List<Color> colors;
        public List<char> chars;

        public Letter(List<Color> colors, List<char> c)
        {
            this.colors = colors;
            this.chars = c;
        }

        public Letter()
        {
            colors = new List<Color> { Color.FromArgb(255, 220, 220, 220) };
            chars = new List<char> { ' ' };
        }
    }
}
