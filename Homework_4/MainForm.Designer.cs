namespace Homework_4
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.labelMode = new System.Windows.Forms.Label();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.labelTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(300, 25);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "結束遊戲";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(75, 25);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 25);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "開始遊戲";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labelMode
            // 
            this.labelMode.AutoSize = true;
            this.labelMode.BackColor = System.Drawing.Color.Transparent;
            this.labelMode.Location = new System.Drawing.Point(15, 430);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(53, 12);
            this.labelMode.TabIndex = 2;
            this.labelMode.Text = "模式選擇";
            // 
            // cbMode
            // 
            this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "玩家 VS 玩家",
            "玩家 VS 電腦"});
            this.cbMode.Location = new System.Drawing.Point(74, 427);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(121, 20);
            this.cbMode.TabIndex = 3;
            // 
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.BackColor = System.Drawing.Color.Transparent;
            this.labelTip.Location = new System.Drawing.Point(325, 430);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(53, 12);
            this.labelTip.TabIndex = 4;
            this.labelTip.Text = "等待中 ...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Homework_4.Properties.Resources.FormBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(480, 457);
            this.Controls.Add(this.labelTip);
            this.Controls.Add(this.cbMode);
            this.Controls.Add(this.labelMode);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnExit);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Homework 4";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label labelMode;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Label labelTip;
    }
}

