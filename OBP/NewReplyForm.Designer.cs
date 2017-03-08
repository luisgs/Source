﻿namespace OBP
{
    partial class NewReplyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewReplyForm));
            this.label1 = new System.Windows.Forms.Label();
            this.languageListBox = new System.Windows.Forms.CheckedListBox();
            this.validateLanguageButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose your language:";
            // 
            // languageListBox
            // 
            this.languageListBox.CheckOnClick = true;
            this.languageListBox.ColumnWidth = 70;
            this.languageListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.languageListBox.FormattingEnabled = true;
            this.languageListBox.Location = new System.Drawing.Point(3, 23);
            this.languageListBox.MinimumSize = new System.Drawing.Size(200, 50);
            this.languageListBox.MultiColumn = true;
            this.languageListBox.Name = "languageListBox";
            this.languageListBox.Size = new System.Drawing.Size(333, 82);
            this.languageListBox.TabIndex = 0;
            this.languageListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.languageListBox_ItemCheck);
            // 
            // validateLanguageButton
            // 
            this.validateLanguageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.validateLanguageButton.Location = new System.Drawing.Point(226, 112);
            this.validateLanguageButton.Name = "validateLanguageButton";
            this.validateLanguageButton.Size = new System.Drawing.Size(110, 23);
            this.validateLanguageButton.TabIndex = 2;
            this.validateLanguageButton.Text = "Compose email";
            this.validateLanguageButton.UseVisualStyleBackColor = true;
            this.validateLanguageButton.Click += new System.EventHandler(this.validateLanguageButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 339F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.validateLanguageButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.languageListBox, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(339, 138);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // NewReplyForm
            // 
            this.AcceptButton = this.validateLanguageButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(367, 164);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "NewReplyForm";
            this.Text = "New reply";
            this.Load += new System.EventHandler(this.NewReplyForm_Load);
            this.Shown += new System.EventHandler(this.NewReplyForm_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox languageListBox;
        private System.Windows.Forms.Button validateLanguageButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}