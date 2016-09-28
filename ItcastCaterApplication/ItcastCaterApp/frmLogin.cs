using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ItcastCater.Models;
using ItcastCater.BLL;

namespace ItcastCaterApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(CheckText()) //账号和密码不为空
            {
                string msg = string.Empty;
                //判断用户登录是否成功
                UserInfoService bllUser = new UserInfoService();
                if(bllUser.IsLoginByLoginName(txtLoginUserName.Text.Trim(), txtUserPwd.Text.Trim(), out msg))
                {
                    msgDiv1.MsgDivShow(msg, 1,Bind);
                }
                else
                {
                    msgDiv1.MsgDivShow(msg, 1);
                }
            }
    
        }

        public void Bind()
        {
            //设置当前的登录窗口的值
            this.DialogResult = DialogResult.OK;
        }

        //判断账号和密码不能为空
        /// <summary>
        /// 判断账号和密码不能为空
        /// </summary>
        /// <returns></returns>
        private bool CheckText()
        {
            if(String.IsNullOrEmpty(txtLoginUserName.Text))
            {
                msgDiv1.MsgDivShow("账号不能为空", 1);
                return false;
            }
            if(String.IsNullOrEmpty(txtUserPwd.Text))
            {
                msgDiv1.MsgDivShow("密码不能为空", 1);
                return false;
            }
            return true;
        }
    }
}
