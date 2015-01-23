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
            #region ���������������ʼ��

            appServer = new CTTCServer();

            #region server ���Ժ�����
            //maxWorkingThreads: �̳߳�������߳�����;
            //minWorkingThreads: �̳߳���С�����߳�����;
            //maxCompletionPortThreads: �̳߳������ɶ˿��߳�����;
            //minCompletionPortThreads: �̳߳���С��ɶ˿��߳�����;
            //disablePerformanceDataCollector: �Ƿ�����������ݲɼ�;
            //performanceDataCollectInterval: �������ݲɼ�Ƶ�� (��λΪ��, Ĭ��ֵ: 60);
            //isolation: SuperSocket ������ʵ�����뼶��
            //None - �޸���
            //AppDomain - Ӧ�ó����򼶱�ĸ��룬���������ʵ�������ڸ��Զ�����Ӧ�ó�����֮��
            //Process - ���̼���ĸ��룬���������ʵ�������ڸ��Զ����Ľ���֮��
            //logFactory: Ĭ��logFactory������, ���п��õ� log factories�������ӽڵ� "logFactories" ֮�У� ���ǽ�����������ĵ��н�����;
            //defaultCulture: ���������Ĭ�� thread culture��ֻ��.Net 4.5�п���;

            //Server ��������������:

            //name: ������ʵ��������;
            //serverType: ������ʵ�������͵���������;
            //serverTypeName: ��ѡ�õķ����������� serverTypes �ڵ�����֣����ýڵ� serverTypes ���ڶ������п��õķ��������ͣ����ǽ��ں���������ϸ����;
            //ip: ������������ip��ַ����������þ���ĵ�ַ��Ҳ��������Ϊ�����ֵ Any - ���е�IPv4��ַ IPv6Any - ���е�IPv6��ַ
            //port: �����������Ķ˿�;
            //listenBacklog: �������еĴ�С;
            //mode: Socket���������е�ģʽ, Tcp (Ĭ��) ���� Udp;
            //disabled: ������ʵ���Ƿ������;
            //startupOrder: ������ʵ������˳��, bootstrap �����մ�ֵ��˳�����������������ʵ��;
            //sendTimeOut: �������ݳ�ʱʱ��;
            //sendingQueueSize: ���Ͷ�����󳤶�;
            //maxConnectionNumber: ���������ӵ����������;
            //receiveBufferSize: ���ջ�������С;
            //sendBufferSize: ���ͻ�������С;
            //syncSend: �Ƿ�����ͬ������ģʽ, Ĭ��ֵ: false;
            //logCommand: �Ƿ��¼����ִ�еļ�¼;
            //logBasicSessionActivity: �Ƿ��¼session�Ļ���������������ӺͶϿ�;
            //clearIdleSession: true �� false, �Ƿ�ʱ��տ��лỰ��Ĭ��ֵ�� false;
            //clearIdleSessionInterval: ��տ��лỰ��ʱ����, Ĭ��ֵ��120, ��λΪ��;
            //idleSessionTimeOut: �Ự��ʱʱ�䣬Ĭ��ֵΪ300����λΪ��;
            //security: Empty, Tls, Ssl3. Socket�����������õĴ�������Э�飬Ĭ��ֵΪ��;
            //maxRequestLength: �����������󳤶ȣ�Ĭ��ֵΪ1024;
            //textEncoding: �ı���Ĭ�ϱ��룬Ĭ��ֵ�� ASCII;
            //defaultCulture: �˷�����ʵ����Ĭ�� thread culture, ֻ��.Net 4.5�п��ö����ڸ��뼶��Ϊ 'None' ʱ��Ч;
            //disableSessionSnapshot: �Ƿ���ûỰ����, Ĭ��ֵΪ false.
            //sessionSnapshotInterval: �Ự����ʱ����, Ĭ��ֵ�� 5, ��λΪ��;
            //keepAliveTime: ����������������µ�keep alive���ݵķ��ͼ��, Ĭ��ֵΪ 600, ��λΪ��;
            //keepAliveInterval: Keep aliveʧ��֮��, keep alive̽����ķ��ͼ����Ĭ��ֵΪ 60, ��λΪ��;
            //certificate: ����ڵ����ڶ������ڴ˷�����ʵ����X509Certificate֤�����Ϣ
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
                ShowOnListBox("����������ʧ��");
                return;
            }
            if (!appServer.Start())
            {
                ShowOnListBox("����������ʧ��");
                return;
            }
            #region ע���¼�

            appServer.NewSessionConnected += new SessionHandler<TerminalSession>(appServer_NewSessionConnected);
            appServer.NewRequestReceived += new RequestHandler<TerminalSession, TerminalRequestInfo>(appServer_NewRequestReceived);
            appServer.SessionClosed += new SessionHandler<TerminalSession, SuperSocket.SocketBase.CloseReason>(appServer_SessionClosed);

            #endregion

            #endregion

            ShowOnListBox("������������");
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
            ShowOnListBox("������ֹͣ");
        }
        private void appServer_SessionClosed(TerminalSession session, SuperSocket.SocketBase.CloseReason theReason)
        {
            string TheBusID = ProvinceID + session.TerminalSessionID.Split('|')[0];
            string log = session.TerminalSessionID + "terminal offline" + " connect time��" + session.StartTime.ToString();
            DBUpdateOnOfOffLine(TheBusID, "OFF");

            ShowOnListBox(session.TerminalSessionID.Split('|')[0] + " " + session.LastActiveTime.ToString() + " ����");
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
                    //�ỰID����A12345|2013/02/04 08:01:01
                    session.TerminalSessionID = ProvinceID + RequestInfo.BusID + "|" + RequestInfo.InfoTime.ToString();

                    switch (RequestInfo.InfoType)
                    {
                        case InfoType.Online:
                            DBUpdateOnOfOffLine(ProvinceID + RequestInfo.BusID, "ON");
                            ShowOnListBox(ProvinceID + RequestInfo.BusID + " " + RequestInfo.InfoTime.ToString() + " ����");
                            break;
                        case InfoType.Offline:
                            DBUpdateOnOfOffLine(ProvinceID + RequestInfo.BusID, "OFF");
                            ShowOnListBox(ProvinceID + RequestInfo.BusID + " " + RequestInfo.InfoTime.ToString() + " ����");
                            break;
                        case InfoType.AlarmInfo:
                            DBUpdateALarm(ProvinceID + RequestInfo.BusID, "ALARM");
                            ShowOnListBox(ProvinceID + RequestInfo.BusID + " " + RequestInfo.InfoTime.ToString() + " ����");
                            break;
                        case InfoType.RealTimeInfo:
                            #region ע��
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
        /// ���ݿ�д��ʵʱ��Ϣ
        /// </summary>
        /// <param name="strSql">��ѯ���</param>
        private void DBInsertRealTimeInfo(string strSql)
        {
            ExcuteDBOPeration(strSql);
        }
        /// <summary>
        /// ����
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
        /// ������ݿ����
        /// </summary>
        /// <param name="strSql">��ѯ���</param>
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