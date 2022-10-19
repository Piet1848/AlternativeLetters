namespace AlternativeLetters
{
    public partial class Form1 : Form
    {
        LetterCalc letterCalc;
        List<Letter> letters;

        public Form1()
        {
            InitializeComponent();
            letterCalc = new LetterCalc();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            letters = letterCalc.updateInput(tbInput.Text);
           
            Thread thread = new Thread(new ThreadStart(printLetters));
            thread.Start();
        }

        private void printLetters()
        {
            int counter = 0;
            while (true)
            {
                DateTime startTime = DateTime.Now;
                
                tbOutput.Text = "";

                while ((DateTime.Now - startTime).TotalMilliseconds < 200)
                {

                }
            }
        }
    }
}