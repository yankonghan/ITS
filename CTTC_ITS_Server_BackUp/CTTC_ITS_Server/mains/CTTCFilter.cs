using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.Facility.Protocol;
using SuperSocket.Common;
using NUnit.Framework;

namespace CTTC_ITS_Server.mains
{
    
    /// <summary>
    /// It is the kind of protocol that
    /// the first two bytes of each command are { 0x68, 0x68 }
    /// and the last two bytes of each command are { 0x0d, 0x0a }
    /// and the 16th byte (data[15]) of each command indicate the command type
    /// if data[15] = 0x10, the command is a keep alive one
    /// if data[15] = 0x1a, the command is position one
    /// </summary>
    class CTTCFilter : BeginEndMarkReceiveFilter<TerminalRequestInfo>
    {
        private readonly static byte[] BeginMark = new byte[] { 0xff };
        private readonly static byte[] EndMark = new byte[] { 0xfe };

        public CTTCFilter()
            : base(BeginMark, EndMark)
        {

        }
        public override TerminalRequestInfo Filter(byte[] readBuffer, int offset, int length, bool toBeCopied, out int rest)
        {
            return base.Filter(readBuffer, offset, length, toBeCopied, out rest);
        }
        protected override TerminalRequestInfo ProcessMatchedRequest(byte[] readBuffer, int offset, int length)
        {

            return new TerminalRequestInfo(BitConverter.ToString(readBuffer, offset + 6, 1), readBuffer.CloneRange(offset, length));
        }
    }
}
