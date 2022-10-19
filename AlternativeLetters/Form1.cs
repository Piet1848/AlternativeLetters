using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace AlternativeLetters
{
    public partial class Form1 : Form
    {
        LetterCalc letterCalc;
        Picture picture;
        List<Letter> letters;

        public Form1()
        {
            InitializeComponent();
            letterCalc = new LetterCalc();
            letters = letterCalc.updateInput(tbInput.Text);
            picture = new Picture(pictureBox.Height, pictureBox.Width);
            picture.setFrames(letters);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            pictureBox.Paint += (s, ev) =>
            {
                ev.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                ev.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                picture.Render(ev.Graphics, pictureBox);
            };
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            letters = letterCalc.updateInput(tbInput.Text);
            picture.setFrames(letters);
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
    }
}