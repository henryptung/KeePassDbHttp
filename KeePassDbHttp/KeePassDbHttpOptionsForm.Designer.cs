namespace KeePassDbHttp
{
    partial class KeePassDbHttpOptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeePassDbHttpOptionsForm));
            this.filenameField = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.portField = new System.Windows.Forms.NumericUpDown();
            this.urlDisplay = new System.Windows.Forms.TextBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.copyToClipboard = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.portField)).BeginInit();
            this.SuspendLayout();
            // 
            // filenameField
            // 
            this.filenameField.Location = new System.Drawing.Point(169, 11);
            this.filenameField.Name = "filenameField";
            this.filenameField.Size = new System.Drawing.Size(258, 20);
            this.filenameField.TabIndex = 1;
            this.filenameField.TextChanged += new System.EventHandler(this.filenameField_TextChanged);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(12, 14);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(26, 13);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Port";
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Location = new System.Drawing.Point(114, 14);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(49, 13);
            this.filenameLabel.TabIndex = 3;
            this.filenameLabel.Text = "Filename";
            // 
            // portField
            // 
            this.portField.Location = new System.Drawing.Point(44, 12);
            this.portField.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.portField.Name = "portField";
            this.portField.Size = new System.Drawing.Size(64, 20);
            this.portField.TabIndex = 4;
            this.portField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.portField.ValueChanged += new System.EventHandler(this.portField_ValueChanged);
            // 
            // urlDisplay
            // 
            this.urlDisplay.Location = new System.Drawing.Point(44, 38);
            this.urlDisplay.Name = "urlDisplay";
            this.urlDisplay.ReadOnly = true;
            this.urlDisplay.Size = new System.Drawing.Size(353, 20);
            this.urlDisplay.TabIndex = 5;
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(12, 41);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(29, 13);
            this.urlLabel.TabIndex = 6;
            this.urlLabel.Text = "URL";
            // 
            // copyToClipboard
            // 
            this.copyToClipboard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("copyToClipboard.BackgroundImage")));
            this.copyToClipboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.copyToClipboard.Location = new System.Drawing.Point(403, 38);
            this.copyToClipboard.Name = "copyToClipboard";
            this.copyToClipboard.Size = new System.Drawing.Size(24, 20);
            this.copyToClipboard.TabIndex = 7;
            this.copyToClipboard.UseVisualStyleBackColor = true;
            this.copyToClipboard.Click += new System.EventHandler(this.copyToClipboard_Click);
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(352, 64);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // KeePassDbHttpOptionsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 99);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.copyToClipboard);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.urlDisplay);
            this.Controls.Add(this.portField);
            this.Controls.Add(this.filenameLabel);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.filenameField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "KeePassDbHttpOptionsForm";
            this.ShowIcon = false;
            this.Text = "KeePassDbHttp Options";
            ((System.ComponentModel.ISupportInitialize)(this.portField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox filenameField;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label filenameLabel;
        private System.Windows.Forms.NumericUpDown portField;
        private System.Windows.Forms.TextBox urlDisplay;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Button copyToClipboard;
        private System.Windows.Forms.Button saveButton;
    }
}