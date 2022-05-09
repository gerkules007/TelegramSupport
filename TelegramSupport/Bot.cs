using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TelegramSupport
{
    class Bot
    {
        private     string TOKEN  = String.Empty;
        private     string url    = String.Empty;
        private HttpClient hc     = new(); // позволяет ходить в интернеты

        public             string Answer    = String.Empty;
        public            JObject JSON      = new();
        public List<ModelMessage> messages  = new();


        public Bot(string _token)
        {
            this.TOKEN = _token;
            url = $"https://api.telegram.org/bot{TOKEN}/";
        }
        public void Start()
        {
            while (true)
            {
                GetRequest();
                CreateModelMessage();

                foreach (var message in messages) {
                    Console.WriteLine(message.ToReadMessage()); }

                Thread.Sleep(2000);
            }
        }

        void GetRequest() //TODO Change name
        {
            Answer = hc.GetStringAsync(url + "getUpdates").Result; //забрать результат запроса в виде строки
            JSON = JObject.Parse(Answer);
        }

        void CreateModelMessage()
        {
            JToken jresult = JSON["result"]!;

            foreach (JToken item in jresult)
            {
                ModelMessage mm = new();

                mm.IdMessage   = item["update_id"]!.ToString();
                mm.UserID      = item["message"]!["from"]!["id"]!.ToString();
                mm.UserName    = item["message"]!["from"]!["first_name"]!.ToString()
                                 + " " +
                                 item["message"]!["from"]!["last_name"]!.ToString();
                mm.MessageText = item["message"]!["text"]!.ToString();

                messages.Add(mm);
            }
        }

        void GetReceivedProperties(string property = "ok") =>
            throw new Exception(); // Queue<JToken> search_element = new(); TODO Algoritm Graph

        /*
        {"GetUpdates", "getUpdates"},
        {"GetMe", "getme"},
        { "SendMessage", "sendMessage?chat_id&text="},*/

        // DataTable newdt = (DataTable)JsonConvert.DeserializeObject(fd, typeof(DataTable));
    }
}
