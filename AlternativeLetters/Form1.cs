using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace AlternativeLetters
{
    public partial class Form1 : Form
    {
        LetterCalc letterCalc;
        Picture picture;
        List<Word> words;

        public Form1()
        {
            InitializeComponent();
            letterCalc = new LetterCalc();
            words = letterCalc.updateInput(tbInput.Text);
            picture = new Picture(pictureBox.Height, pictureBox.Width);
            picture.setFrames(words);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            base.SizeChanged += (s, ev) => setHeightWidth();
            pictureBox.Paint += (s, ev) =>
            {
                ev.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                ev.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                picture.Render(ev.Graphics, pictureBox);
            };
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            words = letterCalc.updateInput(tbInput.Text);
            picture.setFrames(words);
            timer1.Interval = 150;
            timer1.Start();
        }

        private void printLetters()
        {
            pictureBox.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox.Refresh();
        }

        private void setHeightWidth()
        {
            picture.setHeightWidth(pictureBox.Height, pictureBox.Width);
        }
    }
}