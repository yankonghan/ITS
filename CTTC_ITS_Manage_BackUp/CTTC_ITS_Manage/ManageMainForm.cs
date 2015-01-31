using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using ITS_Manage.DAL;
using ITS_Manage.DAL.DBUtility;
using ITS_Manage.Model;
using ITS_Manage.COMMON;
using System.Configuration;
using CTTC_ITS_Manage.MainClass;
using CTTC_ITS_Manage.Forms;
using CTTC_ITS_Manage.UserControl;
using System.Threading.Tasks;
using System.Threading;


namespace CTTC_ITS_Manage
{
    public delegate void ShowLineCHandler(ITS_Manage.Model.LineStation line);

    public partial class ManageMainForm : RibbonForm
    {

        #region 全局变量
        private ShowLineCHandler SLCH;
        private DevExpress.XtraTab.XtraTabPage PeopleInfoListTabPage;
        private DevExpress.XtraTab.XtraTabPage StreetLineXtraPage;
        private PersonSelectForm personSelectForm;
        private StreetLineControl LineControl;
        private string LineIDForLineStreet;

        private MapOperation MainMapOpration;
        private string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        private List<string> LineWCArray;
        private List<string> LineWZArray;
        //线路监控任务列表
        private List<Task> LineCTask;
        //线路监控任务列表
        private List<Task> LineZTask;
        //线路监控停止标志位
        private List<string> IsLineCStop;


        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public ManageMainForm()
        {
            personSelectForm = new PersonSelectForm();
            personSelectForm.simpleButton3.Click += new EventHandler(simpleButton1_Click);
            personSelectForm.simpleButton1.Click += new EventHandler(simpleButton2_Click);
            LineWCArray = new List<string>();
            IsLineCStop = new List<string>();
            LineCTask = new List<Task>();
          /*由于下面的ShowLineC尚未完成，故先注释
           * */
            //  SLCH += ShowLineC;
            InitializeComponent();
        }
        /// <summary>
        /// 显示指定线路的直线图
        /// </summary>
        /// <param name="Line">线路</param>
        private void ShowLineStreet(ITS_Manage.Model.LineStation Line)
        {
            StreetLineXtraPage = new DevExpress.XtraTab.XtraTabPage();
            StreetLineXtraPage.SuspendLayout();
            this.xtraTabControl1.TabPages.Add(StreetLineXtraPage);

            this.StreetLineXtraPage.Name = "StreetLineTabPage";
            this.StreetLineXtraPage.Size = new System.Drawing.Size(847, 518);
            this.StreetLineXtraPage.Text = Line.lineID + "线路直线图";
            this.StreetLineXtraPage.ResumeLayout(false);

            this.LineControl = new StreetLineControl(Line.UpDistance, Line.DownDistance, Line.UpStationName, Line.DownStationName, Line.lineID);
            this.StreetLineXtraPage.Controls.Add(this.LineControl);
            this.LineControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LineControl.Location = new System.Drawing.Point(0, 0);
            this.LineControl.Name = "shishi1";
            this.LineControl.Size = new System.Drawing.Size(847, 518);
            this.LineControl.TabIndex = 2;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            #region ribbonControl

            PeopleInfoListTabPage = new DevExpress.XtraTab.XtraTabPage();
            PeopleInfoListTabPage.SuspendLayout();
            this.xtraTabControl1.TabPages.Add(PeopleInfoListTabPage);
            ModelInfoList infoList = new ModelInfoList(this.personSelectForm);

            this.PeopleInfoListTabPage.Controls.Add(infoList);
            this.PeopleInfoListTabPage.Name = "InfoListTabPage";
            this.PeopleInfoListTabPage.Size = new System.Drawing.Size(847, 518);
            this.PeopleInfoListTabPage.Text = "人员信息查询列表";
            this.PeopleInfoListTabPage.ResumeLayout(false);

            #endregion
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            #region ribbonControl
            ModelInfoList infoList = new ModelInfoList(this.personSelectForm);
            infoList.Dock = DockStyle.Fill;

            PeopleInfoListTabPage = new DevExpress.XtraTab.XtraTabPage();
            PeopleInfoListTabPage.SuspendLayout();
            this.xtraTabControl1.TabPages.Add(PeopleInfoListTabPage);
            this.PeopleInfoListTabPage.Controls.Add(infoList);
            this.PeopleInfoListTabPage.Name = "TryInfoListTabPage";
            this.PeopleInfoListTabPage.Size = new System.Drawing.Size(847, 518);
            this.PeopleInfoListTabPage.Text = "信息查询列表";
            this.PeopleInfoListTabPage.ResumeLayout(false);
            this.PeopleInfoListTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            this.personSelectForm.Hide();
            this.personSelectForm.Close();

            #endregion
        }
        private void TryInfoListTabPage_DoubleClick(object sender, EventArgs e)
        {
            this.PeopleInfoListTabPage.Hide();
            this.PeopleInfoListTabPage.Dispose();
        }
        private void navBarControl2_Click(object sender, EventArgs e)
        {

        }

