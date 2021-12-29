
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
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // windowSizeComboBox
            // 
            this.windowSizeComboBox.FormattingEnabled = true;
            this.windowSizeComboBox.Items.AddRange(new object[] {
            "1024x768",
            "1366x768",
            "1920x1080"});
            this.windowSizeComboBox.Location = new System.Drawing.Point(170, 25);
            this.windowSizeComboBox.Name = "windowSizeComboBox";
            this.windowSizeComboBox.Size = new System.Drawing.Size(121, 24);
            this.windowSizeComboBox.TabIndex = 0;
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(26, 28);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(35, 17);
            this.sizeLabel.TabIndex = 1;
            this.sizeLabel.Text = "Size";
            // 
            // backgroundColorLabel
            // 
            this.backgroundColorLabel.AutoSize = true;
            this.backgroundColorLabel.Location = new System.Drawing.Point(26, 80);
            this.backgroundColorLabel.Name = "backgroundColorLabel";
            this.backgroundColorLabel.Size = new System.Drawing.Size(119, 17);
            this.backgroundColorLabel.TabIndex = 2;
            this.backgroundColorLabel.Text = "Background color";
            // 
            // colorChoosingButton
            // 
            this.colorChoosingButton.Location = new System.Drawing.Point(170, 71);
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
            this.cityLabel.Location = new System.Drawing.Point(26, 132);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(116, 17);
            this.cityLabel.TabIndex = 4;
            this.cityLabel.Text = "City (for weather)";
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(170, 129);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(121, 22);
            this.cityTextBox.TabIndex = 5;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(120, 167);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 35);
            this.applyButton.TabIndex = 7;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 214);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.cityTextBox);
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
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.Button applyButton;
    }
}