
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
            this.windowSizeComboBox.Location = new System.Drawing.Point(149, 23);
            this.windowSizeComboBox.Name = "windowSizeComboBox";
            this.windowSizeComboBox.Size = new System.Drawing.Size(227, 24);
            this.windowSizeComboBox.TabIndex = 0;
            this.windowSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.WindowSizeComboBox_SelectedIndexChanged);
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(27, 26);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(35, 17);
            this.sizeLabel.TabIndex = 1;
            this.sizeLabel.Text = "Size";
            // 
            // backgroundColorLabel
            // 
            this.backgroundColorLabel.AutoSize = true;
            this.backgroundColorLabel.Location = new System.Drawing.Point(27, 78);
            this.backgroundColorLabel.Name = "backgroundColorLabel";
            this.backgroundColorLabel.Size = new System.Drawing.Size(119, 17);
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
            this.colorChoosingButton.Location = new System.Drawing.Point(261, 69);
            this.colorChoosingButton.Name = "colorChoosingButton";
            this.colorChoosingButton.Size = new System.Drawing.Size(75, 35);
            this.colorChoosingButton.TabIndex = 3;
            this.colorChoosingButton.Text = "Choose";
            this.colorChoosingButton.UseVisualStyleBackColor = true;
            this.colorChoosingButton.Click += new System.EventHandler(this.ColorChoosingButton_Click);
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(27, 130);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(116, 17);
            this.cityLabel.TabIndex = 4;
            this.cityLabel.Text = "City (for weather)";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(165, 187);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 35);
            this.applyButton.TabIndex = 7;
            this.applyButton.Text = "Save";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // backgroundPictureBox
            // 
            this.backgroundPictureBox.Location = new System.Drawing.Point(215, 69);
            this.backgroundPictureBox.Name = "backgroundPictureBox";
            this.backgroundPictureBox.Size = new System.Drawing.Size(35, 35);
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
            this.weatherCityComboBox.Location = new System.Drawing.Point(149, 127);
            this.weatherCityComboBox.Name = "weatherCityComboBox";
            this.weatherCityComboBox.Size = new System.Drawing.Size(227, 24);
            this.weatherCityComboBox.TabIndex = 9;
            // 
            // unknownCityLabel
            // 
            this.unknownCityLabel.AutoSize = true;
            this.unknownCityLabel.ForeColor = System.Drawing.Color.Red;
            this.unknownCityLabel.Location = new System.Drawing.Point(146, 154);
            this.unknownCityLabel.Name = "unknownCityLabel";
            this.unknownCityLabel.Size = new System.Drawing.Size(256, 17);
            this.unknownCityLabel.TabIndex = 10;
            this.unknownCityLabel.Text = "This city is unknown for weather server!";
            this.unknownCityLabel.Visible = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 234);
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