using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AlternativeLetters
{
    public partial class Form : System.Windows.Forms.Form
    {
        private readonly LetterCalc letterCalc = new();
        private readonly Stopwatch readingTime = new();
        private bool paused = true;
        private Font? readingFont;

        public Form()
        {
            InitializeComponent();
            modeBox.SelectedIndex = 0;
            UpdateFont();
            UpdateOutput();
        }

        private bool Experimental => modeBox.SelectedIndex == 1;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ResetReadingSession();
            UpdateOutput();
        }

        private void UpdateOutput()
        {
            string text = tbInput.Text;
            int count = Regex.Matches(text, @"\S+").Count;
            countLabel.Text = $"{count} {(count == 1 ? "word" : "words")}";
            reader.Text = text;
            if (Experimental)
                pictureBox.SetWords(letterCalc.updateInput(text.Replace("\r\n", "\n").Replace('\r', '\n')));
            timer1.Enabled = Experimental && !paused && pictureBox.HasAnimation;
        }

        private void modeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetReadingSession();
            reader.Visible = !Experimental;
            pictureBox.Visible = Experimental;
            pauseButton.Enabled = Experimental;
            speedBox.Enabled = Experimental;
            modeHint.Text = Experimental
                ? "Experimental: letters and vowel colors alternate (A orange, E blue, I yellow, O green, U light green). Use the original text for the full wording."
                : "Full text stays available for rereading and selection.";
            UpdateOutput();
        }

        private void timer1_Tick(object sender, EventArgs e) => pictureBox.AdvanceFrame();

        private void pauseButton_Click(object sender, EventArgs e)
        {
            paused = !paused;
            pauseButton.Text = paused ? "Play animation" : "Pause animation";
            timer1.Enabled = Experimental && !paused && pictureBox.HasAnimation;
        }

        private void speedBox_ValueChanged(object sender, EventArgs e) => timer1.Interval = (int)speedBox.Value;

        private void fontSizeBox_ValueChanged(object sender, EventArgs e) => UpdateFont();

        private void UpdateFont()
        {
            var oldFont = readingFont;
            readingFont = new Font(FontFamily.GenericMonospace, (float)fontSizeBox.Value);
            reader.Font = readingFont;
            pictureBox.Font = readingFont;
            oldFont?.Dispose();
        }

        private void sessionButton_Click(object sender, EventArgs e)
        {
            if (readingTime.IsRunning)
            {
                readingTime.Stop();
                double seconds = readingTime.Elapsed.TotalSeconds;
                int count = Regex.Matches(tbInput.Text, @"\S+").Count;
                sessionLabel.Text = seconds < 1 ? "Read for at least one second to measure." :
                    $"{seconds:0.0} s · {count * 60 / seconds:0} words/min (approx.) · Check what you understood.";
                sessionButton.Text = "Start reading timer";
            }
            else if (!string.IsNullOrWhiteSpace(tbInput.Text))
            {
                readingTime.Restart();
                sessionLabel.Text = "Timing… Select the button again when finished.";
                sessionButton.Text = "Finish reading";
                if (Experimental) pictureBox.Focus(); else reader.Focus();
            }
            else
            {
                sessionLabel.Text = "Enter text before starting the timer.";
            }
        }

        private void ResetReadingSession()
        {
            readingTime.Reset();
            sessionButton.Text = "Start reading timer";
            sessionLabel.Text = "Time your reading and check comprehension yourself.";
        }
    }
}
