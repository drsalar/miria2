namespace app1
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.accountL = new System.Windows.Forms.Label();
            this.pwdL = new System.Windows.Forms.Label();
            this.accountTB = new System.Windows.Forms.TextBox();
            this.pwdTB = new System.Windows.Forms.TextBox();
            this.loginBt = new System.Windows.Forms.Button();
            this.accountErr = new System.Windows.Forms.Label();
            this.pwdErr = new System.Windows.Forms.Label();
            this.loginErr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accountL
            // 
            this.accountL.AutoSize = true;
            this.accountL.Location = new System.Drawing.Point(110, 89);
            this.accountL.Name = "accountL";
            this.accountL.Size = new System.Drawing.Size(41, 12);
            this.accountL.TabIndex = 0;
            this.accountL.Text = "账号：";
            // 
            // pwdL
            // 
            this.pwdL.AutoSize = true;
            this.pwdL.Location = new System.Drawing.Point(110, 166);
            this.pwdL.Name = "pwdL";
            this.pwdL.Size = new System.Drawing.Size(41, 12);
            this.pwdL.TabIndex = 1;
            this.pwdL.Text = "密码：";
            this.pwdL.Click += new System.EventHandler(this.pwdL_Click);
            // 
            // accountTB
            // 
            this.accountTB.Location = new System.Drawing.Point(168, 86);
            this.accountTB.Name = "accountTB";
            this.accountTB.Size = new System.Drawing.Size(143, 21);
            this.accountTB.TabIndex = 2;
            // 
            // pwdTB
            // 
            this.pwdTB.Location = new System.Drawing.Point(168, 163);
            this.pwdTB.Name = "pwdTB";
            this.pwdTB.Size = new System.Drawing.Size(143, 21);
            this.pwdTB.TabIndex = 3;
            // 
            // loginBt
            // 
            this.loginBt.Location = new System.Drawing.Point(150, 241);
            this.loginBt.Name = "loginBt";
            this.loginBt.Size = new System.Drawing.Size(75, 23);
            this.loginBt.TabIndex = 4;
            this.loginBt.Text = "登录";
            this.loginBt.UseVisualStyleBackColor = true;
            this.loginBt.Click += new System.EventHandler(this.loginBt_Click);
            // 
            // accountErr
            // 
            this.accountErr.AutoSize = true;
            this.accountErr.ForeColor = System.Drawing.Color.Red;
            this.accountErr.Location = new System.Drawing.Point(317, 89);
            this.accountErr.Name = "accountErr";
            this.accountErr.Size = new System.Drawing.Size(11, 12);
            this.accountErr.TabIndex = 5;
            this.accountErr.Text = "*";
            this.accountErr.Visible = false;
            // 
            // pwdErr
            // 
            this.pwdErr.AutoSize = true;
            this.pwdErr.ForeColor = System.Drawing.Color.Red;
            this.pwdErr.Location = new System.Drawing.Point(317, 166);
            this.pwdErr.Name = "pwdErr";
            this.pwdErr.Size = new System.Drawing.Size(11, 12);
            this.pwdErr.TabIndex = 6;
            this.pwdErr.Text = "*";
            this.pwdErr.Visible = false;
            // 
            // loginErr
            // 
            this.loginErr.AutoSize = true;
            this.loginErr.BackColor = System.Drawing.SystemColors.Window;
            this.loginErr.ForeColor = System.Drawing.Color.Red;
            this.loginErr.Location = new System.Drawing.Point(239, 246);
            this.loginErr.Name = "loginErr";
            this.loginErr.Size = new System.Drawing.Size(89, 12);
            this.loginErr.TabIndex = 7;
            this.loginErr.Text = "用户名密码错误";
            this.loginErr.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 320);
            this.Controls.Add(this.loginErr);
            this.Controls.Add(this.pwdErr);
            this.Controls.Add(this.accountErr);
            this.Controls.Add(this.loginBt);
            this.Controls.Add(this.pwdTB);
            this.Controls.Add(this.accountTB);
            this.Controls.Add(this.pwdL);
            this.Controls.Add(this.accountL);
            this.Name = "LoginForm";
            this.Text = "优学院自动答题";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label accountL;
        private System.Windows.Forms.Label pwdL;
        private System.Windows.Forms.TextBox accountTB;
        private System.Windows.Forms.TextBox pwdTB;
        private System.Windows.Forms.Button loginBt;
        private System.Windows.Forms.Label accountErr;
        private System.Windows.Forms.Label pwdErr;
        private System.Windows.Forms.Label loginErr;
    }
}

