using System;
using System.IO;
using System.Net;
using System.Linq;

namespace TelegramSupport
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = $"C:\\Users\\ovcse\\Desktop\\РАЗРАБОТЧИК\\ФАКУЛЬТАТИВЫ\\С# Telegram\\TelegramSupport\\TelegramSupport\\token.txt";
            string token = File.ReadAllText(path); //TODO Add Encoding

            Bot bot = new(token);

            bot.Start();
        }
    }
}



