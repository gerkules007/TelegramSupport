using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramSupport
{
    class ModelMessage
    {
        public string IdMessage;
        public string UserID;
        public string UserName;
        public string MessageText;
        
        public string ToReadMessage()
        {
            return String.Format("{0,8} {1,15} {2}", IdMessage, UserName, MessageText);
        }
    }
}
