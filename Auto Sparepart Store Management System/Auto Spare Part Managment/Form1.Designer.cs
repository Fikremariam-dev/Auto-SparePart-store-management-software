namespace Auto_Spare_Part_managment
{
    partial class Start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loginAsAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginAsAdminToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loginAsEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginAsAdminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(512, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loginAsAdminToolStripMenuItem
            // 
            this.loginAsAdminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginAsAdminToolStripMenuItem1,
            this.loginAsEmployeeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.loginAsAdminToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginAsAdminToolStripMenuItem.Name = "loginAsAdminToolStripMenuItem";
            this.loginAsAdminToolStripMenuItem.Size = new System.Drawing.Size(60, 25);
            this.loginAsAdminToolStripMenuItem.Text = "Start";
            // 
            // loginAsAdminToolStripMenuItem1
            // 
            this.loginAsAdminToolStripMenuItem1.Name = "loginAsAdminToolStripMenuItem1";
            this.loginAsAdminToolStripMenuItem1.Size = new System.Drawing.Size(222, 26);
            this.loginAsAdminToolStripMenuItem1.Text = "Login as Admin";
            this.loginAsAdminToolStripMenuItem1.Click += new System.EventHandler(this.loginAsAdminToolStripMenuItem1_Click);
            // 
            // loginAsEmployeeToolStripMenuItem
            // 
            this.loginAsEmployeeToolStripMenuItem.Name = "loginAsEmployeeToolStripMenuItem";
            this.loginAsEmployeeToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.loginAsEmployeeToolStripMenuItem.Text = "Login as Employee";
            this.loginAsEmployeeToolStripMenuItem.Click += new System.EventHandler(this.loginAsEmployeeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Auto Spare Part Managment System";
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(512, 219);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Spare Part Managment System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Start_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loginAsAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginAsAdminToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loginAsEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

