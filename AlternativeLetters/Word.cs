using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternativeLetters
{
    internal class Word
    {
        public List<Letter> letterList;

        public Word(List<Letter> letterList)
        {
            this.letterList = letterList;
        }
    }
}
