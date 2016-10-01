using ItcastCater.BLL;
using ItcastCater.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ItcastCaterApp
{
    public partial class FrmChangeProduct : Form
    {
        public FrmChangeProduct()
        {
            InitializeComponent();
        }
        private int TP { get; set; }//标识
        private void LoadCategoryInfoByDelFag(int p)
        {
            CategoryInfoService bll = new CategoryInfoService();
            
            List<CategoryInfo> list = new List<CategoryInfo>();
            list = bll.GetAllCategoryInfoByDelFlag(p);
            //list.Insert(0, new CategoryInfo() {  CatName="请选择", CatId=-1});
            cmbCategory.DataSource = list;
            cmbCategory.DisplayMember = "CatName";
            cmbCategory.ValueMember = "CatId";
        }
        public void SetText(object sender, EventArgs e)
        {
            LoadCategoryInfoByDelFag(0);
            MyEventArgs mea = e as MyEventArgs;
            this.TP = mea.Temp;//标识

            if (this.TP==3)//新增
            {
                
            }
            else if (this.TP==4)
            {
                ProductInfo pro = mea.Obj as ProductInfo;
                txtCost.Text = pro.ProCost.ToString();
                txtName.Text = pro.ProName;
                txtNum.Text = pro.ProNum;
                txtPrice.Text = pro.ProPrice.ToString();
                txtRemark.Text = pro.Remark;
                txtSpell.Text = pro.ProSpell;
                txtStock.Text = pro.ProStock.ToString();
                txtUnit.Text = pro.ProUnit;
                labId.Text = pro.ProID.ToString();//id存起来

                //类别
                cmbCategory.SelectedValue = pro.CatID;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //判断是新增还是修改
            if (CheckEmpty())
            {
                ProductInfo pro = new ProductInfo();
                pro.CatID = Convert.ToInt32(cmbCategory.SelectedValue);
                pro.ProCost = Convert.ToDecimal(txtCost.Text);
                pro.ProName = txtName.Text;
                pro.ProNum = txtNum.Text;
                pro.ProPrice = Convert.ToDecimal(txtPrice.Text);
                pro.ProSpell = txtSpell.Text;
                pro.ProStock = Convert.ToDecimal(txtStock.Text);
                pro.ProUnit = txtUnit.Text;
                pro.Remark = txtRemark.Text;
              
                if (this.TP==3)//新增
                {
                    pro.DelFlag = 0;
                    pro.SubBy = 1;
                    pro.SubTime = System.DateTime.Now;
                }
                else if (this.TP==4)//修改
                {
                    pro.ProID = Convert.ToInt32(labId.Text);
                }
               // ProductInfoBLL bll = new ProductInfoBLL();
               //string msg= bll.SaveProduct(pro,this.TP)?"操作成功":"操作失败";
               //MessageBox.Show(msg);
               this.Close();
            }
        }
        //判断每个文本框不能为空
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtCost.Text))
            {
                MessageBox.Show("商品成本不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("商品名称不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtNum.Text))
            {
                MessageBox.Show("商品编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("商品价格不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtRemark.Text))
            {
                MessageBox.Show("商品备注不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtSpell.Text))
            {
                MessageBox.Show("商品拼音不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("商品库存不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtUnit.Text))
            {
                MessageBox.Show("商品单位不能为空");
                return false;
            }
            if (cmbCategory.SelectedIndex==0)
            {
                MessageBox.Show("请选择类别");
                return false;
            }
            return true;
        }
    }
}
