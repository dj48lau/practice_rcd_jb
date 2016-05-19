namespace RCD.FormWindows
{
    partial class Form1
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
            this.getFiles = new System.Windows.Forms.Button();
            this.text_search = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // getFiles
            // 
            this.getFiles.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.getFiles.Location = new System.Drawing.Point(478, 447);
            this.getFiles.Name = "getFiles";
            this.getFiles.Size = new System.Drawing.Size(75, 23);
            this.getFiles.TabIndex = 1;
            this.getFiles.Text = "Get Files";
            this.getFiles.UseVisualStyleBackColor = true;
            this.getFiles.Click += new System.EventHandler(this.button1_Click);
            // 
            // text_search
            // 
            this.text_search.Location = new System.Drawing.Point(919, 12);
            this.text_search.Name = "text_search";
            this.text_search.Size = new System.Drawing.Size(144, 20);
            this.text_search.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1032, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 500);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.text_search);
            this.Controls.Add(this.getFiles);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button getFiles;
        private System.Windows.Forms.TextBox text_search;
        private System.Windows.Forms.Button button1;
    }
}

