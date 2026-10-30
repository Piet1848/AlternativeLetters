namespace AlternativeLetters
{
    partial class Form
    {
        private System.ComponentModel.IContainer components = null!;
        private TextBox tbInput = null!;
        private Picture pictureBox = null!;
        private RichTextBox reader = null!;
        private System.Windows.Forms.Timer timer1 = null!;
        private Button pauseButton = null!, sessionButton = null!;
        private ComboBox modeBox = null!;
        private NumericUpDown fontSizeBox = null!, speedBox = null!;
        private Label countLabel = null!, modeHint = null!, sessionLabel = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing) { components?.Dispose(); readingFont?.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tbInput = new TextBox();
            pictureBox = new Picture();
            reader = new RichTextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            pauseButton = new Button();
            sessionButton = new Button();
            modeBox = new ComboBox();
            fontSizeBox = new NumericUpDown();
            speedBox = new NumericUpDown();
            countLabel = new Label();
            modeHint = new Label();
            sessionLabel = new Label();
            var layout = new TableLayoutPanel();
            var inputHeader = new FlowLayoutPanel();
            var controls = new FlowLayoutPanel();
            var sessionBar = new FlowLayoutPanel();
            var output = new Panel();
            SuspendLayout();

            layout.Dock = DockStyle.Fill;
            layout.Padding = new Padding(16);
            layout.ColumnCount = 1;
            layout.RowCount = 6;
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            inputHeader.Dock = DockStyle.Fill;
            inputHeader.AutoSize = true;
            inputHeader.Controls.Add(MakeLabel("Your text", true));
            countLabel.AutoSize = true;
            countLabel.ForeColor = Color.Silver;
            countLabel.Margin = new Padding(16, 3, 0, 4);
            inputHeader.Controls.Add(countLabel);
            tbInput.Dock = DockStyle.Fill;
            tbInput.Multiline = true;
            tbInput.AcceptsReturn = true;
            tbInput.ScrollBars = ScrollBars.Vertical;
            tbInput.BackColor = Color.FromArgb(42, 42, 42);
            tbInput.ForeColor = Color.White;
            tbInput.BorderStyle = BorderStyle.FixedSingle;
            tbInput.Font = new Font(FontFamily.GenericSansSerif, 12F);
            tbInput.AccessibleName = "Text to read";
            tbInput.TextChanged += textBox1_TextChanged;

            controls.AutoSize = true;
            controls.Dock = DockStyle.Fill;
            controls.WrapContents = true;
            controls.Padding = new Padding(0, 8, 0, 2);
            controls.Controls.Add(MakeLabel("View"));
            modeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            modeBox.Width = 155;
            modeBox.Items.AddRange(new object[] { "Original text", "Alternative letters" });
            modeBox.AccessibleName = "Reading view";
            modeBox.SelectedIndexChanged += modeBox_SelectedIndexChanged;
            controls.Controls.Add(modeBox);
            controls.Controls.Add(MakeLabel("Text size"));
            fontSizeBox.Minimum = 12; fontSizeBox.Maximum = 36; fontSizeBox.Value = 20;
            fontSizeBox.Width = 55; fontSizeBox.AccessibleName = "Text size in points";
            fontSizeBox.ValueChanged += fontSizeBox_ValueChanged;
            controls.Controls.Add(fontSizeBox);
            pauseButton.Text = "Play animation";
            pauseButton.AutoSize = true;
            pauseButton.Click += pauseButton_Click;
            controls.Controls.Add(pauseButton);
            controls.Controls.Add(MakeLabel("Frame ms"));
            speedBox.Minimum = 100; speedBox.Maximum = 2000; speedBox.Increment = 50; speedBox.Value = 175;
            speedBox.Width = 65; speedBox.AccessibleName = "Animation frame duration in milliseconds";
            speedBox.ValueChanged += speedBox_ValueChanged;
            controls.Controls.Add(speedBox);
            modeHint.AutoSize = true;
            modeHint.ForeColor = Color.Silver;
            modeHint.Margin = new Padding(3, 2, 3, 8);
            layout.SizeChanged += (sender, e) => modeHint.MaximumSize = new Size(Math.Max(100, layout.ClientSize.Width - 40), 0);

            output.Dock = DockStyle.Fill;
            reader.Dock = DockStyle.Fill;
            reader.ReadOnly = true;
            reader.BorderStyle = BorderStyle.None;
            reader.BackColor = Color.FromArgb(32, 32, 32);
            reader.ForeColor = Color.White;
            reader.ScrollBars = RichTextBoxScrollBars.Vertical;
            reader.AccessibleName = "Original text reading view";
            pictureBox.Dock = DockStyle.Fill;
            output.Controls.Add(reader);
            output.Controls.Add(pictureBox);

            sessionBar.AutoSize = true;
            sessionBar.Dock = DockStyle.Fill;
            sessionBar.WrapContents = true;
            sessionBar.Padding = new Padding(0, 8, 0, 0);
            sessionButton.Text = "Start reading timer";
            sessionButton.AutoSize = true;
            sessionButton.Click += sessionButton_Click;
            sessionBar.Controls.Add(sessionButton);
            sessionLabel.AutoSize = true;
            sessionLabel.ForeColor = Color.Silver;
            sessionLabel.Margin = new Padding(12, 7, 0, 0);
            sessionBar.Controls.Add(sessionLabel);

            layout.Controls.Add(inputHeader, 0, 0);
            layout.Controls.Add(tbInput, 0, 1);
            layout.Controls.Add(controls, 0, 2);
            layout.Controls.Add(modeHint, 0, 3);
            layout.Controls.Add(output, 0, 4);
            layout.Controls.Add(sessionBar, 0, 5);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ForeColor = Color.White;
            ClientSize = new Size(1100, 700);
            MinimumSize = new Size(500, 440);
            Controls.Add(layout);
            Text = "Alternative Letters";
            ResumeLayout(false);
        }

        private Label MakeLabel(string text, bool bold = false)
        {
            return new Label { Text = text, AutoSize = true, Margin = new Padding(3, 6, 6, 3),
                Font = bold ? new Font(Font, FontStyle.Bold) : Font };
        }
    }
}
