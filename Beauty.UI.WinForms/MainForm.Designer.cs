﻿namespace Beauty.UI.WinForms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ageFromTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ageToTextBox = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(412, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From";
            // 
            // ageFromTextBox
            // 
            this.ageFromTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSource1, "AgeFrom", true));
            this.ageFromTextBox.Location = new System.Drawing.Point(61, 47);
            this.ageFromTextBox.Name = "ageFromTextBox";
            this.ageFromTextBox.Size = new System.Drawing.Size(100, 20);
            this.ageFromTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To";
            // 
            // ageToTextBox
            // 
            this.ageToTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingSource1, "AgeTo", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.ageToTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "AgeTo", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "19", "N2"));
            this.ageToTextBox.Location = new System.Drawing.Point(186, 48);
            this.ageToTextBox.Name = "ageToTextBox";
            this.ageToTextBox.Size = new System.Drawing.Size(100, 20);
            this.ageToTextBox.TabIndex = 2;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Beauty.UI.WinForms.SearchParameters);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 481);
            this.Controls.Add(this.ageToTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ageFromTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ageFromTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ageToTextBox;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}