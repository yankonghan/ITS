using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace CTTC_ITS_Server
{
    public partial class ServerMainForm : Form
    {
        public ServerMainForm()
        {
            InitializeComponent();
        }
        private MainThread mainThread;
        private void ServerMainForm_Load(object sender, EventArgs e)
        {
            InitServerMainForm();
            //Thread main = new Thread(
        }
        /// <summary>
        /// 初始化服务器主窗体
        /// </summary>
        private void InitServerMainForm()
        {

            ServerStartButton.Enabled = true;
            ServerStopButton.Enabled = false;
        }
        private void ServerMainForm_FormClosed(object sender, FormClosedEventArgs e)
        { 
            //关闭所有运行线程
        }

        private void ServerStartButton_Click(object sender, EventArgs e)
        {
            mainThread = new MainThread(this);
            this.FormClosed += ServerMainForm_FormClosed;
            ServerStartButton.Enabled = false;
            ServerStopButton.Enabled = true ;
        }

        private void ServerStopButton_Click(object sender, EventArgs e)
        {
            ServerStartButton.Enabled = true;
            ServerStopButton.Enabled = false;
            mainThread.ServerStop();
        }


    }
}
