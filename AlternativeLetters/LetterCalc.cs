using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternativeLetters
{
    internal class LetterCalc
    {
        private char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        public List<Word> updateInput(String input)
        {
            List<Word> newWords = new List<Word>();
            String[] words = input.Split(' ', StringSplitOptions.TrimEntries);
            foreach (String word in words)
            {
                newWords.Add(new Word(getLetters(word)));
            }
            return newWords;
        }

        private List<Letter> getLetters(String word)
        {
            List<Letter> outputWord = new List<Letter>();
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
                    if(charsInLetter.Count == 0)
                    {
                        charsInLetter.Add(currentC);
                    }
                    colors.Add(getColor(currentC));
                }else if((int) currentC < 65 || ((int) currentC > 90 && (int) currentC < 97) || (int) currentC > 122)
                {
                    if (charsInLetter.Count > 0)
                    {
                        if (colors.Count == 0)
                        {
                            colors.Add(Color.FromArgb(255, 220, 220, 220));
                        }
                        outputWord.Add(new Letter(colors, charsInLetter));
                        colors = new List<Color>();
                    }
                    outputWord.Add(new Letter(new List<Color> { Color.White }, new List<char> { currentC }));
                    charsInLetter = new List<char>();
                    lastVowel=false;
                }
                else if (lastVowel)
                {
                    if (colors.Count == 0)
                    {
                        colors.Add(Color.FromArgb(255, 220, 220, 220));
                    }
                    outputWord.Add(new Letter(colors, charsInLetter));
                    charsInLetter = new List<char> { currentC };
                    colors = new List<Color>();
                    lastVowel = false;
                }
                else
                {
                    charsInLetter.Add(currentC);
                }
            }
            if (charsInLetter.Count > 0)
            {
                if (colors.Count == 0)
                {
                    colors.Add(Color.FromArgb(255, 220, 220, 220));
                }
                outputWord.Add(new Letter(colors, charsInLetter));
            }
            outputWord.Add(new Letter());  //Leerzeichen ' '
            return outputWord;
        }

        private Color getColor(char c)
        {
            switch (c)
            {
                case 'a':
                    return Color.OrangeRed;
                case 'e':
                    return Color.LightSkyBlue;
                case 'i':
                    return Color.Yellow;
                case 'o':
                    return Color.FromArgb(255, 0, 123, 49);
                case 'u':
                    return Color.LightGreen;
                default:
                    return Color.FromArgb(255, 220, 220, 220);
            }
        }
    }
}
