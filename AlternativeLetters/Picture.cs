﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternativeLetters
{
    internal class Picture
    {
        static readonly Random rng = new Random();
        List<Word> words;
        int counter = 0;
        int height;
        int width;

        public Picture(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public void setFrames(List<Word> words)
        {
            //TODO calc frames
            this.words = words;
        }

        public void setHeightWidth(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public void Render(Graphics g, Control target)
        {
            float wt = target.ClientSize.Width, ht = target.ClientSize.Height;
            Font font = new Font("Cascadia Mono", 20);
            int x = 0;
            int y = 0;
            int dx = 20;
            int dy = 45;
            foreach (Word word in words)
            {
                if (x + dx * word.letterList.Count >= width - 2 * dx)
                {
                    x = 0;
                    y += dy;
                }
                foreach (Letter letter in word.letterList)
                {
                    if (letter.chars[0] != 10)
                    {
                        Color color = letter.colors[counter % letter.colors.Count];
                        PointF pos = new Point(x, y);
                        int modulo = counter % letter.chars.Count;
                        String s = "" + letter.chars[modulo];
                        g.DrawString(s, font, new SolidBrush(color), pos);
                        x += dx;
                    }
                    else
                    {
                        y += dy;
                        x = 0;
                    }
                }
            }
            counter++;
        }

        public Bitmap GenerateBitmap(PictureBox target)
        {
            int wt = target.ClientSize.Width, ht = target.ClientSize.Height;
            Bitmap bmp = new Bitmap(wt, ht, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            Render(g, target);
            return bmp;
        }
    }
}
