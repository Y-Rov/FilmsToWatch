
namespace FilmsToWatch
{
    partial class SettingsForm
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
            this.windowSizeComboBox = new System.Windows.Forms.ComboBox();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.backgroundColorLabel = new System.Windows.Forms.Label();
            this.backgroundColorDialog = new System.Windows.Forms.ColorDialog();
            this.colorChoosingButton = new System.Windows.Forms.Button();
            this.cityLabel = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.backgroundPictureBox = new System.Windows.Forms.PictureBox();
            this.weatherCityComboBox = new System.Windows.Forms.ComboBox();
            this.unknownCityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // windowSizeComboBox
            // 
            this.windowSizeComboBox.FormattingEnabled = true;
            this.windowSizeComboBox.Items.AddRange(new object[] {
            "1024x768",
            "1366x768",
            "1920x1080"});
            this.windowSizeComboBox.Location = new System.Drawing.Point(112, 19);
            this.windowSizeComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.windowSizeComboBox.Name = "windowSizeComboBox";
            this.windowSizeComboBox.Size = new System.Drawing.Size(171, 21);
            this.windowSizeComboBox.TabIndex = 0;
            this.windowSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.WindowSizeComboBox_SelectedIndexChanged);
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(20, 21);
            this.sizeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(27, 13);
            this.sizeLabel.TabIndex = 1;
            this.sizeLabel.Text = "Size";
            // 
            // backgroundColorLabel
            // 
            this.backgroundColorLabel.AutoSize = true;
            this.backgroundColorLabel.Location = new System.Drawing.Point(20, 63);
            this.backgroundColorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.backgroundColorLabel.Name = "backgroundColorLabel";
            this.backgroundColorLabel.Size = new System.Drawing.Size(91, 13);
            this.backgroundColorLabel.TabIndex = 2;
            this.backgroundColorLabel.Text = "Background color";
            // 
            // backgroundColorDialog
            // 
            this.backgroundColorDialog.AnyColor = true;
            this.backgroundColorDialog.Color = System.Drawing.SystemColors.InactiveCaption;
            this.backgroundColorDialog.FullOpen = true;
            // 
            // colorChoosingButton
            // 
            this.colorChoosingButton.Location = new System.Drawing.Point(196, 56);
            this.colorChoosingButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.colorChoosingButton.Name = "colorChoosingButton";
            this.colorChoosingButton.Size = new System.Drawing.Size(56, 28);
            this.colorChoosingButton.TabIndex = 3;
            this.colorChoosingButton.Text = "Choose";
            this.colorChoosingButton.UseVisualStyleBackColor = true;
            this.colorChoosingButton.Click += new System.EventHandler(this.ColorChoosingButton_Click);
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(20, 106);
            this.cityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(86, 13);
            this.cityLabel.TabIndex = 4;
            this.cityLabel.Text = "City (for weather)";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(124, 152);
            this.applyButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(56, 28);
            this.applyButton.TabIndex = 7;
            this.applyButton.Text = "Save";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // backgroundPictureBox
            // 
            this.backgroundPictureBox.Location = new System.Drawing.Point(161, 56);
            this.backgroundPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backgroundPictureBox.Name = "backgroundPictureBox";
            this.backgroundPictureBox.Size = new System.Drawing.Size(26, 28);
            this.backgroundPictureBox.TabIndex = 8;
            this.backgroundPictureBox.TabStop = false;
            // 
            // weatherCityComboBox
            // 
            this.weatherCityComboBox.FormattingEnabled = true;
            this.weatherCityComboBox.Items.AddRange(new object[] {
            "Ivano-Frankivsk",
            "Lviv",
            "Kyiv",
            "Dnipro",
            "Kharkiv"});
            this.weatherCityComboBox.Location = new System.Drawing.Point(112, 103);
            this.weatherCityComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.weatherCityComboBox.Name = "weatherCityComboBox";
            this.weatherCityComboBox.Size = new System.Drawing.Size(171, 21);
            this.weatherCityComboBox.TabIndex = 9;
            // 
            // unknownCityLabel
            // 
            this.unknownCityLabel.AutoSize = true;
            this.unknownCityLabel.ForeColor = System.Drawing.Color.Red;
            this.unknownCityLabel.Location = new System.Drawing.Point(110, 125);
            this.unknownCityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.unknownCityLabel.Name = "unknownCityLabel";
            this.unknownCityLabel.Size = new System.Drawing.Size(194, 13);
            this.unknownCityLabel.TabIndex = 10;
            this.unknownCityLabel.Text = "This city is unknown for weather server!";
            this.unknownCityLabel.Visible = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 190);
            this.Controls.Add(this.unknownCityLabel);
            this.Controls.Add(this.weatherCityComboBox);
            this.Controls.Add(this.backgroundPictureBox);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.colorChoosingButton);
            this.Controls.Add(this.backgroundColorLabel);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.windowSizeComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings (Main window)";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox windowSizeComboBox;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Label backgroundColorLabel;
        private System.Windows.Forms.ColorDialog backgroundColorDialog;
        private System.Windows.Forms.Button colorChoosingButton;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.PictureBox backgroundPictureBox;
        private System.Windows.Forms.ComboBox weatherCityComboBox;
        private System.Windows.Forms.Label unknownCityLabel;
    }
}