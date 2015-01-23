using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;


namespace CTTC_ITS_Server.mains
{

    public class TerminalSession : AppSession<TerminalSession, TerminalRequestInfo>
    {
        public new CTTCServer AppServer
        {
            get
            {
                return (CTTCServer)base.AppServer;
            }
        }
        private string terminalSessionID;
        public string TerminalSessionID
        {
            get
            {
                return terminalSessionID;
            }
            set 
            {
                terminalSessionID = value;
            }
        }
    }

}
