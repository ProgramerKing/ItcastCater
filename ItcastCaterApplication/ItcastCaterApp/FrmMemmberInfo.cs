using ItcastCater.BLL;
using System;
using System.Windows.Forms;
namespace ItcastCaterApp
{
    public partial class FrmMemmberInfo : Form
    {
        MemberInfoService memBll = new MemberInfoService();
        public FrmMemmberInfo()
        {
            InitializeComponent();
        }
        //窗体加载
        private void FrmMemmberInfo_Load(object sender, EventArgs e)
        {
            LoadMemmberInfoByDelFlag(0);
        }
        //加载所有的会员
        private void LoadMemmberInfoByDelFlag(int p)
        {
           
            dgvMemmber.AutoGenerateColumns = false;//禁止自动生成列
            dgvMemmber.DataSource = memBll.GetAllMemberInfoByDelFlag(p);
            dgvMemmber.SelectedRows[0].Selected = false;//禁止默认第一行选中
        }
        //删除会员--逻辑删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMemmber.SelectedRows.Count > 0)//有选中的行
            {
                int memberID = Convert.ToInt32(dgvMemmber.SelectedRows[0].Cells[0].Value.ToString());
                string msg = memBll.DelteMemberInfoByMemberID(memberID) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                LoadMemmberInfoByDelFlag(0);//刷新
            }
        }
        public event EventHandler evtMemmber;
        //标识1-----新增,2----修改
        //增加会员
        private void btnAddMemMber_Click(object sender, EventArgs e)
        {
            ShowFrmUpdateMemmberInfo(1);
        }
        //修改会员
        private void btnUpdateMember_Click(object sender, EventArgs e)
        {
            //if (dgvMemmber.SelectedRows.Count > 0)//有选中的行
            //{
            //    //获取选中行的id
            //    //根据id去数据库查询
            //    int id = Convert.ToInt32(dgvMemmber.SelectedRows[0].Cells[0].Value.ToString());
            //    //去数据库查询数据
            //    MemmberInfoBLL bll = new MemmberInfoBLL();
            //    mea.Obj = bll.GetMemmberInfoBymemmberId(id);//对象拿到了

            //    ShowFrmUpdateMemmberInfo(2);

            //}
            //else
            //{
            //    MessageBox.Show("请看准目标再下手");
            //}

        }
        //MyEventArgs mea = new MyEventArgs();//用来传值的
        public void ShowFrmUpdateMemmberInfo(int p)
        {
            //FrmUpdateMemmberInfo fum = new FrmUpdateMemmberInfo();
            //this.evtMemmber += new EventHandler(fum.SetText);
            //mea.Temp = p;
            //if (this.evtMemmber!=null)
            //{
            //    this.evtMemmber(this, mea);
            //    fum.FormClosed += new FormClosedEventHandler(fum_FormClosed);//关闭刷新
            //    fum.ShowDialog();
            //}
           
        }

        void fum_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadMemmberInfoByDelFlag(0);
        }
    }
}
