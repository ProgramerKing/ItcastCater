using ItcastCater.BLL;
using ItcastCater.Models;
using System;
using System.Windows.Forms;

namespace ItcastCaterApp
{
    public partial class FrmChangeCategory : Form
    {
        public FrmChangeCategory()
        {
            InitializeComponent();
        }
        private int TP { get; set; }//存标识
        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;
            this.TP = mea.Temp;//标识存起来了
            if (this.TP==1)//新增
            {
                
            }
            else if (this.TP==2)//修改
            {
                CategoryInfo ct = mea.Obj as CategoryInfo;
                txtCName.Text = ct.CatName;
                txtCNum.Text = ct.CatNum;
                txtCRemark.Text = ct.Remark;
                labId.Text = ct.CatID.ToString();//id存起来
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                CategoryInfo ct = new CategoryInfo();
                ct.CatName = txtCName.Text;
                ct.CatNum = txtCNum.Text;
                ct.Remark = txtCRemark.Text;
              
                //判断新增还是修改
                if (this.TP == 1)//新增
                {
                    ct.DelFlag = 0;
                    ct.SubBy = 1;
                    ct.SubTime = System.DateTime.Now;
                }
                else if (this.TP == 2)//修改
                {
                    ct.CatID = Convert.ToInt32(labId.Text);
                }
                CategoryInfoService bll = new CategoryInfoService();
                //string msg= bll.SaveCategoryInfo(ct, this.TP)?"操作成功":"操作失败";
                //MessageBox.Show(msg);
                this.Close();
            }

           
        }
        //判断各个文本框不能为空
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtCName.Text))
            {
                MessageBox.Show("名字不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtCNum.Text))
            {
                MessageBox.Show("编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtCRemark.Text))
            {
                MessageBox.Show("备注不能为空");
                return false;
            }
            return true;
        }
    }
}
