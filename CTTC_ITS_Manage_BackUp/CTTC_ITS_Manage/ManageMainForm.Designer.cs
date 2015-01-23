using CTTC_ITS_Manage.UserControl;
namespace CTTC_ITS_Manage
{
    partial class ManageMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageMainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("车辆监控");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("站点监控");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("部门列表");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("部门信息", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("人员列表");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("管理员列表");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("岗位类型");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("人员档案", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("出租车列表");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("出租车管理", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("公交车列表");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("公交车管理", new System.Windows.Forms.TreeNode[] {
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("车辆管理", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("线路列表");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("站点列表");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("线路信息", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("自动排班");
            this.navbarImageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.navbarImageList = new System.Windows.Forms.ImageList(this.components);
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.appMenu = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.popupControlContainer2 = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.buttonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.popupControlContainer1 = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.someLabelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.someLabelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ribbonImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.iBoldFontStyle = new DevExpress.XtraBars.BarButtonItem();
            this.iItalicFontStyle = new DevExpress.XtraBars.BarButtonItem();
            this.iUnderlinedFontStyle = new DevExpress.XtraBars.BarButtonItem();
            this.iLeftTextAlign = new DevExpress.XtraBars.BarButtonItem();
            this.iCenterTextAlign = new DevExpress.XtraBars.BarButtonItem();
            this.iRightTextAlign = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonImageCollectionLarge = new DevExpress.Utils.ImageCollection(this.components);
            this.ManageOnLineToolRibbon = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.fileRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup12 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup13 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup14 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup15 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup16 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup17 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup18 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.HistoryRecordToolRibbon = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.formatRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup19 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ReportToolRibbon = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup20 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup21 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup22 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup23 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup24 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.BasicInfoToolRibbon = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup25 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup26 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup27 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup28 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup29 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup30 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup31 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.HelpToolRibbon = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup32 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup33 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup34 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup35 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup36 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup37 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup38 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup39 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.skinsRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.ManageOnLineGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.ManageOnlineTree = new System.Windows.Forms.TreeView();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.HistoryRecordTree = new System.Windows.Forms.TreeView();
            this.navBarGroupControlContainer3 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.BasicInfoTreeView = new System.Windows.Forms.TreeView();
            this.HistoryRecordGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.ReportCenterGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.BasicInfoGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.NameTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.MainMap = new GMap.NET.WindowsForms.GMapControl();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer2)).BeginInit();
            this.popupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).BeginInit();
            this.popupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            this.navBarControl.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.navBarGroupControlContainer2.SuspendLayout();
            this.navBarGroupControlContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.NameTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // navbarImageListLarge
            // 
            this.navbarImageListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("navbarImageListLarge.ImageStream")));
            this.navbarImageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.navbarImageListLarge.Images.SetKeyName(0, "Mail_32x32.png");
            this.navbarImageListLarge.Images.SetKeyName(1, "Organizer_32x32.png");
            // 
            // navbarImageList
            // 
            this.navbarImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("navbarImageList.ImageStream")));
            this.navbarImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.navbarImageList.Images.SetKeyName(0, "Inbox_16x16.png");
            this.navbarImageList.Images.SetKeyName(1, "Outbox_16x16.png");
            this.navbarImageList.Images.SetKeyName(2, "Drafts_16x16.png");
            this.navbarImageList.Images.SetKeyName(3, "Trash_16x16.png");
            this.navbarImageList.Images.SetKeyName(4, "Calendar_16x16.png");
            this.navbarImageList.Images.SetKeyName(5, "Tasks_16x16.png");
            // 
            // ribbonControl
            // 
            this.ribbonControl.ApplicationButtonDropDownControl = this.appMenu;
            this.ribbonControl.ApplicationButtonText = null;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.ExpandCollapseItem.Name = "";
            this.ribbonControl.Images = this.ribbonImageCollection;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.iBoldFontStyle,
            this.iItalicFontStyle,
            this.iUnderlinedFontStyle,
            this.iLeftTextAlign,
            this.iCenterTextAlign,
            this.iRightTextAlign});
            this.ribbonControl.LargeImages = this.ribbonImageCollectionLarge;
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 63;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ManageOnLineToolRibbon,
            this.HistoryRecordToolRibbon,
            this.ReportToolRibbon,
            this.BasicInfoToolRibbon,
            this.HelpToolRibbon});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice;
            this.ribbonControl.Size = new System.Drawing.Size(1100, 133);
            this.ribbonControl.Click += new System.EventHandler(this.ribbonControl_Click);
            // 
            // appMenu
            // 
            this.appMenu.BottomPaneControlContainer = this.popupControlContainer2;
            this.appMenu.Name = "appMenu";
            this.appMenu.Ribbon = this.ribbonControl;
            this.appMenu.RightPaneControlContainer = this.popupControlContainer1;
            this.appMenu.ShowRightPane = true;
            // 
            // popupControlContainer2
            // 
            this.popupControlContainer2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.popupControlContainer2.Appearance.Options.UseBackColor = true;
            this.popupControlContainer2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainer2.Controls.Add(this.buttonEdit);
            this.popupControlContainer2.Location = new System.Drawing.Point(238, 289);
            this.popupControlContainer2.Name = "popupControlContainer2";
            this.popupControlContainer2.Ribbon = this.ribbonControl;
            this.popupControlContainer2.Size = new System.Drawing.Size(118, 28);
            this.popupControlContainer2.TabIndex = 3;
            this.popupControlContainer2.Visible = false;
            // 
            // buttonEdit
            // 
            this.buttonEdit.EditValue = "Some Text";
            this.buttonEdit.Location = new System.Drawing.Point(3, 5);
            this.buttonEdit.MenuManager = this.ribbonControl;
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit.Size = new System.Drawing.Size(100, 20);
            this.buttonEdit.TabIndex = 0;
            // 
            // popupControlContainer1
            // 
            this.popupControlContainer1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.popupControlContainer1.Appearance.Options.UseBackColor = true;
            this.popupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainer1.Controls.Add(this.someLabelControl2);
            this.popupControlContainer1.Controls.Add(this.someLabelControl1);
            this.popupControlContainer1.Location = new System.Drawing.Point(111, 197);
            this.popupControlContainer1.Name = "popupControlContainer1";
            this.popupControlContainer1.Ribbon = this.ribbonControl;
            this.popupControlContainer1.Size = new System.Drawing.Size(76, 70);
            this.popupControlContainer1.TabIndex = 2;
            this.popupControlContainer1.Visible = false;
            // 
            // someLabelControl2
            // 
            this.someLabelControl2.Location = new System.Drawing.Point(3, 57);
            this.someLabelControl2.Name = "someLabelControl2";
            this.someLabelControl2.Size = new System.Drawing.Size(57, 14);
            this.someLabelControl2.TabIndex = 0;
            this.someLabelControl2.Text = "Some Info";
            // 
            // someLabelControl1
            // 
            this.someLabelControl1.Location = new System.Drawing.Point(3, 3);
            this.someLabelControl1.Name = "someLabelControl1";
            this.someLabelControl1.Size = new System.Drawing.Size(57, 14);
            this.someLabelControl1.TabIndex = 0;
            this.someLabelControl1.Text = "Some Info";
            // 
            // ribbonImageCollection
            // 
            this.ribbonImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ribbonImageCollection.ImageStream")));
            this.ribbonImageCollection.Images.SetKeyName(0, "Ribbon_New_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(1, "Ribbon_Open_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(2, "Ribbon_Close_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(3, "Ribbon_Find_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(4, "Ribbon_Save_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(5, "Ribbon_SaveAs_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(6, "Ribbon_Exit_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(7, "Ribbon_Content_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(8, "Ribbon_Info_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(9, "Ribbon_Bold_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(10, "Ribbon_Italic_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(11, "Ribbon_Underline_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(12, "Ribbon_AlignLeft_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(13, "Ribbon_AlignCenter_16x16.png");
            this.ribbonImageCollection.Images.SetKeyName(14, "Ribbon_AlignRight_16x16.png");
            // 
            // iBoldFontStyle
            // 
            this.iBoldFontStyle.Caption = "Bold";
            this.iBoldFontStyle.Id = 53;
            this.iBoldFontStyle.ImageIndex = 9;
            this.iBoldFontStyle.Name = "iBoldFontStyle";
            // 
            // iItalicFontStyle
            // 
            this.iItalicFontStyle.Caption = "Italic";
            this.iItalicFontStyle.Id = 54;
            this.iItalicFontStyle.ImageIndex = 10;
            this.iItalicFontStyle.Name = "iItalicFontStyle";
            // 
            // iUnderlinedFontStyle
            // 
            this.iUnderlinedFontStyle.Caption = "Underlined";
            this.iUnderlinedFontStyle.Id = 55;
            this.iUnderlinedFontStyle.ImageIndex = 11;
            this.iUnderlinedFontStyle.Name = "iUnderlinedFontStyle";
            // 
            // iLeftTextAlign
            // 
            this.iLeftTextAlign.Caption = "Left";
            this.iLeftTextAlign.Id = 57;
            this.iLeftTextAlign.ImageIndex = 12;
            this.iLeftTextAlign.Name = "iLeftTextAlign";
            // 
            // iCenterTextAlign
            // 
            this.iCenterTextAlign.Caption = "Center";
            this.iCenterTextAlign.Id = 58;
            this.iCenterTextAlign.ImageIndex = 13;
            this.iCenterTextAlign.Name = "iCenterTextAlign";
            // 
            // iRightTextAlign
            // 
            this.iRightTextAlign.Caption = "Right";
            this.iRightTextAlign.Id = 59;
            this.iRightTextAlign.ImageIndex = 14;
            this.iRightTextAlign.Name = "iRightTextAlign";
            // 
            // ribbonImageCollectionLarge
            // 
            this.ribbonImageCollectionLarge.ImageSize = new System.Drawing.Size(32, 32);
            this.ribbonImageCollectionLarge.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ribbonImageCollectionLarge.ImageStream")));
            this.ribbonImageCollectionLarge.Images.SetKeyName(0, "Ribbon_New_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(1, "Ribbon_Open_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(2, "Ribbon_Close_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(3, "Ribbon_Find_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(4, "Ribbon_Save_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(5, "Ribbon_SaveAs_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(6, "Ribbon_Exit_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(7, "Ribbon_Content_32x32.png");
            this.ribbonImageCollectionLarge.Images.SetKeyName(8, "Ribbon_Info_32x32.png");
            // 
            // ManageOnLineToolRibbon
            // 
            this.ManageOnLineToolRibbon.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.fileRibbonPageGroup,
            this.ribbonPageGroup9,
            this.ribbonPageGroup10,
            this.ribbonPageGroup11,
            this.ribbonPageGroup12,
            this.ribbonPageGroup13,
            this.ribbonPageGroup14,
            this.ribbonPageGroup15,
            this.ribbonPageGroup16,
            this.ribbonPageGroup17,
            this.ribbonPageGroup18});
            this.ManageOnLineToolRibbon.Name = "ManageOnLineToolRibbon";
            this.ManageOnLineToolRibbon.Tag = ((short)(0));
            this.ManageOnLineToolRibbon.Text = "在线监控";
            // 
            // fileRibbonPageGroup
            // 
            this.fileRibbonPageGroup.ImageIndex = 12;
            this.fileRibbonPageGroup.Name = "fileRibbonPageGroup";
            this.fileRibbonPageGroup.Text = "File";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.ImageIndex = 7;
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.Text = "File";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.Text = "File";
            // 
            // ribbonPageGroup11
            // 
            this.ribbonPageGroup11.Name = "ribbonPageGroup11";
            this.ribbonPageGroup11.Text = "File";
            // 
            // ribbonPageGroup12
            // 
            this.ribbonPageGroup12.Name = "ribbonPageGroup12";
            this.ribbonPageGroup12.Text = "File";
            // 
            // ribbonPageGroup13
            // 
            this.ribbonPageGroup13.Name = "ribbonPageGroup13";
            this.ribbonPageGroup13.Text = "File";
            // 
            // ribbonPageGroup14
            // 
            this.ribbonPageGroup14.Name = "ribbonPageGroup14";
            this.ribbonPageGroup14.Text = "File";
            // 
            // ribbonPageGroup15
            // 
            this.ribbonPageGroup15.Name = "ribbonPageGroup15";
            this.ribbonPageGroup15.Text = "File";
            // 
            // ribbonPageGroup16
            // 
            this.ribbonPageGroup16.Name = "ribbonPageGroup16";
            this.ribbonPageGroup16.Text = "File";
            // 
            // ribbonPageGroup17
            // 
            this.ribbonPageGroup17.Name = "ribbonPageGroup17";
            this.ribbonPageGroup17.Text = "File";
            // 
            // ribbonPageGroup18
            // 
            this.ribbonPageGroup18.Name = "ribbonPageGroup18";
            this.ribbonPageGroup18.Text = "File";
            // 
            // HistoryRecordToolRibbon
            // 
            this.HistoryRecordToolRibbon.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.formatRibbonPageGroup,
            this.ribbonPageGroup6,
            this.ribbonPageGroup8,
            this.ribbonPageGroup19});
            this.HistoryRecordToolRibbon.Name = "HistoryRecordToolRibbon";
            this.HistoryRecordToolRibbon.Tag = ((short)(2));
            this.HistoryRecordToolRibbon.Text = "历史轨迹";
            // 
            // formatRibbonPageGroup
            // 
            this.formatRibbonPageGroup.Name = "formatRibbonPageGroup";
            this.formatRibbonPageGroup.Text = "Format";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Format";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.Text = "Format";
            // 
            // ribbonPageGroup19
            // 
            this.ribbonPageGroup19.ImageIndex = 2;
            this.ribbonPageGroup19.Name = "ribbonPageGroup19";
            this.ribbonPageGroup19.Text = "Format";
            // 
            // ReportToolRibbon
            // 
            this.ReportToolRibbon.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup7,
            this.ribbonPageGroup20,
            this.ribbonPageGroup21,
            this.ribbonPageGroup22,
            this.ribbonPageGroup23,
            this.ribbonPageGroup24});
            this.ReportToolRibbon.Name = "ReportToolRibbon";
            this.ReportToolRibbon.Tag = ((short)(3));
            this.ReportToolRibbon.Text = "报表中心";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "Format";
            // 
            // ribbonPageGroup20
            // 
            this.ribbonPageGroup20.Name = "ribbonPageGroup20";
            this.ribbonPageGroup20.Text = "Format";
            // 
            // ribbonPageGroup21
            // 
            this.ribbonPageGroup21.Name = "ribbonPageGroup21";
            this.ribbonPageGroup21.Text = "Format";
            // 
            // ribbonPageGroup22
            // 
            this.ribbonPageGroup22.Name = "ribbonPageGroup22";
            this.ribbonPageGroup22.Text = "Format";
            // 
            // ribbonPageGroup23
            // 
            this.ribbonPageGroup23.Name = "ribbonPageGroup23";
            this.ribbonPageGroup23.Text = "Format";
            // 
            // ribbonPageGroup24
            // 
            this.ribbonPageGroup24.Name = "ribbonPageGroup24";
            this.ribbonPageGroup24.Text = "Format";
            // 
            // BasicInfoToolRibbon
            // 
            this.BasicInfoToolRibbon.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup25,
            this.ribbonPageGroup26,
            this.ribbonPageGroup27,
            this.ribbonPageGroup28,
            this.ribbonPageGroup29,
            this.ribbonPageGroup30,
            this.ribbonPageGroup31});
            this.BasicInfoToolRibbon.Name = "BasicInfoToolRibbon";
            this.BasicInfoToolRibbon.Tag = ((short)(4));
            this.BasicInfoToolRibbon.Text = "基础档案";
            // 
            // ribbonPageGroup25
            // 
            this.ribbonPageGroup25.Name = "ribbonPageGroup25";
            this.ribbonPageGroup25.Text = "Format";
            // 
            // ribbonPageGroup26
            // 
            this.ribbonPageGroup26.Name = "ribbonPageGroup26";
            this.ribbonPageGroup26.Text = "Format";
            // 
            // ribbonPageGroup27
            // 
            this.ribbonPageGroup27.Name = "ribbonPageGroup27";
            this.ribbonPageGroup27.Text = "Format";
            // 
            // ribbonPageGroup28
            // 
            this.ribbonPageGroup28.Name = "ribbonPageGroup28";
            this.ribbonPageGroup28.Text = "Format";
            // 
            // ribbonPageGroup29
            // 
            this.ribbonPageGroup29.Name = "ribbonPageGroup29";
            this.ribbonPageGroup29.Text = "Format";
            // 
            // ribbonPageGroup30
            // 
            this.ribbonPageGroup30.Name = "ribbonPageGroup30";
            this.ribbonPageGroup30.Text = "Format";
            // 
            // ribbonPageGroup31
            // 
            this.ribbonPageGroup31.Name = "ribbonPageGroup31";
            this.ribbonPageGroup31.Text = "Format";
            // 
            // HelpToolRibbon
            // 
            this.HelpToolRibbon.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup32,
            this.ribbonPageGroup33,
            this.ribbonPageGroup34,
            this.ribbonPageGroup35,
            this.ribbonPageGroup36,
            this.ribbonPageGroup37,
            this.ribbonPageGroup38,
            this.ribbonPageGroup39});
            this.HelpToolRibbon.Name = "HelpToolRibbon";
            this.HelpToolRibbon.Text = "帮助";
            // 
            // ribbonPageGroup32
            // 
            this.ribbonPageGroup32.Name = "ribbonPageGroup32";
            this.ribbonPageGroup32.Text = "Format";
            // 
            // ribbonPageGroup33
            // 
            this.ribbonPageGroup33.Name = "ribbonPageGroup33";
            this.ribbonPageGroup33.Text = "Format";
            // 
            // ribbonPageGroup34
            // 
            this.ribbonPageGroup34.Name = "ribbonPageGroup34";
            this.ribbonPageGroup34.Text = "Format";
            // 
            // ribbonPageGroup35
            // 
            this.ribbonPageGroup35.Name = "ribbonPageGroup35";
            this.ribbonPageGroup35.Text = "Format";
            // 
            // ribbonPageGroup36
            // 
            this.ribbonPageGroup36.Name = "ribbonPageGroup36";
            this.ribbonPageGroup36.Text = "Format";
            // 
            // ribbonPageGroup37
            // 
            this.ribbonPageGroup37.Name = "ribbonPageGroup37";
            this.ribbonPageGroup37.Text = "Format";
            // 
            // ribbonPageGroup38
            // 
            this.ribbonPageGroup38.Name = "ribbonPageGroup38";
            this.ribbonPageGroup38.Text = "Format";
            // 
            // ribbonPageGroup39
            // 
            this.ribbonPageGroup39.Name = "ribbonPageGroup39";
            this.ribbonPageGroup39.Text = "Format";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // skinsRibbonPageGroup
            // 
            this.skinsRibbonPageGroup.Name = "skinsRibbonPageGroup";
            this.skinsRibbonPageGroup.ShowCaptionButton = false;
            this.skinsRibbonPageGroup.Text = "Skins";
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.ManageOnLineGroup;
            this.navBarControl.Controls.Add(this.navBarGroupControlContainer1);
            this.navBarControl.Controls.Add(this.navBarGroupControlContainer2);
            this.navBarControl.Controls.Add(this.navBarGroupControlContainer3);
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.ManageOnLineGroup,
            this.HistoryRecordGroup,
            this.ReportCenterGroup,
            this.BasicInfoGroup});
            this.navBarControl.LargeImages = this.navbarImageListLarge;
            this.navBarControl.Location = new System.Drawing.Point(0, 0);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 226;
            this.navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl.Size = new System.Drawing.Size(226, 547);
            this.navBarControl.SmallImages = this.navbarImageList;
            this.navBarControl.StoreDefaultPaintStyleName = true;
            this.navBarControl.TabIndex = 1;
            this.navBarControl.Text = "navBarControl1";
            this.navBarControl.Click += new System.EventHandler(this.navBarControl_Click);
            // 
            // ManageOnLineGroup
            // 
            this.ManageOnLineGroup.Caption = "在线监控";
            this.ManageOnLineGroup.ControlContainer = this.navBarGroupControlContainer1;
            this.ManageOnLineGroup.Expanded = true;
            this.ManageOnLineGroup.GroupClientHeight = 80;
            this.ManageOnLineGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.ManageOnLineGroup.LargeImage = ((System.Drawing.Image)(resources.GetObject("ManageOnLineGroup.LargeImage")));
            this.ManageOnLineGroup.LargeImageIndex = 0;
            this.ManageOnLineGroup.Name = "ManageOnLineGroup";
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.ManageOnlineTree);
            this.navBarGroupControlContainer1.Controls.Add(this.navBarControl1);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(226, 288);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // ManageOnlineTree
            // 
            this.ManageOnlineTree.BackColor = System.Drawing.SystemColors.Menu;
            this.ManageOnlineTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ManageOnlineTree.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageOnlineTree.ItemHeight = 18;
            this.ManageOnlineTree.LineColor = System.Drawing.Color.Gray;
            this.ManageOnlineTree.Location = new System.Drawing.Point(0, 0);
            this.ManageOnlineTree.Name = "ManageOnlineTree";
            treeNode1.Name = "BusManageNode";
            treeNode1.Text = "车辆监控";
            treeNode2.Name = "StopManageNode";
            treeNode2.Text = "站点监控";
            this.ManageOnlineTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.ManageOnlineTree.Size = new System.Drawing.Size(226, 288);
            this.ManageOnlineTree.TabIndex = 1;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = null;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 226;
            this.navBarControl1.Size = new System.Drawing.Size(226, 288);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Controls.Add(this.HistoryRecordTree);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(231, 251);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // HistoryRecordTree
            // 
            this.HistoryRecordTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistoryRecordTree.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoryRecordTree.Location = new System.Drawing.Point(0, 0);
            this.HistoryRecordTree.Name = "HistoryRecordTree";
            this.HistoryRecordTree.Size = new System.Drawing.Size(231, 251);
            this.HistoryRecordTree.TabIndex = 0;
            // 
            // navBarGroupControlContainer3
            // 
            this.navBarGroupControlContainer3.Controls.Add(this.BasicInfoTreeView);
            this.navBarGroupControlContainer3.Name = "navBarGroupControlContainer3";
            this.navBarGroupControlContainer3.Size = new System.Drawing.Size(226, 288);
            this.navBarGroupControlContainer3.TabIndex = 2;
            // 
            // BasicInfoTreeView
            // 
            this.BasicInfoTreeView.BackColor = System.Drawing.SystemColors.Menu;
            this.BasicInfoTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasicInfoTreeView.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BasicInfoTreeView.FullRowSelect = true;
            this.BasicInfoTreeView.ItemHeight = 20;
            this.BasicInfoTreeView.Location = new System.Drawing.Point(0, 0);
            this.BasicInfoTreeView.Name = "BasicInfoTreeView";
            treeNode3.Name = "DepartmentListNode";
            treeNode3.Tag = "部门列表";
            treeNode3.Text = "部门列表";
            treeNode4.Name = "DepartmentInfoRootNode";
            treeNode4.Tag = "部门信息";
            treeNode4.Text = "部门信息";
            treeNode5.Name = "PersonList";
            treeNode5.Tag = "人员列表";
            treeNode5.Text = "人员列表";
            treeNode6.Name = "节点2";
            treeNode6.Tag = "管理员列表";
            treeNode6.Text = "管理员列表";
            treeNode7.Name = "DutyTypeNode";
            treeNode7.Tag = "岗位类型";
            treeNode7.Text = "岗位类型";
            treeNode8.Name = "PersonRootNode";
            treeNode8.Tag = "人员档案";
            treeNode8.Text = "人员档案";
            treeNode9.Name = "TaxiListNode";
            treeNode9.Tag = "出租车列表";
            treeNode9.Text = "出租车列表";
            treeNode10.Name = "TaxiManageNode";
            treeNode10.Tag = "出租车管理";
            treeNode10.Text = "出租车管理";
            treeNode11.Name = "BusListNode";
            treeNode11.Tag = "公交车列表";
            treeNode11.Text = "公交车列表";
            treeNode12.Name = "BusManageNode";
            treeNode12.Tag = "公交车管理";
            treeNode12.Text = "公交车管理";
            treeNode13.Name = "ManagementRootNode";
            treeNode13.Tag = "车辆管理";
            treeNode13.Text = "车辆管理";
            treeNode14.Name = "LineListNode";
            treeNode14.Tag = "线路列表";
            treeNode14.Text = "线路列表";
            treeNode15.Name = "StopListNode";
            treeNode15.Tag = "站点列表";
            treeNode15.Text = "站点列表";
            treeNode16.Name = "LineInfoRootNode";
            treeNode16.Tag = "线路信息";
            treeNode16.Text = "线路信息";
            treeNode17.Name = "AutoDutyRootNode";
            treeNode17.Tag = "自动排班";
            treeNode17.Text = "自动排班";
            this.BasicInfoTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode8,
            treeNode13,
            treeNode16,
            treeNode17});
            this.BasicInfoTreeView.Size = new System.Drawing.Size(226, 288);
            this.BasicInfoTreeView.TabIndex = 0;
            // 
            // HistoryRecordGroup
            // 
            this.HistoryRecordGroup.Caption = "历史轨迹";
            this.HistoryRecordGroup.ControlContainer = this.navBarGroupControlContainer2;
            this.HistoryRecordGroup.GroupClientHeight = 80;
            this.HistoryRecordGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.HistoryRecordGroup.LargeImage = ((System.Drawing.Image)(resources.GetObject("HistoryRecordGroup.LargeImage")));
            this.HistoryRecordGroup.LargeImageIndex = 1;
            this.HistoryRecordGroup.Name = "HistoryRecordGroup";
            // 
            // ReportCenterGroup
            // 
            this.ReportCenterGroup.Caption = "报表中心";
            this.ReportCenterGroup.LargeImage = ((System.Drawing.Image)(resources.GetObject("ReportCenterGroup.LargeImage")));
            this.ReportCenterGroup.Name = "ReportCenterGroup";
            // 
            // BasicInfoGroup
            // 
            this.BasicInfoGroup.Caption = "基础档案";
            this.BasicInfoGroup.ControlContainer = this.navBarGroupControlContainer3;
            this.BasicInfoGroup.GroupClientHeight = 80;
            this.BasicInfoGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.BasicInfoGroup.LargeImage = ((System.Drawing.Image)(resources.GetObject("BasicInfoGroup.LargeImage")));
            this.BasicInfoGroup.Name = "BasicInfoGroup";
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 133);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Padding = new System.Windows.Forms.Padding(6);
            this.splitContainerControl.Panel1.Controls.Add(this.navBarControl);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(1100, 563);
            this.splitContainerControl.SplitterPosition = 226;
            this.splitContainerControl.TabIndex = 0;
            this.splitContainerControl.Text = "splitContainerControl1";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.NameTabPage;
            this.xtraTabControl1.Size = new System.Drawing.Size(853, 547);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.NameTabPage});
            this.xtraTabControl1.Click += new System.EventHandler(this.xtraTabControl1_Click);
            // 
            // NameTabPage
            // 
            this.NameTabPage.Controls.Add(this.MainMap);
            this.NameTabPage.Name = "NameTabPage";
            this.NameTabPage.Size = new System.Drawing.Size(847, 518);
            this.NameTabPage.Text = "在线实时监控";
            // 
            // MainMap
            // 
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(0, 0);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 18;
            this.MainMap.MinZoom = 0;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(847, 518);
            this.MainMap.TabIndex = 1;
            this.MainMap.Zoom = 12D;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Format";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Format";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 0;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1100, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 696);
            this.barDockControlBottom.Size = new System.Drawing.Size(1100, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 696);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1100, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 696);
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "File";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "File";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "File";
            // 
            // ManageMainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 696);
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.ribbonControl);
            this.Controls.Add(this.popupControlContainer1);
            this.Controls.Add(this.popupControlContainer2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageMainForm";
            this.Ribbon = this.ribbonControl;
            this.Text = "程天科技智能公交管理平台";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ManageMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer2)).EndInit();
            this.popupControlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).EndInit();
            this.popupControlContainer1.ResumeLayout(false);
            this.popupControlContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonImageCollectionLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            this.navBarControl.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.navBarGroupControlContainer2.ResumeLayout(false);
            this.navBarGroupControlContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.NameTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem iBoldFontStyle;
        private DevExpress.XtraBars.BarButtonItem iItalicFontStyle;
        private DevExpress.XtraBars.BarButtonItem iUnderlinedFontStyle;
        private DevExpress.XtraBars.BarButtonItem iLeftTextAlign;
        private DevExpress.XtraBars.BarButtonItem iCenterTextAlign;
        private DevExpress.XtraBars.BarButtonItem iRightTextAlign;
        private DevExpress.XtraBars.Ribbon.RibbonPage ManageOnLineToolRibbon;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup fileRibbonPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup formatRibbonPageGroup;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu appMenu;
        private DevExpress.XtraBars.PopupControlContainer popupControlContainer1;
        private DevExpress.XtraEditors.LabelControl someLabelControl2;
        private DevExpress.XtraEditors.LabelControl someLabelControl1;
        private DevExpress.XtraBars.PopupControlContainer popupControlContainer2;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit;
        private DevExpress.Utils.ImageCollection ribbonImageCollection;
        private DevExpress.Utils.ImageCollection ribbonImageCollectionLarge;
        private System.Windows.Forms.ImageList navbarImageList;
        private System.Windows.Forms.ImageList navbarImageListLarge;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private DevExpress.XtraBars.Ribbon.RibbonPage HistoryRecordToolRibbon;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup skinsRibbonPageGroup;
        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup ManageOnLineGroup;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private System.Windows.Forms.TreeView ManageOnlineTree;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private System.Windows.Forms.TreeView HistoryRecordTree;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer3;
        private DevExpress.XtraNavBar.NavBarGroup HistoryRecordGroup;
        private DevExpress.XtraNavBar.NavBarGroup ReportCenterGroup;
        private DevExpress.XtraNavBar.NavBarGroup BasicInfoGroup;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.TreeView BasicInfoTreeView;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage NameTabPage;
        private GMap.NET.WindowsForms.GMapControl MainMap;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup11;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup12;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup13;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup14;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup15;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup16;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup17;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup18;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup19;
        private DevExpress.XtraBars.Ribbon.RibbonPage ReportToolRibbon;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup20;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup21;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup22;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup23;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup24;
        private DevExpress.XtraBars.Ribbon.RibbonPage BasicInfoToolRibbon;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup25;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup26;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup27;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup28;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup29;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup30;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup31;
        private DevExpress.XtraBars.Ribbon.RibbonPage HelpToolRibbon;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup32;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup33;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup34;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup35;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup36;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup37;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup38;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup39;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private UserControl.StreetLineControl streetLineControl1;
        private shishi shishi1;

    }
}
