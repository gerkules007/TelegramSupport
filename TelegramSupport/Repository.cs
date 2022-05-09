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
        Dictionary<string, List<ModelMessage>> db = new();

        public void Append(ModelMessage model)
        {
            var id = model.IdMessage;
            if (db.ContainsKey(id))
            {
                db[id].Add(model);
            }
            else
            {
                db.Add(id, new List<ModelMessage>(new ModelMessage[] { model }));
            }
        }

        public Dictionary<string, List<ModelMessage>> Read()
        {
            return db;
        }

        public string GetString()
        {
            string data = String.Empty;


            foreach (var item in db)
            {
                data += $"{item.Key} [{String.Join(", ", item.Value)}]\n";
            }
            return $"{data}\n\n";

        }

        public void Save()
        {
            File.WriteAllText($"SaveMessage{DateTime.Now.ToShortDateString}.json", JsonConvert.SerializeObject(db));
        }

        public void Load(string fileName)
        {
            string file = File.ReadAllText ($"{  Directory.GetCurrentDirectory()  }\\{  fileName  }");

            if (file != null)
            {
                db = (Dictionary<string, List<ModelMessage>>)   JsonConvert.DeserializeObject( file )!;
            }
        }
    }
}
