using System.Drawing;
using System.Windows.Forms;

namespace AlternativeLetters
{
    // Keeps layout separate from animation: a repaint never changes the displayed frame.
    internal sealed class Picture : ScrollableControl
    {
        private readonly List<(Letter Letter, Point Position)> glyphs = new();
        private List<Word> words = new();
        private int frame;
        private int cellWidth;
        private int lineHeight;

        public bool HasAnimation { get; private set; }

        public Picture()
        {
            AutoScroll = true;
            DoubleBuffered = true;
            BackColor = Color.FromArgb(32, 32, 32);
            ForeColor = Color.White;
            Font = new Font(FontFamily.GenericMonospace, 20F);
            Padding = new Padding(12);
            TabStop = true;
            AccessibleName = "Alternative letters output";
        }

        public void SetWords(List<Word> value)
        {
            words = value;
            frame = 0;
            HasAnimation = words.Any(word => word.letterList.Any(letter =>
                letter.chars.Count > 1 || letter.colors.Count > 1));
            LayoutGlyphs();
        }

        public void AdvanceFrame()
        {
            frame = frame == int.MaxValue ? 0 : frame + 1;
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            LayoutGlyphs();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            LayoutGlyphs();
        }

        private void LayoutGlyphs()
        {
            if (words == null || ClientSize.Width <= 0) return;
            glyphs.Clear();
            Size cell = TextRenderer.MeasureText("M", Font, Size.Empty,
                TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine);
            cellWidth = Math.Max(1, cell.Width);
            lineHeight = Math.Max(1, cell.Height + 8);
            int left = Padding.Left, x = left, y = Padding.Top;
            // Reserve room for a vertical scrollbar so its appearance does not change wrapping.
            int right = Math.Max(left + cellWidth, ClientSize.Width - Padding.Right - SystemInformation.VerticalScrollBarWidth);
            foreach (Word word in words)
            {
                int length = word.letterList.TakeWhile(letter => letter.chars[0] != '\n').Count();
                if (x > left && length * cellWidth <= right - left && x + length * cellWidth > right)
                {
                    x = left;
                    y += lineHeight;
                }
                foreach (Letter letter in word.letterList)
                {
                    if (letter.chars[0] == '\n')
                    {
                        x = left;
                        y += lineHeight;
                        continue;
                    }
                    if (x + cellWidth > right && x > left)
                    {
                        x = left;
                        y += lineHeight;
                    }
                    glyphs.Add((letter, new Point(x, y)));
                    x += cellWidth;
                }
            }
            AutoScrollMinSize = new Size(0, y + lineHeight + Padding.Bottom);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Point scroll = AutoScrollPosition;
            // Glyphs are in reading order, so skip directly to the first visible row.
            int low = 0, high = glyphs.Count;
            while (low < high)
            {
                int middle = low + (high - low) / 2;
                if (glyphs[middle].Position.Y + scroll.Y + lineHeight < 0) low = middle + 1;
                else high = middle;
            }
            for (int index = low; index < glyphs.Count; index++)
            {
                var glyph = glyphs[index];
                int y = glyph.Position.Y + scroll.Y;
                if (y > ClientSize.Height) break;
                Letter letter = glyph.Letter;
                TextRenderer.DrawText(e.Graphics, letter.chars[frame % letter.chars.Count].ToString(), Font,
                    new Point(glyph.Position.X + scroll.X, y), letter.colors[frame % letter.colors.Count],
                    TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine);
            }
        }
    }
}
