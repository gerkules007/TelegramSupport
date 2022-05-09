using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramSupport
{
    class ModelMessage
    {
        public string UpdateID    = String.Empty;
        public string UserID      = String.Empty;
        public string UserName    = String.Empty;
        public string MessageText = String.Empty;
        
        public override string ToString()
        {
            return $"{UpdateID}, {UserName}, {MessageText}"; 
        }
    }
}
