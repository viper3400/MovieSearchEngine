namespace TestForm
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
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.lbUrl = new System.Windows.Forms.Label();
            this.lbXPath = new System.Windows.Forms.Label();
            this.tbXPath = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.lboxResult = new System.Windows.Forms.ListBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.gBoxEngines = new System.Windows.Forms.GroupBox();
            this.rBtnPure = new System.Windows.Forms.RadioButton();
            this.rBtnHtmAgility = new System.Windows.Forms.RadioButton();
            this.gBoxEngines.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(71, 12);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(936, 20);
            this.tbUrl.TabIndex = 0;
            this.tbUrl.Text = "http://www.ofdb.de/view.php?page=suchergebnis&SText=Kreis";
            // 
            // lbUrl
            // 
            this.lbUrl.AutoSize = true;
            this.lbUrl.Location = new System.Drawing.Point(17, 15);
            this.lbUrl.Name = "lbUrl";
            this.lbUrl.Size = new System.Drawing.Size(20, 13);
            this.lbUrl.TabIndex = 1;
            this.lbUrl.Text = "Url";
            // 
            // lbXPath
            // 
            this.lbXPath.AutoSize = true;
            this.lbXPath.Location = new System.Drawing.Point(17, 45);
            this.lbXPath.Name = "lbXPath";
            this.lbXPath.Size = new System.Drawing.Size(36, 13);
            this.lbXPath.TabIndex = 3;
            this.lbXPath.Text = "XPath";
            // 
            // tbXPath
            // 
            this.tbXPath.Location = new System.Drawing.Point(71, 42);
            this.tbXPath.Name = "tbXPath";
            this.tbXPath.Size = new System.Drawing.Size(936, 20);
            this.tbXPath.TabIndex = 2;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(1013, 9);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(1013, 38);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lboxResult
            // 
            this.lboxResult.FormattingEnabled = true;
            this.lboxResult.Location = new System.Drawing.Point(20, 134);
            this.lboxResult.Name = "lboxResult";
            this.lboxResult.Size = new System.Drawing.Size(987, 329);
            this.lboxResult.TabIndex = 6;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(1013, 134);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 7;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // gBoxEngines
            // 
            this.gBoxEngines.Controls.Add(this.rBtnHtmAgility);
            this.gBoxEngines.Controls.Add(this.rBtnPure);
            this.gBoxEngines.Location = new System.Drawing.Point(21, 74);
            this.gBoxEngines.Name = "gBoxEngines";
            this.gBoxEngines.Size = new System.Drawing.Size(985, 54);
            this.gBoxEngines.TabIndex = 8;
            this.gBoxEngines.TabStop = false;
            this.gBoxEngines.Text = "Choose engine";
            // 
            // rBtnPure
            // 
            this.rBtnPure.AutoSize = true;
            this.rBtnPure.Location = new System.Drawing.Point(24, 22);
            this.rBtnPure.Name = "rBtnPure";
            this.rBtnPure.Size = new System.Drawing.Size(70, 17);
            this.rBtnPure.TabIndex = 0;
            this.rBtnPure.Text = ".NET Xml";
            this.rBtnPure.UseVisualStyleBackColor = true;
            // 
            // rBtnHtmAgility
            // 
            this.rBtnHtmAgility.AutoSize = true;
            this.rBtnHtmAgility.Checked = true;
            this.rBtnHtmAgility.Location = new System.Drawing.Point(117, 22);
            this.rBtnHtmAgility.Name = "rBtnHtmAgility";
            this.rBtnHtmAgility.Size = new System.Drawing.Size(98, 17);
            this.rBtnHtmAgility.TabIndex = 1;
            this.rBtnHtmAgility.TabStop = true;
            this.rBtnHtmAgility.Text = "HtmlAgilityPack";
            this.rBtnHtmAgility.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 487);
            this.Controls.Add(this.gBoxEngines);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lboxResult);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lbXPath);
            this.Controls.Add(this.tbXPath);
            this.Controls.Add(this.lbUrl);
            this.Controls.Add(this.tbUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gBoxEngines.ResumeLayout(false);
            this.gBoxEngines.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label lbUrl;
        private System.Windows.Forms.Label lbXPath;
        private System.Windows.Forms.TextBox tbXPath;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ListBox lboxResult;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.GroupBox gBoxEngines;
        private System.Windows.Forms.RadioButton rBtnHtmAgility;
        private System.Windows.Forms.RadioButton rBtnPure;
    }
}

