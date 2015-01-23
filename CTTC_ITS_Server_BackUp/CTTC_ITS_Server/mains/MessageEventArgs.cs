using System;
using System.Data;
using CommonClassLibrary;

namespace CTTC_ITS_Server
{
    public class MessageEventArgs : EventArgs
    {
        private string msg;

        public string Message
        {
            get
            {
                return msg;
            }
            set
            {
                msg = value;
            }
        }
    }
}