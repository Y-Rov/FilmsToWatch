
namespace FilmsToWatch
{
    partial class NewFilmForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.genreTextBox = new System.Windows.Forms.TextBox();
            this.productionTextBox = new System.Windows.Forms.TextBox();
            this.languageTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.directorTextBox = new System.Windows.Forms.TextBox();
            this.actorsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.releaseYearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.runningTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.budgetNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.titileLabel = new System.Windows.Forms.Label();
            this.directorLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.actorsLabel = new System.Windows.Forms.Label();
            this.productionLabel = new System.Windows.Forms.Label();
            this.languageLabel = new System.Windows.Forms.Label();
            this.releaseYearLabel = new System.Windows.Forms.Label();
            this.runningTimeLabel = new System.Windows.Forms.Label();
            this.budgetLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.releaseYearNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.runningTimeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.budgetNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // genreTextBox
            // 
            this.genreTextBox.Location = new System.Drawing.Point(195, 98);
            this.genreTextBox.Name = "genreTextBox";
            this.genreTextBox.Size = new System.Drawing.Size(220, 22);
            this.genreTextBox.TabIndex = 3;
            this.genreTextBox.Text = "Horror";
            this.genreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnteredText);
            // 
            // productionTextBox
            // 
            this.productionTextBox.Location = new System.Drawing.Point(195, 252);
            this.productionTextBox.Name = "productionTextBox";
            this.productionTextBox.Size = new System.Drawing.Size(220, 22);
            this.productionTextBox.TabIndex = 5;
            this.productionTextBox.Text = "New Line Cinema";
            // 
            // languageTextBox
            // 
            this.languageTextBox.Location = new System.Drawing.Point(195, 294);
            this.languageTextBox.Name = "languageTextBox";
            this.languageTextBox.Size = new System.Drawing.Size(220, 22);
            this.languageTextBox.TabIndex = 6;
            this.languageTextBox.Text = "English";
            this.languageTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnteredText);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(195, 22);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(220, 22);
            this.titleTextBox.TabIndex = 1;
            this.titleTextBox.Text = "It Chapter Two";
            // 
            // directorTextBox
            // 
            this.directorTextBox.Location = new System.Drawing.Point(195, 60);
            this.directorTextBox.Name = "directorTextBox";
            this.directorTextBox.Size = new System.Drawing.Size(220, 22);
            this.directorTextBox.TabIndex = 2;
            this.directorTextBox.Text = "Andy Muschietti";
            this.directorTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnteredText);
            // 
            // actorsRichTextBox
            // 
            this.actorsRichTextBox.Location = new System.Drawing.Point(195, 137);
            this.actorsRichTextBox.Name = "actorsRichTextBox";
            this.actorsRichTextBox.Size = new System.Drawing.Size(220, 96);
            this.actorsRichTextBox.TabIndex = 4;
            this.actorsRichTextBox.Text = "Jessica Chastain, James McAvoy, Bill Hader, Isaiah Mustafa, Jay Ryan, James Ranso" +
    "ne, Andy Bean, Bill Skarsgard";
            // 
            // releaseYearNumericUpDown
            // 
            this.releaseYearNumericUpDown.Location = new System.Drawing.Point(195, 330);
            this.releaseYearNumericUpDown.Maximum = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.releaseYearNumericUpDown.Minimum = new decimal(new int[] {
            1888,
            0,
            0,
            0});
            this.releaseYearNumericUpDown.Name = "releaseYearNumericUpDown";
            this.releaseYearNumericUpDown.Size = new System.Drawing.Size(220, 22);
            this.releaseYearNumericUpDown.TabIndex = 7;
            this.releaseYearNumericUpDown.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            // 
            // runningTimeNumericUpDown
            // 
            this.runningTimeNumericUpDown.Location = new System.Drawing.Point(195, 367);
            this.runningTimeNumericUpDown.Maximum = new decimal(new int[] {
            14400,
            0,
            0,
            0});
            this.runningTimeNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.runningTimeNumericUpDown.Name = "runningTimeNumericUpDown";
            this.runningTimeNumericUpDown.Size = new System.Drawing.Size(220, 22);
            this.runningTimeNumericUpDown.TabIndex = 8;
            this.runningTimeNumericUpDown.Value = new decimal(new int[] {
            169,
            0,
            0,
            0});
            // 
            // budgetNumericUpDown
            // 
            this.budgetNumericUpDown.Location = new System.Drawing.Point(195, 413);
            this.budgetNumericUpDown.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.budgetNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.budgetNumericUpDown.Name = "budgetNumericUpDown";
            this.budgetNumericUpDown.Size = new System.Drawing.Size(220, 22);
            this.budgetNumericUpDown.TabIndex = 9;
            this.budgetNumericUpDown.Value = new decimal(new int[] {
            79000000,
            0,
            0,
            0});
            // 
            // titileLabel
            // 
            this.titileLabel.AutoSize = true;
            this.titileLabel.Location = new System.Drawing.Point(150, 25);
            this.titileLabel.Name = "titileLabel";
            this.titileLabel.Size = new System.Drawing.Size(39, 17);
            this.titileLabel.TabIndex = 0;
            this.titileLabel.Text = "Title:";
            // 
            // directorLabel
            // 
            this.directorLabel.AutoSize = true;
            this.directorLabel.Location = new System.Drawing.Point(127, 63);
            this.directorLabel.Name = "directorLabel";
            this.directorLabel.Size = new System.Drawing.Size(62, 17);
            this.directorLabel.TabIndex = 0;
            this.directorLabel.Text = "Director:";
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(137, 101);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(52, 17);
            this.genreLabel.TabIndex = 0;
            this.genreLabel.Text = "Genre:";
            // 
            // actorsLabel
            // 
            this.actorsLabel.AutoSize = true;
            this.actorsLabel.Location = new System.Drawing.Point(137, 173);
            this.actorsLabel.Name = "actorsLabel";
            this.actorsLabel.Size = new System.Drawing.Size(52, 17);
            this.actorsLabel.TabIndex = 0;
            this.actorsLabel.Text = "Actors:";
            // 
            // productionLabel
            // 
            this.productionLabel.AutoSize = true;
            this.productionLabel.Location = new System.Drawing.Point(48, 255);
            this.productionLabel.Name = "productionLabel";
            this.productionLabel.Size = new System.Drawing.Size(141, 17);
            this.productionLabel.TabIndex = 0;
            this.productionLabel.Text = "Production company:";
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(113, 297);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(76, 17);
            this.languageLabel.TabIndex = 0;
            this.languageLabel.Text = "Language:";
            // 
            // releaseYearLabel
            // 
            this.releaseYearLabel.AutoSize = true;
            this.releaseYearLabel.Location = new System.Drawing.Point(93, 332);
            this.releaseYearLabel.Name = "releaseYearLabel";
            this.releaseYearLabel.Size = new System.Drawing.Size(96, 17);
            this.releaseYearLabel.TabIndex = 0;
            this.releaseYearLabel.Text = "Release year:";
            // 
            // runningTimeLabel
            // 
            this.runningTimeLabel.AutoSize = true;
            this.runningTimeLabel.Location = new System.Drawing.Point(16, 369);
            this.runningTimeLabel.Name = "runningTimeLabel";
            this.runningTimeLabel.Size = new System.Drawing.Size(173, 17);
            this.runningTimeLabel.TabIndex = 0;
            this.runningTimeLabel.Text = "Running time (in minutes):";
            // 
            // budgetLabel
            // 
            this.budgetLabel.AutoSize = true;
            this.budgetLabel.Location = new System.Drawing.Point(110, 415);
            this.budgetLabel.Name = "budgetLabel";
            this.budgetLabel.Size = new System.Drawing.Size(79, 17);
            this.budgetLabel.TabIndex = 0;
            this.budgetLabel.Text = "Budget ($):";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(195, 457);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(90, 30);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // NewFilmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 499);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.budgetLabel);
            this.Controls.Add(this.runningTimeLabel);
            this.Controls.Add(this.releaseYearLabel);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.productionLabel);
            this.Controls.Add(this.actorsLabel);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.directorLabel);
            this.Controls.Add(this.titileLabel);
            this.Controls.Add(this.budgetNumericUpDown);
            this.Controls.Add(this.runningTimeNumericUpDown);
            this.Controls.Add(this.releaseYearNumericUpDown);
            this.Controls.Add(this.actorsRichTextBox);
            this.Controls.Add(this.directorTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.languageTextBox);
            this.Controls.Add(this.productionTextBox);
            this.Controls.Add(this.genreTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(528, 546);
            this.Name = "NewFilmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New film";
            ((System.ComponentModel.ISupportInitialize)(this.releaseYearNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.runningTimeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.budgetNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox genreTextBox;
        private System.Windows.Forms.TextBox productionTextBox;
        private System.Windows.Forms.TextBox languageTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox directorTextBox;
        private System.Windows.Forms.RichTextBox actorsRichTextBox;
        private System.Windows.Forms.NumericUpDown releaseYearNumericUpDown;
        private System.Windows.Forms.NumericUpDown runningTimeNumericUpDown;
        private System.Windows.Forms.NumericUpDown budgetNumericUpDown;
        private System.Windows.Forms.Label titileLabel;
        private System.Windows.Forms.Label directorLabel;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.Label actorsLabel;
        private System.Windows.Forms.Label productionLabel;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.Label releaseYearLabel;
        private System.Windows.Forms.Label runningTimeLabel;
        private System.Windows.Forms.Label budgetLabel;
        private System.Windows.Forms.Button addButton;
    }
}