using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace CTTC_ITS_Server.mains
{
    public class CTTCServer : AppServer<TerminalSession, TerminalRequestInfo>
    {
        public CTTCServer()
            : base(new DefaultReceiveFilterFactory<CTTCFilter, TerminalRequestInfo>())
        {
            DefaultResponse = new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff };
        }
        internal byte[] DefaultResponse { get; private set; }
    }
}
