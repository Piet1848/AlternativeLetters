using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternativeLetters
{
    internal class LetterCalc
    {
        private char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
        public List<Letter> updateInput(String input)
        {
            List<Letter> letters = new List<Letter>();
            String[] words = input.Split(' ', StringSplitOptions.TrimEntries);
            foreach (String word in words)
            {
                letters.AddRange(getLetters(word));
            }
            return letters;
        }

        private List<Letter> getLetters(String word)
        {
            List<Letter> letters = new List<Letter>();
            char[] chars = word.ToCharArray();
            List<char> charsInLetter = new List<char>();
            List<Color> colors = new List<Color>();

            bool lastVowel = false;
            for (int i = 0; i < chars.Length; i++)
            {
                char currentC = chars[i];
                if (vowels.Contains(currentC))
                {
                    lastVowel = true;
                    colors.Add(getColor(currentC));
                }
                else if (lastVowel)
                {
                    if(colors.Count == 0)
                    {
                        colors.Add(Color.Black);
                    }
                    letters.Add(new Letter(colors, charsInLetter));
                    charsInLetter = new List<char> { currentC };
                    colors = new List<Color>();
                    lastVowel = false;
                }
                else
                {
                    charsInLetter.Add(currentC);
                }
            }
            return letters;
        }

        private Color getColor(char c)
        {
            switch (c)
            {
                case 'a':
                    return Color.Red;
                case 'e':
                    return Color.Green;
                case 'i':
                    return Color.Orange;
                case 'o':
                    return Color.Yellow;
                case 'u':
                    return Color.Blue;
                default:
                    return Color.Black;
            }
        }
    }
}
