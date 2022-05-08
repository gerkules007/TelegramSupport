using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramSupport
{
    class TelegramNetwork
    {
        
        string TOKEN  = String.Empty;
        string url    = String.Empty;

        HttpClient hc = new(); // позволяет ходить в интернеты
       
        public string TextAnswer = String.Empty;
                                                                                                                                                 
        public TelegramNetwork(string _token)
        {
            this.TOKEN = _token;
            url = $"https://api.telegram.org/bot" + TOKEN + "/";
        }

        public void GetRequest()
        {
            TextAnswer = hc.GetStringAsync(url + "getUpdates").Result; //забрать результат запроса в виде строки
        }

        /*
        {"GetUpdates", "getUpdates"},
        {"GetMe", "getme"},
        { "SendMessage", "sendMessage?chat_id&text="},*/
    }
}
