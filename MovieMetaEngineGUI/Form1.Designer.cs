namespace MovieMetaEngineGUI
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
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnSearchEAN = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnSearchTitle = new System.Windows.Forms.Button();
            this.btnSearchId = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(12, 12);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(249, 20);
            this.tbSearch.TabIndex = 0;
            // 
            // btnSearchEAN
            // 
            this.btnSearchEAN.Location = new System.Drawing.Point(267, 10);
            this.btnSearchEAN.Name = "btnSearchEAN";
            this.btnSearchEAN.Size = new System.Drawing.Size(75, 23);
            this.btnSearchEAN.TabIndex = 1;
            this.btnSearchEAN.Text = "Search Ean";
            this.btnSearchEAN.UseVisualStyleBackColor = true;
            this.btnSearchEAN.Click += new System.EventHandler(this.btnSearchEAN_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(14, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(537, 238);
            this.listBox1.TabIndex = 2;
            // 
            // btnSearchTitle
            // 
            this.btnSearchTitle.Location = new System.Drawing.Point(348, 10);
            this.btnSearchTitle.Name = "btnSearchTitle";
            this.btnSearchTitle.Size = new System.Drawing.Size(75, 23);
            this.btnSearchTitle.TabIndex = 3;
            this.btnSearchTitle.Text = "Search Title";
            this.btnSearchTitle.UseVisualStyleBackColor = true;
            this.btnSearchTitle.Click += new System.EventHandler(this.btnSearchTitle_Click);
            // 
            // btnSearchId
            // 
            this.btnSearchId.Location = new System.Drawing.Point(429, 10);
            this.btnSearchId.Name = "btnSearchId";
            this.btnSearchId.Size = new System.Drawing.Size(75, 23);
            this.btnSearchId.TabIndex = 4;
            this.btnSearchId.Text = "Search Id";
            this.btnSearchId.UseVisualStyleBackColor = true;
            this.btnSearchId.Click += new System.EventHandler(this.btnSearchId_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 662);
            this.Controls.Add(this.btnSearchId);
            this.Controls.Add(this.btnSearchTitle);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSearchEAN);
            this.Controls.Add(this.tbSearch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnSearchEAN;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnSearchTitle;
        private System.Windows.Forms.Button btnSearchId;
    }
}

