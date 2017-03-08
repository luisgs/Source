namespace OBP
{
    partial class ConfigurationForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.consultantNameTextBox = new System.Windows.Forms.TextBox();
            this.templateDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.salesForceTrackingAddressTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.selectedLanguagesListBox = new System.Windows.Forms.CheckedListBox();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.consultantNameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.templateDirectoryTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.salesForceTrackingAddressTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.selectedLanguagesListBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.saveSettingsButton, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(625, 209);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "SFDC tracking address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 102);
            this.label4.TabIndex = 3;
            this.label4.Text = "Languages:";
            // 
            // consultantNameTextBox
            // 
            this.consultantNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consultantNameTextBox.Location = new System.Drawing.Point(128, 3);
            this.consultantNameTextBox.Name = "consultantNameTextBox";
            this.consultantNameTextBox.Size = new System.Drawing.Size(494, 20);
            this.consultantNameTextBox.TabIndex = 4;
            // 
            // templateDirectoryTextBox
            // 
            this.templateDirectoryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateDirectoryTextBox.Location = new System.Drawing.Point(128, 29);
            this.templateDirectoryTextBox.Name = "templateDirectoryTextBox";
            this.templateDirectoryTextBox.Size = new System.Drawing.Size(494, 20);
            this.templateDirectoryTextBox.TabIndex = 5;
            // 
            // salesForceTrackingAddressTextBox
            // 
            this.salesForceTrackingAddressTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salesForceTrackingAddressTextBox.Location = new System.Drawing.Point(128, 55);
            this.salesForceTrackingAddressTextBox.Name = "salesForceTrackingAddressTextBox";
            this.salesForceTrackingAddressTextBox.Size = new System.Drawing.Size(494, 20);
            this.salesForceTrackingAddressTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Path to email templates:";
            // 
            // selectedLanguagesListBox
            // 
            this.selectedLanguagesListBox.CheckOnClick = true;
            this.selectedLanguagesListBox.ColumnWidth = 70;
            this.selectedLanguagesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedLanguagesListBox.FormattingEnabled = true;
            this.selectedLanguagesListBox.Location = new System.Drawing.Point(128, 81);
            this.selectedLanguagesListBox.MultiColumn = true;
            this.selectedLanguagesListBox.Name = "selectedLanguagesListBox";
            this.selectedLanguagesListBox.Size = new System.Drawing.Size(494, 96);
            this.selectedLanguagesListBox.TabIndex = 7;
            this.selectedLanguagesListBox.SelectedIndexChanged += new System.EventHandler(this.languageListBox_SelectedIndexChanged);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveSettingsButton.Location = new System.Drawing.Point(547, 183);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.saveSettingsButton.TabIndex = 8;
            this.saveSettingsButton.Text = "Save";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this.saveSettingsButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(658, 242);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConfigurationForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Technical Presales add-in settings";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox consultantNameTextBox;
        private System.Windows.Forms.TextBox templateDirectoryTextBox;
        private System.Windows.Forms.TextBox salesForceTrackingAddressTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox selectedLanguagesListBox;
        private System.Windows.Forms.Button saveSettingsButton;
    }
}