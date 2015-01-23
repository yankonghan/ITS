using System; 
using System.Net.Sockets; 
using System.Text; 
using System.Collections; 
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using CommonClassLibrary;

namespace PlayCardServer
{
    public class Client
    {
        public event EventHandler Connected;
        public event EventHandler Disconnected;
        public event EventHandler<MessageEventArgs> MessageReceived;

        private TcpClient myClient;

        private byte[] recByte;
        private SplitBytes sb;

        private string userID;
        private string userName;
        private bool isLogin;
        private string ip;

        public Client(TcpClient myClient)
        {
            this.myClient = myClient;
            sb = new SplitBytes();
            recByte = new byte[1024];
            isLogin = false;
        }

        public string UserID
        {
            get
            {
                return userID;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }
        }

        public string IP
        {
            get
            {
                return ip;
            }
        }



        private void myReadCallBack(IAsyncResult ar)
        {
            int numberOfBytesRead;

            try
            {
                lock (myClient.GetStream())
                {
                    numberOfBytesRead = myClient.GetStream().EndRead(ar);

                    if (numberOfBytesRead < 1)
                    {
                        //If a value less than 1 received that means that client disconnected 
                        myClient.Close();
                        //raise the Disconnected Event 
                        if (Disconnected != null)
                        {
                            EventArgs e = new EventArgs();
                            Disconnected(this, e);
                        }
                        return;
                    }
                }

                sb.AddBytes(recByte, numberOfBytesRead);
                recByte = new byte[1024];

                if (myClient.GetStream().DataAvailable)
                {
                    myClient.GetStream().BeginRead(recByte, 0, recByte.Length, new AsyncCallback(myReadCallBack), myClient.GetStream());
                }
                else
                {
                    BuildText(sb.ReceiveAllByte);
                    sb.Dispose();

                    if (isLogin)
                    {
                        lock (myClient.GetStream())
                        {
                            AsyncCallback GetStreamMsgCallback = new AsyncCallback(myReadCallBack);
                            myClient.GetStream().BeginRead(recByte, 0, 1024, GetStreamMsgCallback, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                myClient.Close();
                if (Disconnected != null)
                {
                    EventArgs e = new EventArgs();
                    Disconnected(this, e);
                }
            }
        }

        public void Connect()
        {
            AsyncCallback GetStreamMsgCallback = new AsyncCallback(myReadCallBack);
            myClient.GetStream().BeginRead(recByte, 0, 1024, GetStreamMsgCallback, null);
        }

        public void Disconnect()
        {
            myClient.Close();
        }

        public void CheckUserName(string UserID, string Password, string IP)
        {
            LoginUser u = new LoginUser();
            u.Protocol = "502";

            SqlDataReader dr = DB.LoginDB(UserID, Password);
            if (dr.Read())
            {
                isLogin = true;
                DB.UpdateStatus(UserID, "1");

                this.userID = UserID;
                this.userName = dr["UserName"].ToString().Trim();
                this.ip = dr["Port"].ToString().Trim();
                int ImageIndex = (int)dr["ImageIndex"];

                ClientList.Instance().AddClient(UserID, UserName, ImageIndex);

                //Send the UserName
                u.UserName = userName;
                u.IsLogin = true;
                u.IP = this.ip;

                byte[] message = SerializationFormatter.GetSerializationBytes(u);
                Send(message);

                //Raise the Connected Event 
                if (Connected != null)
                {
                    EventArgs e = new EventArgs();
                    Connected(this, e);
                }
            }
            else
            {
                u.IsLogin = false;
                byte[] message = SerializationFormatter.GetSerializationBytes(u);
                Send(message);

                Disconnect();
                dr.Close();
                return;
            }
            dr.Close();
        }

        public void BuildText(byte[] dataByte)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(dataByte);
            CommonProtocol obj = (CommonProtocol)formatter.Deserialize(stream);
            stream.Close();

            string Protocol = obj.Protocol;

            switch (Protocol)
            {
                case "501":
                    LoginUser u = (LoginUser)obj;
                    CheckUserName(u.UserID, u.Password, u.IP);

                    break;

                case "503":
                    if (MessageReceived != null)
                    {
                        ChatMessage meg = (ChatMessage)obj;
                        MessageEventArgs e = new MessageEventArgs();
                        e.Message = meg.Message;
                        MessageReceived(this, e);
                    } 
                    
                    break;
            }
        }

        public void Send(byte[] byteMessage)
        {
            lock (myClient.GetStream())
            {
                BinaryWriter writer = new BinaryWriter(myClient.GetStream()); ;
                writer.Write(byteMessage);
                writer.Flush();
            }
        }
    }
}