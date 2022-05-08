using System;
using System.IO;
using System.Net;
using System.Linq;

namespace TelegramSupport
{
    class Programm
    {
        static void Main(string[] args)
        {
            string path = $"C:\\Users\\ovcse\\Desktop\\РАЗРАБОТЧИК\\ФАКУЛЬТАТИВЫ\\С# Telegram\\TelegramSupport\\TelegramSupport\\token.txt";
            string TOKEN = File.ReadAllText(path);

            TelegramNetwork tn = new(TOKEN);

            tn.GetRequest();
            Console.WriteLine(tn.TextAnswer);
        }
    }
}



