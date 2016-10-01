using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ItcastCater.Models;
using ItcastCater.BLL;
namespace ItcastCaterApp
{
    public partial class FrmCategory : Form
    {
        
        public FrmCategory()
        {
            InitializeComponent();
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            //加载所有的商品类别
            LoadCategoryInfoByDelFlag(0);
            //加载所有的产品
            LoadProductInfoByDelFlag(0);

            //显示所有的类别
            LoadCategoryInfoByDelFlagToCmb(0);
        }
        //绑定下拉框
        private void LoadCategoryInfoByDelFlagToCmb(int p)
        {
            //CategoryInfoBLL bll = new CategoryInfoBLL();
         
            //List<CategoryInfo>list= bll.GetAllCategoryInfoByDelFlag(p);
            //list.Insert(0, new CategoryInfo() {  CatId=-1, CatName="请选择"});
            //cmbCategory.DataSource = list;
            //cmbCategory.DisplayMember = "CatName";
            //cmbCategory.ValueMember = "CatId";
        }
        //产品
        private void LoadProductInfoByDelFlag(int p)
        {
            //ProductInfoBLL bll = new ProductInfoBLL();
            //dgvProductInfo.AutoGenerateColumns = false;
            //dgvProductInfo.DataSource = bll.GetAllProductInfoByDelFlag(p);
            //dgvProductInfo.SelectedRows[0].Selected = false;
        }
        //类别
        private void LoadCategoryInfoByDelFlag(int p)
        {
            //CategoryInfoBLL bll = new CategoryInfoBLL();
            //dgvCategoryInfo.AutoGenerateColumns = false;
            //dgvCategoryInfo.DataSource= bll.GetAllCategoryInfoByDelFlag(p);
            //dgvCategoryInfo.SelectedRows[0].Selected = false;
        }
        //增加商品类别
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            LoadFrmChangeCategoryInfo(1);//新增
        }
        //修改商品类别
        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            //if (dgvCategoryInfo.SelectedRows.Count>0)
            //{
            //    //选中行后获取id                //根据id获取该对象
            //    int id = Convert.ToInt32(dgvCategoryInfo.SelectedRows[0].Cells[0].Value.ToString());
            //    //根据id去数据库查询对应的对象
            //    CategoryInfoBLL bll = new CategoryInfoBLL();
            //    CategoryInfo ct= bll.GetCategoryInfoById(id);//
                
            //    if (ct!=null)
            //    {
            //        mea.Obj = ct;
            //        LoadFrmChangeCategoryInfo(2);//修改
            //    }
            //    //存对象
            //}
            //else
            //{
            //    MessageBox.Show("请选中要修改的行");
            //}
           
        }
        //p----1表示的是新增,2表示的是修改
        //显示新增或者修改的商品类别窗体
       // MyEventArgs mea = new MyEventArgs();
        public event EventHandler evtFcc;
        private void LoadFrmChangeCategoryInfo(int p)
        {
            //FrmChangeCategory fcc = new FrmChangeCategory();
            //this.evtFcc+=new EventHandler(fcc.SetText);//注册事件
            //mea.Temp = p;//标识存起来
            //if (this.evtFcc!=null)
            //{
            //    this.evtFcc(this, mea);
            //    fcc.FormClosed += new FormClosedEventHandler(fcc_FormClosed);
            //    fcc.ShowDialog();
            //}
        }
        //刷新---是新增或修改窗体关闭后调用的方法
        void fcc_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadCategoryInfoByDelFlag(0);
        }
        //删除产品
        private void btnDeletePro_Click(object sender, EventArgs e)
        {
            //if (dgvProductInfo.SelectedRows.Count>0)//有选中的行
            //{
            //    //非常友好的提示
            //    if (DialogResult.OK== MessageBox.Show("真的要删除吗","删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            //    {
            //        int id = Convert.ToInt32(dgvProductInfo.SelectedRows[0].Cells[0].Value.ToString());
            //        ProductInfoBLL bll = new ProductInfoBLL();
            //      string msg=  bll.SoftDeleteProductInfoByProId(id)?"操作成功":"操作失败";
            //      MessageBox.Show(msg);
            //      LoadProductInfoByDelFlag(0);

            //    }
            //}
            //else
            //{
            //    MessageBox.Show("请选中要删除的行");
            //}
        }


        public event EventHandler evtFcp;//产品传值的事件

        //增加产品
        private void btnAddPro_Click(object sender, EventArgs e)
        {
            ShowFrmChangeProduct(3);
        }
        //修改产品
        private void btnUpdatePro_Click(object sender, EventArgs e)
        {
            //if (dgvProductInfo.SelectedRows.Count>0)
            //{
            //    int id = Convert.ToInt32(dgvProductInfo.SelectedRows[0].Cells[0].Value.ToString());
            //    //根据id查询对象
            //    ProductInfoBLL bll = new ProductInfoBLL();
            //    ProductInfo pro = bll.GetProductInfoById(id);
            //    if (pro!=null)
            //    {
            //        meaFcp.Obj = pro;
            //        //获取id
            //        ShowFrmChangeProduct(4);
            //    }
              
            //}
            //else
            //{
            //    MessageBox.Show("说好的要做彼此的大天使呢,请选中");
            //}
        }
        //标识  3---新增,4----修改
        //MyEventArgs meaFcp = new MyEventArgs();
        private void ShowFrmChangeProduct(int p)
        {
            //FrmChangeProduct fcp = new FrmChangeProduct();
            //this.evtFcp+=new EventHandler(fcp.SetText);//注册事件
            //meaFcp.Temp = p;//标识存起来
            //if (this.evtFcp!=null)
            //{
            //    this.evtFcp(this,meaFcp);
            //    fcp.FormClosed += new FormClosedEventHandler(fcp_FormClosed);
            //    fcp.ShowDialog();
            //}

        }
        //产品刷新
        void fcp_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadProductInfoByDelFlag(0);
        }
        //选中类别显示产品
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbCategory.SelectedIndex!=0)
            //{
            //    int id = Convert.ToInt32(cmbCategory.SelectedValue);
            //    ProductInfoBLL bll = new ProductInfoBLL();
            //    dgvProductInfo.AutoGenerateColumns = false;
            //    dgvProductInfo.DataSource= bll.GetProductInfoByCatId(id);
            //    if (dgvProductInfo.SelectedRows.Count>0)
            //    {
            //        dgvProductInfo.SelectedRows[0].Selected = false;
            //    }
            //}
            //else
            //{
            //    LoadProductInfoByDelFlag(0);
            //}
        }
    }
}
