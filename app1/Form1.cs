using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void pwdL_Click(object sender, EventArgs e)
        {

        }

        private void loginBt_Click(object sender, EventArgs e)
        {
            if (this.accountTB.Text == "")
            {
                this.accountErr.Visible = true;
                return;
            }
            else
            {
                this.accountErr.Visible = false;
                Http.user = this.accountTB.Text;
            }
            if (this.pwdTB.Text == "")
            {
                this.pwdErr.Visible = true;
                return;
            }
            else
            {
                this.pwdErr.Visible = false;
                Http.pwd = this.pwdTB.Text;
            }

            if (!checkPwdAndLogin(this.accountTB.Text, this.pwdTB.Text))
            {
                this.loginErr.Visible = true;
                return;
            }
            this.loginErr.Visible = false;

            Form1 form2 = new Form1();
            //form2.user = this.user;
            //form2.password = this.pwd;
            //form2.cc = this.cc;
            form2.Show();
            this.Dispose(false);
        }

        private bool checkPwdAndLogin(string username, string pwd)
        {
            string postDataStr = "loginname=" + Http.user + "&password=" + Http.pwd;

            //string req = Http.HttpPost("http://english.ulearning.cn/login/checkUserForLogin.do", postDataStr);
            //char res = req.Split(':')[1][0];
            //if (res == '0')
            //{
            //    return false;
            //}
            //postDataStr = "name=" + Http.user + "&passwd=" + Http.pwd + "&requestUrl=english.ulearning.cn";
            //req = Http.HttpPost("http://english.ulearning.cn/umooc/user/login.do", postDataStr);
            //Http.findname(req);
            string req = Http.HttpPost("http://www.ulearning.cn/ulearning_web/login!checkUserForLogin.do", postDataStr);
            char res = req[0];
            if (res == '0')
            {
                return false;
            }
            postDataStr = "name=" + Http.user + "&passwd=" + Http.pwd;
            req = Http.HttpPost("http://www.ulearning.cn/umooc/user/login.do", postDataStr);
            //Http.findname(req);
            return true;
        }
    }
}
