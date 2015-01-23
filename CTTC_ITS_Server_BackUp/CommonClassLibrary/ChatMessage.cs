using System;

namespace CommonClassLibrary
{
    [Serializable()]
    public class ChatMessage : CommonProtocol
    {
        private string message;
        private string userName;

        public ChatMessage()
        {
        }

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
    }
}
