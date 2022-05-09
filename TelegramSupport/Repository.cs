using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TelegramSupport
{
    class Repository
    {
        Dictionary<string, List<ModelMessage>> dataBase = new();

        public void Append(List<ModelMessage> lmm)
        {
            foreach (ModelMessage model in lmm)
            {
                var id = model.UserID;
                if (dataBase.ContainsKey(id))
                {
                    dataBase[id].Add(model);
                }
                else
                {
                    dataBase.Add(id, new List<ModelMessage>( new ModelMessage[] { model } ));
                }
            }
        }

        public Dictionary<string, List<ModelMessage>> Read()
        {
            return dataBase;
        }

        public string GetString()
        {
            string data = String.Empty;

            foreach (var item in dataBase)
            {
                data += $"{item.Key} [{  String.Join(", ", item.Value.Select(e => e.ToString()))  }] \n";

            }
            return $"{data}\n\n";

        }

        public void Save(string info = "")
        {
            File.WriteAllText($"SaveMessages{info}.json", JsonConvert.SerializeObject(dataBase));
        }

        public void Load(string info = "")
        {
            string file = $"SaveMessages{info}.json";

            if (File.Exists(file))
            {
                dataBase = JsonConvert.DeserializeObject<Dictionary<string, List<ModelMessage>>>(  File.ReadAllText(file)  )!;
            }
        }

        // DateTime.Now.ToShortDateString
    }
}
