using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Collections;
using System.Data;
using CommonClassLibrary;
using System.Net;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System.IO;
using CTTC_ITS_Server.mains;
using System.Configuration;
using System.Windows.Forms;

namespace CTTC_ITS_Server
{
    public class MainThread
    {

        private ServerMainForm serverFrm;
        protected string ProvinceID = ConfigurationManager.AppSettings["Province"];
        protected CTTCServer appServer;
        public MainThread(ServerMainForm Form)
        {
            serverFrm = Form;
            #region 服务器网络参数初始化

            appServer = new CTTCServer();

            #region server 属性和配置
            //maxWorkingThreads: 线程池最大工作线程数量;
            //minWorkingThreads: 线程池最小工作线程数量;
            //maxCompletionPortThreads: 线程池最大完成端口线程数量;
            //minCompletionPortThreads: 线程池最小完成端口线程数量;
            //disablePerformanceDataCollector: 是否禁用性能数据采集;
            //performanceDataCollectInterval: 性能数据采集频率 (单位为秒, 默认值: 60);
            //isolation: SuperSocket 服务器实例隔离级别
            //None - 无隔离
            //AppDomain - 应用程序域级别的隔离，多个服务器实例运行在各自独立的应用程序域之中
            //Process - 进程级别的隔离，多个服务器实例运行在各自独立的进程之中
            //logFactory: 默认logFactory的名字, 所有可用的 log factories定义在子节点 "logFactories" 之中， 我们将会在下面的文档中介绍它;
            //defaultCulture: 整个程序的默认 thread culture，只在.Net 4.5中可用;

            //Server 的所有属性如下:

            //name: 服务器实例的名称;
            //serverType: 服务器实例的类型的完整名称;
            //serverTypeName: 所选用的服务器类型在 serverTypes 节点的名字，配置节点 serverTypes 用于定义所有可用的服务器类型，我们将在后面再做详细介绍;
            //ip: 服务器监听的ip地址。你可以设置具体的地址，也可以设置为下面的值 Any - 所有的IPv4地址 IPv6Any - 所有的IPv6地址
            //port: 服务器监听的端口;
            //listenBacklog: 监听队列的大小;
            //mode: Socket服务器运行的模式, Tcp (默认) 或者 Udp;
            //disabled: 服务器实例是否禁用了;
            //startupOrder: 服务器实例启动顺序, bootstrap 将按照此值的顺序来启动多个服务器实例;
            //sendTimeOut: 发送数据超时时间;
            //sendingQueueSize: 发送队列最大长度;
            //maxConnectionNumber: 可允许连接的最大连接数;
            //receiveBufferSize: 接收缓冲区大小;
            //sendBufferSize: 发送缓冲区大小;
            //syncSend: 是否启用同步发送模式, 默认值: false;
            //logCommand: 是否记录命令执行的记录;
            //logBasicSessionActivity: 是否记录session的基本基本活动，如连接和断开;
            //clearIdleSession: true 或 false, 是否定时清空空闲会话，默认值是 false;
            //clearIdleSessionInterval: 清空空闲会话的时间间隔, 默认值是120, 单位为秒;
            //idleSessionTimeOut: 会话超时时间，默认值为300，单位为秒;
            //security: Empty, Tls, Ssl3. Socket服务器所采用的传输层加密协议，默认值为空;
            //maxRequestLength: 最大允许的请求长度，默认值为1024;
            //textEncoding: 文本的默认编码，默认值是 ASCII;
            //defaultCulture: 此服务器实例的默认 thread culture, 只在.Net 4.5中可用而且在隔离级别为 'None' 时无效;
            //disableSessionSnapshot: 是否禁用会话快照, 默认值为 false.
            //sessionSnapshotInterval: 会话快照时间间隔, 默认值是 5, 单位为秒;
            //keepAliveTime: 网络连接正常情况下的keep alive数据的发送间隔, 默认值为 600, 单位为秒;
            //keepAliveInterval: Keep alive失败之后, keep alive探测包的发送间隔，默认值为 60, 单位为秒;
            //certificate: 这各节点用于定义用于此服务器实例的X509Certificate证书的信息
            #endregion

            var serverConfig = new ServerConfig
            {
                Port = 9900,
                Mode = SocketMode.Tcp,
                MaxConnectionNumber = 10000,
                SendTimeOut = 5000,
                ReceiveBufferSize = 10240,
            };
            if (!appServer.Setup(serverConfig))
            {
                ShowOnListBox("服务器设置失败");
                return;
            }
            if (!appServer.Start())
            {
                ShowOnListBox("服务器启动失败");
                return;
            }
            #region 注册事件

            appServer.NewSessionConnected += new SessionHandler<TerminalSession>(appServer_NewSessionConnected);
            appServer.NewRequestReceived += new RequestHandler<TerminalSession, TerminalRequestInfo>(appServer_NewRequestReceived);
            appServer.SessionClosed += new SessionHandler<TerminalSession, SuperSocket.SocketBase.CloseReason>(appServer_SessionClosed);

            #endregion

            #endregion

            ShowOnListBox("服务器已启动");
            fs = new FileStream(@"D:\log.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, 8);
            serverFrm.ServerStopButton.Click += new EventHandler(ServerStopButton_Click);

        }

        FileStream fs;

        public static int offset;
        /// <summary>
        /// 
        /// </summary>
        public void ServerStop()
        {
            appServer.Stop();
            ShowOnListBox("服务器停止");
        }
        private void appServer_SessionClosed(TerminalSession session, SuperSocket.SocketBase.CloseReason theReason)
        {
            string TheBusID = ProvinceID + session.TerminalSessionID.Split('|')[0];
            string log = session.TerminalSessionID + "terminal offline" + " connect time：" + session.StartTime.ToString();
            DBUpdateOnOfOffLine(TheBusID, "OFF");

            ShowOnListBox(session.TerminalSessionID.Split('|')[0] + " " + session.LastActiveTime.ToString() + " 离线");
            #region log



            #endregion
        }
        private void appServer_NewSessionConnected(TerminalSession session)
        {
            string log = session.TerminalSessionID + "terminal online";
            session.TrySend(new byte[] { 0xff, 0xfe, 0xee, 0xef }, 0, 4);
        }
        private void appServer_NewRequestReceived(TerminalSession session, TerminalRequestInfo RequestInfo)
        {
            switch (RequestInfo.TerminalType)
            {
                case TerminalType.BusTerminal:
                    //会话ID，例A12345|2013/02/04 08:01:01
                    session.TerminalSessionID = ProvinceID + RequestInfo.BusID + "|" + RequestInfo.InfoTime.ToString();

                    switch (RequestInfo.InfoType)
                    {
                        case InfoType.Online:
                            DBUpdateOnOfOffLine(ProvinceID + RequestInfo.BusID, "ON");
                            ShowOnListBox(ProvinceID + RequestInfo.BusID + " " + RequestInfo.InfoTime.ToString() + " 上线");
                            break;
                        case InfoType.Offline:
                            DBUpdateOnOfOffLine(ProvinceID + RequestInfo.BusID, "OFF");
                            ShowOnListBox(ProvinceID + RequestInfo.BusID + " " + RequestInfo.InfoTime.ToString() + " 下线");
                            break;
                        case InfoType.AlarmInfo:
                            DBUpdateALarm(ProvinceID + RequestInfo.BusID, "ALARM");
                            ShowOnListBox(ProvinceID + RequestInfo.BusID + " " + RequestInfo.InfoTime.ToString() + " 报警");
                            break;
                        case InfoType.RealTimeInfo:
                            #region 注释
                            string strSql = "INSERT INTO Bus_RealTime(Bus_ID,RealTime,Speed,Num_People,Lat,Lng,OilRemain,IsAlarm,Driver_ID,Forward)VALUES('" 
                                             + ProvinceID + RequestInfo.BusID + "'," 
                                             + "convert(datetime,'" + RequestInfo.InfoTime.ToString() + "', 121)," 
                                             + RequestInfo.Speed.ToString() + ","
                                             + RequestInfo.PeopleNumber.ToString() + ","
                                             + RequestInfo.Lat.ToString() + ","
                                             + RequestInfo.Lng.ToString() + ","
                                             + RequestInfo.Oil.ToString() + ","
                                             + "0" + ", '"
                                             + RequestInfo.DriverID + "','"
                                             + RequestInfo.Forward.ToString() + "')";
                            DBInsertRealTimeInfo(strSql);

                            #endregion

                            break;
                        default:
                            break;
                    }

                    break;
                case TerminalType.Manager:

                    break;
                case TerminalType.TaxiTerminal:

                    break;
                default:

                    break;
            }
        }
        /// <summary>
        /// 数据库写入实时信息
        /// </summary>
        /// <param name="strSql">查询语句</param>
        private void DBInsertRealTimeInfo(string strSql)
        {
            ExcuteDBOPeration(strSql);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="theBusID"></param>
        /// <param name="OKOrAlarm"></param>
        private void DBUpdateALarm(string theBusID, string OKOrAlarm)
        {
            string ISAlarm = "1";
            switch (OKOrAlarm.ToUpper())
            {
                case "OK":
                    ISAlarm = "0";
                    break;
                case "ALARM":
                    ISAlarm = "1";
                    break;
                default:
                    break;
            }
            string SqlStr = "UPDATE Bus SET IsAlarm = " + ISAlarm + " where Bus_id = N'" + theBusID + "'";
            ExcuteDBOPeration(SqlStr);
        }

        private void DBUpdateOnOfOffLine(string TheBusID, string OnOrOff)
        {
            string ISOnline = "1";
            switch (OnOrOff.ToUpper())
            {
                case "ON":
                    ISOnline = "1";
                    break;
                case "OFF":
                    ISOnline = "0";
                    break;
                default:
                    break;
            }
            string strSql = "UPDATE Bus SET IsOnline = " + ISOnline + " WHERE Bus_id = N'" + TheBusID + "'";
            ExcuteDBOPeration(strSql);
        }
        /// <summary>
        /// 完成数据库操作
        /// </summary>
        /// <param name="strSql">查询语句</param>
        private static void ExcuteDBOPeration(string strSql)
        {
            try
            {
                int result = DBHelper.ExecuteSQL(strSql);
                if (result == -1)
                {
                    #region Log



                    #endregion
                }
                else if (result == 1)
                {
                    #region Log



                    #endregion
                }

            }
            catch (Exception ex)//log
            {
                #region Log



                #endregion
            }
        }


        private void ShowOnListBox(string p)
        {
            serverFrm.RTlist.BeginInvoke(new RTListAction(() =>
            {
                serverFrm.RTlist.Items.Add(DateTime.Now.ToString() + "_" + p);

            }));
        }

        private void ShowOnListBox(AppSession session, AppSessionActionType ShowType)
        {
            switch (ShowType)
            {
                case AppSessionActionType.ManangeConnect:
                    ShowOnListBox(session.RemoteEndPoint.ToString());
                    break;
                case AppSessionActionType.ManageDisconnect:
                    break;
                case AppSessionActionType.TerminalConnect:
                    break;
                case AppSessionActionType.TerminalDisconnect:
                    break;
                default:
                    break;
            }
        }
        private void AddLog(string msg)
        {
            Console.WriteLine(msg);
        }
        private void ServerStopButton_Click(object sender, EventArgs e)
        {
            
            fs.Close();
        }
    }
    enum AppSessionActionType
    {
        ManangeConnect = 1,
        ManageDisconnect = 2,
        TerminalConnect = 20,
        TerminalDisconnect = 22,
    }
    public delegate void RTListAction();

}