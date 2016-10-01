using ItcastCater.BLL;
using ItcastCater.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace ItcastCaterApp
{
    public partial class FrmUpdateMemmberInfo : Form
    {
        public FrmUpdateMemmberInfo()
        {
            InitializeComponent();
        }
        private int TP { get; set; }//存标识
        //为该窗体中的所有文本框赋值

        //直接写个方法,不要load方法 ---不信你就试试

        private void LoadMemmberTypeByDelFlag(int p)
        {
            //MemmberTypeBLL bll = new MemmberTypeBLL();
            //List<MemmberType> list = bll.GetAllMemmberTypeByDelFlag(p);
            //list.Insert(0, new MemmberType() { MemType = -1, MemTpName = "请选择" });
            //cmbMemType.DataSource = list;
            //cmbMemType.DisplayMember = "MemTpName";
            //cmbMemType.ValueMember = "MemType";
        }

        public void SetText(object sender, EventArgs e)
        {
            LoadMemmberTypeByDelFlag(0);
            //
            MyEventArgs mea = e as MyEventArgs;
            this.TP = mea.Temp;//标识存起来
            if (this.TP == 1)//新增
            {
                //复习 清空所有的文本框

                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox tb = item as TextBox;
                        tb.Text = "";
                    }
                }
                txtMemIntegral.Text = "0";
                rdoMan.Checked = true;
            }
            else if (this.TP == 2)//修改
            {
                MemberInfo mem = mea.Obj as MemberInfo;
                txtBirs.Text = mem.MemBirthday.ToString();//生日
                txtMemDiscount.Text = mem.MemDiscount.ToString();//折扣
                txtMemIntegral.Text = mem.MemIntegral.ToString();//积分
                txtmemMoney.Text = mem.MemMoney.ToString();//余下额
                txtMemName.Text = mem.MemName;//名字
                txtMemNum.Text = mem.MemNum;//编号
                txtMemPhone.Text = mem.MemMobilePhone;//电话
                //性别
                rdoMan.Checked = mem.MemGender == "男" ? true : false;
                rdoWomen.Checked = mem.MemGender == "女" ? true : false;
                //结束的日期
                dtEndServerTime.Value = Convert.ToDateTime(mem.MemEndServerTime);

                //绑定会员的等级
                cmbMemType.SelectedValue = mem.MemType;
                //id存起来

                labId.Text = mem.MemberID.ToString();
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                //获取每个文本框的值
                MemberInfo mem = new MemberInfo();
                // mem.MemAddress=地址不要了
                mem.MemBirthday = Convert.ToDateTime(txtBirs.Text);
                mem.MemDiscount = Convert.ToDecimal(txtMemDiscount.Text);
                mem.MemEndServerTime = Convert.ToDateTime(dtEndServerTime.Value);
                mem.MemGender = CheckGender();//性别
                mem.MemIntegral = Convert.ToInt32(txtMemIntegral.Text);
                mem.MemMobilePhone = txtMemPhone.Text;
                mem.MemMoney = Convert.ToDecimal(txtmemMoney.Text);
                mem.MemName = txtMemName.Text;
                mem.MemNum = txtMemNum.Text;
                mem.MemType = Convert.ToInt32(cmbMemType.SelectedValue);

                //判断新增还是修改----刚把得--加油--你们可以的
                if (this.TP == 1)//新增
                {
                    mem.SubTime = System.DateTime.Now;
                    mem.DelFlag = 0;
                }
                else if (this.TP == 2)//修改
                {
                    mem.MemberID = Convert.ToInt32(labId.Text);
                }
                MemberInfoService bll = new MemberInfoService();
               // string msg = bll.SaveMemmberInfo(mem, this.TP) ? "操作成功" : "操作失败";
                //MessageBox.Show(msg);
                this.Close();
            }


        }
        //性别
        private string CheckGender()
        {
            string str = "";
            if (rdoMan.Checked)
            {
                str = "男";
            }
            else if (rdoWomen.Checked)
            {
                str = "女";
            }
            return str;
        }

        //判断所有的文本框不为空
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtBirs.Text))
            {
                MessageBox.Show("生日不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemDiscount.Text))
            {
                MessageBox.Show("折扣不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemIntegral.Text))
            {
                MessageBox.Show("积分不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtmemMoney.Text))
            {
                MessageBox.Show("钱不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemName.Text))
            {
                MessageBox.Show("名字不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemNum.Text))
            {
                MessageBox.Show("编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtMemPhone.Text))
            {
                MessageBox.Show("电话不能为空");
                return false;
            }
            if (cmbMemType.SelectedIndex == 0)
            {
                MessageBox.Show("请选择会员级别");
                return false;
            }
            return true;
        }
    }
}