        private void ribbonControl_Click(object sender, EventArgs e)
        {

        }

        private void ManageMainForm_Load(object sender, EventArgs e)
        {

            #region 界面初始化

            InitManageOnLineTree();
            MainMapOpration = new MapOperation(this.MainMap);
            MainMapOpration.InitMap();

            #endregion

            #region 注册事件

            ManageOnlineTree.NodeMouseClick += new TreeNodeMouseClickEventHandler(ManageOnlineTree_NodeMouseClick);
            contextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(contextMenuStrip_ItemClicked);
            ManageOnlineTree.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(ManageOnlineTree_NodeMouseDoubleClick);
            BasicInfoTreeView.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(BasicInfoTreeView_NodeMouseDoubleClick);
            //this.TryInfoListTabPage.DoubleClick += new EventHandler(TryInfoListTabPage_DoubleClick);

            #endregion


        }

        private void BasicInfoTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Tag.ToString())
            {
                case "部门列表":

                    break;
                case "人员列表": ;
                    personSelectForm.ShowDialog();
                    break;
                case "车辆管理":

                    break;
                case "线路列表":
                    LineSelectForm lineSelectForm = new LineSelectForm();
                    lineSelectForm.ShowDialog();
                    break;
                case "自动排班":

                    break;
                default:

                    break;
            }
        }
        private void InitBasicInfoTree()
        {

        }
        private void ManageOnlineTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Tag.ToString())
            {
                case "在线监控|车辆|在线":
                    MapOperation.CheckBusRealInfoOnMap(e.Node.Text);
                    break;
                case "在线监控|车辆|离线":
                    break;
                case "历史记录|车辆":
                    //Open
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 右键单击树状导航栏弹出菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageOnlineTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                switch (e.Node.Tag.ToString())
                {
                    case "车辆监控":

                        this.contextMenuStrip.Items.Clear();
                        ToolStripMenuItem[] AddAreaManageBus = new ToolStripMenuItem[2];
                        AddAreaManageBus[0] = new ToolStripMenuItem("查看所有车辆");
                        AddAreaManageBus[0].Name = "查看所有车辆";
                        if (e.Node.IsExpanded != true)
                        {
                            AddAreaManageBus[1] = new ToolStripMenuItem("展开");
                            AddAreaManageBus[1].Name = "展开";
                        }
                        else
                        {
                            AddAreaManageBus[1] = new ToolStripMenuItem("折叠");
                            AddAreaManageBus[1].Name = "折叠";
                        }
                        contextMenuStrip.Items.AddRange(AddAreaManageBus);
                        this.contextMenuStrip.Show(this.ManageOnlineTree, e.Location);

                        break;
                    case "站点监控":

                        this.contextMenuStrip.Items.Clear();
                        ToolStripMenuItem[] AddAreaManageStation = new ToolStripMenuItem[2];
                        AddAreaManageStation[0] = new ToolStripMenuItem("查看所有站点");
                        AddAreaManageStation[0].Name = "查看所有站点";
                        if (e.Node.IsExpanded != true)
                        {
                            AddAreaManageStation[1] = new ToolStripMenuItem("展开");
                            AddAreaManageStation[1].Name = "展开";
                        }
                        else
                        {
                            AddAreaManageStation[1] = new ToolStripMenuItem("折叠");
                            AddAreaManageStation[1].Name = "折叠";
                        }
                        contextMenuStrip.Items.AddRange(AddAreaManageStation);
                        this.contextMenuStrip.Show(this.ManageOnlineTree, e.Location);

                        break;
                    case "线路":

                        this.LineIDForLineStreet = e.Node.Text.Trim();
                        this.contextMenuStrip.Items.Clear();
                        ToolStripMenuItem[] AddAreaLine = new ToolStripMenuItem[4];
                        AddAreaLine[0] = new ToolStripMenuItem("线路信息");
                        AddAreaLine[0].Name = "线路信息";
                        if (e.Node.IsExpanded != true)
                        {
                            AddAreaLine[1] = new ToolStripMenuItem("展开");
                            AddAreaLine[1].Name = "展开";
                        }
                        else
                        {
                            AddAreaLine[1] = new ToolStripMenuItem("折叠");
                            AddAreaLine[1].Name = "折叠";
                        }
                        if (e.Node.Parent.Tag.ToString() == "车辆监控")
                        {
                            if (LineWCArray.Contains(LineIDForLineStreet))
                            {
                                AddAreaLine[2] = new ToolStripMenuItem("停止地图监控(车辆)");
                                AddAreaLine[2].Name = "停止地图监控(车辆)";
                            }
                            else
                            {
                                AddAreaLine[2] = new ToolStripMenuItem("地图监控线路(车辆)");
                                AddAreaLine[2].Name = "地图监控线路(车辆)";
                            }
                        }
                        else if (e.Node.Parent.Tag.ToString() == "站点监控")
                        {
                            if (LineWCArray.Contains(LineIDForLineStreet))
                            {
                                AddAreaLine[2] = new ToolStripMenuItem("停止地图监控(站点)");
                                AddAreaLine[2].Name = "停止地图监控(站点)";
                            }
                            else
                            {
                                AddAreaLine[2] = new ToolStripMenuItem("地图监控线路(站点)");
                                AddAreaLine[2].Name = "地图监控线路(站点)";
                            }
                        }

                        AddAreaLine[3] = new ToolStripMenuItem("查看线路直线图");
                        AddAreaLine[3].Name = "查看线路直线图";

                        

                        contextMenuStrip.Items.AddRange(AddAreaLine);
                        this.contextMenuStrip.Show(this.ManageOnlineTree, e.Location);

                        break;
                    case "在线监控|车辆|在线":

                        this.contextMenuStrip.Items.Clear();
                        ToolStripMenuItem[] AddAreaOnline = new ToolStripMenuItem[5];
                        AddAreaOnline[0] = new ToolStripMenuItem("地图位置");
                        AddAreaOnline[0].Name = "地图位置";
                        AddAreaOnline[1] = new ToolStripMenuItem("车辆信息");
                        AddAreaOnline[1].Name = "车辆信息";
                        AddAreaOnline[2] = new ToolStripMenuItem("打开监控窗口");
                        AddAreaOnline[2].Name = "打开监控窗口";
                        AddAreaOnline[3] = new ToolStripMenuItem("调度");
                        AddAreaOnline[3].Name = "调度";
                        AddAreaOnline[4] = new ToolStripMenuItem("历史行车轨迹回放");
                        AddAreaOnline[4].Name = "历史行车轨迹回放";
                        contextMenuStrip.Items.AddRange(AddAreaOnline);
                        this.contextMenuStrip.Show(this.ManageOnlineTree, e.Location);

                        break;
                    case "在线监控|车辆|离线":

                        this.contextMenuStrip.Items.Clear();
                        ToolStripMenuItem[] AddAreaOffline = new ToolStripMenuItem[2];
                        AddAreaOffline[0] = new ToolStripMenuItem("车辆信息");
                        AddAreaOffline[0].Name = "车辆信息";
                        AddAreaOffline[1] = new ToolStripMenuItem("历史行车轨迹回放");
                        AddAreaOffline[1].Name = "历史行车轨迹回放";
                        contextMenuStrip.Items.AddRange(AddAreaOffline);
                        this.contextMenuStrip.Show(this.ManageOnlineTree, e.Location);

                        break;
                    case "历史记录|车辆":

                        this.contextMenuStrip.Items.Clear();
                        ToolStripMenuItem[] AddAreaHistory = new ToolStripMenuItem[1];
                        AddAreaHistory[0] = new ToolStripMenuItem("查看历史记录");
                        AddAreaHistory[0].Name = "查看历史记录";
                        contextMenuStrip.Items.AddRange(AddAreaHistory);
                        this.contextMenuStrip.Show(this.ManageOnlineTree, e.Location);

                        break;
                    case "在线监控|车辆|报警":

                        this.contextMenuStrip.Items.Clear();
                        ToolStripMenuItem[] AddAreaAlarm = new ToolStripMenuItem[6];
                        AddAreaAlarm[0] = new ToolStripMenuItem("地图位置");
                        AddAreaAlarm[0].Name = "地图位置";
                        AddAreaAlarm[1] = new ToolStripMenuItem("车辆信息");
                        AddAreaAlarm[1].Name = "车辆信息";
                        AddAreaAlarm[2] = new ToolStripMenuItem("打开监控窗口");
                        AddAreaAlarm[2].Name = "打开监控窗口";
                        AddAreaAlarm[3] = new ToolStripMenuItem("警报处理");
                        AddAreaAlarm[3].Name = "警报处理";
                        AddAreaAlarm[4] = new ToolStripMenuItem("调度");
                        AddAreaAlarm[4].Name = "调度";
                        AddAreaAlarm[5] = new ToolStripMenuItem("历史行车轨迹回放");
                        AddAreaAlarm[5].Name = "历史行车轨迹回放";
                        contextMenuStrip.Items.AddRange(AddAreaAlarm);
                        this.contextMenuStrip.Show(this.ManageOnlineTree, e.Location);

                        break;
                    case "在线监控|站点|在线":

                        this.contextMenuStrip.Items.Clear();
                        ToolStripMenuItem[] AddAreaStationOnline = new ToolStripMenuItem[3];
                        AddAreaStationOnline[0] = new ToolStripMenuItem("地图位置");
                        AddAreaStationOnline[0].Name = "地图位置";
                        AddAreaStationOnline[1] = new ToolStripMenuItem("站点信息");
                        AddAreaStationOnline[1].Name = "站点信息";
                        AddAreaStationOnline[2] = new ToolStripMenuItem("打开监控窗口");
                        AddAreaStationOnline[2].Name = "打开监控窗口";
                        contextMenuStrip.Items.AddRange(AddAreaStationOnline);
                        this.contextMenuStrip.Show(this.ManageOnlineTree, e.Location);

                        break;
                    case "在线监控|站点|离线":

                        this.contextMenuStrip.Items.Clear();
                        ToolStripMenuItem[] AddAreaStationOffline = new ToolStripMenuItem[2];
                        AddAreaStationOffline[0] = new ToolStripMenuItem("地图位置");
                        AddAreaStationOffline[0].Name = "地图位置";
                        AddAreaStationOffline[1] = new ToolStripMenuItem("站点信息");
                        AddAreaStationOffline[1].Name = "站点信息";
                        contextMenuStrip.Items.AddRange(AddAreaStationOffline);
                        this.contextMenuStrip.Show(this.ManageOnlineTree, e.Location);

                        break;
                    case "在线监控|站点|报警":

                        this.contextMenuStrip.Items.Clear();
                        ToolStripMenuItem[] AddAreaStationAlarm = new ToolStripMenuItem[2];
                        AddAreaStationAlarm[0] = new ToolStripMenuItem("地图位置");
                        AddAreaStationAlarm[0].Name = "地图位置";
                        AddAreaStationAlarm[1] = new ToolStripMenuItem("站点信息");
                        AddAreaStationAlarm[1].Name = "站点信息";
                        AddAreaStationAlarm[2] = new ToolStripMenuItem("报警处理");
                        AddAreaStationAlarm[2].Name = "报警处理";
                        contextMenuStrip.Items.AddRange(AddAreaStationAlarm);
                        this.contextMenuStrip.Show(this.ManageOnlineTree, e.Location);

                        break;
                    default:
                        return;
                }
            }
        }
        /// <summary>
        /// 点击菜单项目处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "查看线路直线图":

                    ITS_Manage.Model.LineStation lineStreet = new ITS_Manage.Model.LineStation();
                    lineStreet.lineID = LineIDForLineStreet;
                    lineStreet.StationLatLngUp = ITS_Manage.DAL.LineStationService.GetLineStationLatLng(LineIDForLineStreet, Forward.UP);
                    lineStreet.StationLatLngDown = ITS_Manage.DAL.LineStationService.GetLineStationLatLng(LineIDForLineStreet, Forward.DOWN);
                    lineStreet.UpDistance = MapOperation.GetDistanceArray(lineStreet.StationLatLngUp).UpDistance;
                    lineStreet.DownDistance = MapOperation.GetDistanceArray(lineStreet.StationLatLngUp).DownDistance;
                    lineStreet.UpStationName = ITS_Manage.DAL.LineStationService.GetLineStationName(LineIDForLineStreet, Forward.UP);
                    lineStreet.DownStationName = ITS_Manage.DAL.LineStationService.GetLineStationName(LineIDForLineStreet, Forward.DOWN);
                    ShowLineStreet(lineStreet);

                    break;
                case "地图监控线路(车辆)":

                    ITS_Manage.Model.LineStation line = new ITS_Manage.Model.LineStation();
                    line.lineID = LineIDForLineStreet;
                    line.StationLatLngUp = ITS_Manage.DAL.LineStationService.GetLineStationLatLng(line.lineID, Forward.UP);

                    
                    MainMapOpration.ShowLine(line);
                    LineWCArray.Add(line.lineID);
                    //Task LineCControl = new Task(ShowLineC,line,TaskCreationOptions.PreferFairness | TaskCreationOptions.LongRunning | TaskCreationOptions.AttachedToParent);

                    //LineCControl.Start();

                    Thread LineCControl = new Thread(new MapOperation(this.MainMap).ShowLineC);
                       LineCControl.Start(line);

                    break;
                case "停止地图监控(车辆)":
                    ITS_Manage.Model.LineStation lineStop = new ITS_Manage.Model.LineStation();
                    lineStop.lineID = LineIDForLineStreet;
                    MainMapOpration.StopShowLine(lineStop);

                    LineWCArray.RemoveAll(name =>
                    {
                        if (name ==lineStop.lineID)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    });
                  //  this.MainMap.MouseMove();
                    //this.MainMap.MouseMove += new MouseEventHandler();
                    break;
                default:
                    break;
            }
        }
        
        /// <summary>
        /// 初始化左侧树状导航栏 ,要加载很多数据库中的表到导航栏
        /// </summary>
        private void InitManageOnLineTree()
        {
            try
            {
                #region 在线监控

                ManageOnlineTree.Nodes[0].Tag = "车辆监控";
                ManageOnlineTree.Nodes[1].Tag = "站点监控";

                #region 加载线路列表

                DataTable dt = ITS_Manage.DAL.LineService.SelectLineInfo();
                TreeNode[] Lineroot = new TreeNode[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Lineroot[i] = new TreeNode(dt.Rows[i][0].ToString());
                    Lineroot[i].Text = dt.Rows[i][0].ToString();
                }
                for (int i = 0; i < Lineroot.Length; i++)
                {
                    this.ManageOnlineTree.Nodes[0].Nodes.Add(Lineroot[i].Text, Lineroot[i].Text);
                    this.ManageOnlineTree.Nodes[1].Nodes.Add(Lineroot[i].Text, Lineroot[i].Text);
                    this.ManageOnlineTree.Nodes[0].Nodes[i].Tag = "线路";
                    this.ManageOnlineTree.Nodes[1].Nodes[i].Tag = "线路";
                }

                #endregion

                #region 加载汽车列表

                for (int j = 0; j < Lineroot.Length; j++)
                {
                    string lineID = ManageOnlineTree.Nodes[0].Nodes[j].Text.Trim();
                    ITS_Manage.Model.Bus[] BusArrayForTree = ITS_Manage.DAL.BusService.SelectBusArray(lineID);
                    if (BusArrayForTree.Length == 0)
                    {
                        continue;
                    }
                    TreeNode[] BusNodes = new TreeNode[BusArrayForTree.Length];
                    for (int i = 0; i < BusArrayForTree.Length; i++)
                    {

                        BusNodes[i] = new TreeNode(BusArrayForTree[i].busID);

                        if (BusArrayForTree[i].isOnline == true)
                        {
                            BusNodes[i].Text = BusArrayForTree[i].busID.Trim() + "[在线]";
                        }
                        else
                        {
                            BusNodes[i].Text = BusArrayForTree[i].busID;
                        }
                        this.ManageOnlineTree.Nodes[0].Nodes[j].Nodes.Add(BusNodes[i].Text, BusNodes[i].Text);
                        if (BusArrayForTree[i].isOnline == true)
                        {
                            this.ManageOnlineTree.Nodes[0].Nodes[j].Nodes[i].ForeColor = Color.Green;
                            this.ManageOnlineTree.Nodes[0].Nodes[j].Nodes[i].Tag = "在线监控|车辆|在线";
                        }
                        else
                        {
                            this.ManageOnlineTree.Nodes[0].Nodes[j].Nodes[i].Tag = "在线监控|车辆|离线";
                        }
                    }
                }

                #endregion
               
                #region 加载站点列表
                /*此处需要较大修改，主要是数据库中的Station并没有isOnline。。因此将暂时默认为站点全为isOnline
                 * 站点需要什么isOnline吗？不是通过卫星定位的嘛。。额，暂时不清楚，如果要Station里添加isOnline，需要改DAL，Model，BLL
                 * 等多处的方法，真麻烦！！！！！！！！！！！！！！！！
                 * */

                for (int j = 0; j < Lineroot.Length; j++)
                {
                    string lineID = ManageOnlineTree.Nodes[0].Nodes[j].Text.Trim();
                    ITS_Manage.Model.Station[] StationArrayForTree = ITS_Manage.DAL.StationService.SelectStationLineArray(lineID);
                    if (StationArrayForTree.Length == 0)
                    {
                        continue;
                    }
                    TreeNode[] StationNodes = new TreeNode[StationArrayForTree.Length];
                    for (int i = 0; i < StationArrayForTree.Length; i++)
                    {

                        StationNodes[i] = new TreeNode(StationArrayForTree[i].stationName);

                        //if (StationArrayForTree[i].isOnline == true)
                        //{
                            StationNodes[i].Text = StationArrayForTree[i].stationName.Trim() + "[在线]";
                        //}
                        //else
                        //{
                        //    StationNodes[i].Text = StationArrayForTree[i].stationName;
                        //}
                        this.ManageOnlineTree.Nodes[1].Nodes[j].Nodes.Add(StationNodes[i].Text, StationNodes[i].Text);
                        //if (StationArrayForTree[i].isOnline == true)
                        //{
                            this.ManageOnlineTree.Nodes[1].Nodes[j].Nodes[i].ForeColor = Color.Green;
                            this.ManageOnlineTree.Nodes[1].Nodes[j].Nodes[i].Tag = "在线监控|站点|在线";
                        //}
                        //else
                        //{
                        //    this.ManageOnlineTree.Nodes[1].Nodes[j].Nodes[i].Tag = "在线监控|站点|离线";
                        //}
                    }
                }

                #endregion

                #endregion

                #region 历史轨迹

                #region 加载线路历史列表

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Lineroot[i] = new TreeNode(dt.Rows[i][0].ToString());
                    Lineroot[i].Text = dt.Rows[i][0].ToString();
                }
                for (int i = 0; i < Lineroot.Length; i++)
                {
                    this.HistoryRecordTree.Nodes.Add(Lineroot[i].Text, Lineroot[i].Text);
                    this.HistoryRecordTree.Nodes[i].Tag = "线路";
                }

                #endregion

                #region 加载公交历史列表

                for (int j = 0; j < Lineroot.Length; j++)
                {
                    string lineID = HistoryRecordTree.Nodes[j].Text.Trim();
                  
                    ITS_Manage.Model.Bus[] BusArrayForTree = ITS_Manage.BLL.BusManage.SelectBusArray(lineID);
                    if (BusArrayForTree.Length == 0)
                    {
                        continue;
                    }
                    TreeNode[] BusNodes = new TreeNode[BusArrayForTree.Length];
                    for (int i = 0; i < BusArrayForTree.Length; i++)
                    {

                        BusNodes[i] = new TreeNode(BusArrayForTree[i].busID);

                        BusNodes[i].Text = BusArrayForTree[i].busID;

                        this.HistoryRecordTree.Nodes[j].Nodes.Add(BusNodes[i].Text, BusNodes[i].Text);
                        this.HistoryRecordTree.Nodes[j].Nodes[i].Tag = "历史记录|车辆";
                    }
                }

                #endregion

                #endregion
            }
            catch (Exception ex)
            {
                //log
                MessageBox.Show("在线列表加载失败，请重启程序或联系系统管理员");
            }
        }



        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void treeList1_FocusedNodeChanged_1(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        private void navBarControl_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }


        #region 线程
        /*有问题部分，需等数据库设计完之后再更改
         * */
        //private void ShowLineC(object theline)
        //{
        //    ITS_Manage.Model.LineStationInfo line = (ITS_Manage.Model.LineStationInfo)theline;
        //    while (LineWCArray.Contains(line.LineID))  
        //    {
        //        MainMapOpration.ShowBusOnLine(ITS_Manage.DAL.BusRealInfo.GetBusRealInfoList(line.LineID), line.LineID);
        //    }
        //    if (!LineWCArray.Contains(line.LineID))
        //    {
        //        return;
        //    }
        //}

        #endregion



    }
}