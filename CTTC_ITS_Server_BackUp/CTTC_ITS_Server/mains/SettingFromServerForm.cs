using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTTC_ITS_Server
{
    /// <summary>
    /// 界面设置信息
    /// </summary>
    public class SettingFromServerForm
    {
        /// <summary>
        /// 管理端通信端口
        /// </summary>
        private int managePort;
        /// <summary>
        /// 管理端通信端口
        /// </summary>
        public int ManagePort
        {
            get
            {
                return managePort;
            }
            set
            {
                managePort = value;
            }
        }
        /// <summary>
        /// 界面设置信息构造函数
        /// </summary>
        /// <param name="MPort">管理端通信端口</param>
        public SettingFromServerForm(int MPort)
        {
            this.managePort = MPort;
        }
        public void SaveSettings(SettingFromServerForm NewSettings)
        { 
            
        }
    }
}
