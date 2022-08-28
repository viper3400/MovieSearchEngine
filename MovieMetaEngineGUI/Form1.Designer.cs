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
            this.cBEngine = new System.Windows.Forms.ComboBox();
            this.tbApiKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(13, 42);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(365, 22);
            this.tbSearch.TabIndex = 0;
            // 
            // btnSearchEAN
            // 
            this.btnSearchEAN.Location = new System.Drawing.Point(13, 72);
            this.btnSearchEAN.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchEAN.Name = "btnSearchEAN";
            this.btnSearchEAN.Size = new System.Drawing.Size(100, 28);
            this.btnSearchEAN.TabIndex = 1;
            this.btnSearchEAN.Text = "Search Ean";
            this.btnSearchEAN.UseVisualStyleBackColor = true;
            this.btnSearchEAN.Click += new System.EventHandler(this.btnSearchEAN_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(13, 119);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1052, 292);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // btnSearchTitle
            // 
            this.btnSearchTitle.Location = new System.Drawing.Point(121, 72);
            this.btnSearchTitle.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchTitle.Name = "btnSearchTitle";
            this.btnSearchTitle.Size = new System.Drawing.Size(100, 28);
            this.btnSearchTitle.TabIndex = 3;
            this.btnSearchTitle.Text = "Search Title";
            this.btnSearchTitle.UseVisualStyleBackColor = true;
            this.btnSearchTitle.Click += new System.EventHandler(this.btnSearchTitle_Click);
            // 
            // btnSearchId
            // 
            this.btnSearchId.Location = new System.Drawing.Point(229, 72);
            this.btnSearchId.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchId.Name = "btnSearchId";
            this.btnSearchId.Size = new System.Drawing.Size(100, 28);
            this.btnSearchId.TabIndex = 4;
            this.btnSearchId.Text = "Search Id";
            this.btnSearchId.UseVisualStyleBackColor = true;
            this.btnSearchId.Click += new System.EventHandler(this.btnSearchId_Click);
            // 
            // cBEngine
            // 
            this.cBEngine.FormattingEnabled = true;
            this.cBEngine.Items.AddRange(new object[] {
            "Ofdb",
            "TheMovieDb"});
            this.cBEngine.Location = new System.Drawing.Point(386, 42);
            this.cBEngine.Margin = new System.Windows.Forms.Padding(4);
            this.cBEngine.Name = "cBEngine";
            this.cBEngine.Size = new System.Drawing.Size(205, 24);
            this.cBEngine.TabIndex = 5;
            // 
            // tbApiKey
            // 
            this.tbApiKey.Location = new System.Drawing.Point(599, 42);
            this.tbApiKey.Margin = new System.Windows.Forms.Padding(4);
            this.tbApiKey.Name = "tbApiKey";
            this.tbApiKey.Size = new System.Drawing.Size(466, 22);
            this.tbApiKey.TabIndex = 6;
            this.tbApiKey.TextChanged += new System.EventHandler(this.tbApiKey_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search Term";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search Engine";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(596, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "API Key";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 815);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbApiKey);
            this.Controls.Add(this.cBEngine);
            this.Controls.Add(this.btnSearchId);
            this.Controls.Add(this.btnSearchTitle);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSearchEAN);
            this.Controls.Add(this.tbSearch);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.ComboBox cBEngine;
        private System.Windows.Forms.TextBox tbApiKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

