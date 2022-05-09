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

        public             string Answer   = String.Empty;
        public             string SendMsg  = String.Empty;
        public            JObject JSON     = new();
        public List<ModelMessage> messages = new(); // TODO Check security for all
                       Repository rep      = new();


        public Bot(string _token)
        {
            this.TOKEN = _token;
            url = $"https://api.telegram.org/bot{TOKEN}/";
        }
        public void Start() // TODO создать отдельную сущность в виде контроллера
        {
            // TODO Добавить потоки
            rep.Load();
            Console.WriteLine("Enter to Start");

            while (!Console.ReadKey().Key.Equals(ConsoleKey.S)) // TODO Поменять логику клавиш или Do While цикл
            {
                GetRequest();
                CreateModelMessage();

                /*foreach (var message in messages) {
                    Console.WriteLine(message.ToReadMessage()); }*/
                
                rep.Append(messages);

                Console.WriteLine(rep.GetString());

                Thread.Sleep(2000);
            }
            rep.Save();
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

                mm.UpdateID    = item["update_id"]!.ToString();
                mm.UserID      = item["message"]!["from"]!["id"]!.ToString();
                mm.UserName    = item["message"]!["from"]!["first_name"]!.ToString()
                                                      + " " +
                                 item["message"]!["from"]!["last_name"]!.ToString();
                mm.MessageText = item["message"]!["text"]!.ToString();

                messages.Add(mm);
            }
        }

        public void SendMessage(ModelMessage mm, string text)
        {
            SendMsg = $"{url}sendmessage?chat_id={mm.UserID}&text={text}";
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
