namespace ItcastCaterApp
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnEsc = new System.Windows.Forms.Button();
            this.txtLoginUserName = new System.Windows.Forms.TextBox();
            this.txtUserPwd = new System.Windows.Forms.TextBox();
            this.msgDiv1 = new MsgDiv();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLogin.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(217, 157);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 35);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "登  录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnEsc
            // 
            this.btnEsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEsc.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEsc.ForeColor = System.Drawing.Color.White;
            this.btnEsc.Location = new System.Drawing.Point(327, 157);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Size = new System.Drawing.Size(75, 35);
            this.btnEsc.TabIndex = 1;
            this.btnEsc.Text = "退  出";
            this.btnEsc.UseVisualStyleBackColor = false;
            // 
            // txtLoginUserName
            // 
            this.txtLoginUserName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLoginUserName.Location = new System.Drawing.Point(218, 69);
            this.txtLoginUserName.Multiline = true;
            this.txtLoginUserName.Name = "txtLoginUserName";
            this.txtLoginUserName.Size = new System.Drawing.Size(183, 30);
            this.txtLoginUserName.TabIndex = 2;
            this.txtLoginUserName.Text = "admin";
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserPwd.Location = new System.Drawing.Point(218, 108);
            this.txtUserPwd.Multiline = true;
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.Size = new System.Drawing.Size(183, 30);
            this.txtUserPwd.TabIndex = 2;
            this.txtUserPwd.Text = "admin";
            // 
            // msgDiv1
            // 
            this.msgDiv1.AutoSize = true;
            this.msgDiv1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.msgDiv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msgDiv1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msgDiv1.ForeColor = System.Drawing.Color.Red;
            this.msgDiv1.Location = new System.Drawing.Point(112, 161);
            this.msgDiv1.MaximumSize = new System.Drawing.Size(980, 525);
            this.msgDiv1.Name = "msgDiv1";
            this.msgDiv1.Padding = new System.Windows.Forms.Padding(7);
            this.msgDiv1.Size = new System.Drawing.Size(86, 31);
            this.msgDiv1.TabIndex = 1;
            this.msgDiv1.Text = "msgDiv1";
            this.msgDiv1.Visible = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ItcastCaterApp.Properties.Resources.登录背景;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(432, 265);
            this.Controls.Add(this.msgDiv1);
            this.Controls.Add(this.txtUserPwd);
            this.Controls.Add(this.txtLoginUserName);
            this.Controls.Add(this.btnEsc);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "餐饮管理系统登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnEsc;
        private System.Windows.Forms.TextBox txtLoginUserName;
        private System.Windows.Forms.TextBox txtUserPwd;
        private MsgDiv msgDiv1;
    }
}