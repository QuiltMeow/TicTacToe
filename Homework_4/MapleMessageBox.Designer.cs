namespace Homework_4
{
    partial class MapleMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapleMessageBox));
            this.labelMessage = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.BackColor = System.Drawing.Color.Transparent;
            this.labelMessage.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelMessage.ForeColor = System.Drawing.Color.White;
            this.labelMessage.Location = new System.Drawing.Point(25, 45);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(155, 17);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "訊息文字 MESSAGE TEXT";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Image = global::Homework_4.MapleMessageBoxResource.ButtonOKNormal;
            this.btnOK.Location = new System.Drawing.Point(205, 100);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(41, 17);
            this.btnOK.TabIndex = 1;
            this.btnOK.TabStop = false;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.EnabledChanged += new System.EventHandler(this.btnOK_EnabledChanged);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOK_MouseDown);
            this.btnOK.MouseEnter += new System.EventHandler(this.btnOK_MouseEnter);
            this.btnOK.MouseLeave += new System.EventHandler(this.btnOK_MouseLeave);
            // 
            // MapleMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Homework_4.MapleMessageBoxResource.MessageBox;
            this.ClientSize = new System.Drawing.Size(260, 131);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelMessage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapleMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "MapleMessageBox";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.MapleMessageBox_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapleMessageBox_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button btnOK;
    }
}