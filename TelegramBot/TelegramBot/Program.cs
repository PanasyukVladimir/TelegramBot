using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;

namespace TelegramBot
{
    class Program
    {
        static void CheckNumber(int number, ref bool statusNum)
        {
            string url = $"https://localhost:44302/api/numbers/{number}";
            var json = new WebClient() { Encoding = Encoding.UTF8 }.DownloadString(url);

            statusNum = json.Equals("true") ? true : false;

        }
        static void Main(string[] args)
        {
            bool statusNumber = true;

            TelegramBotClient bot = new TelegramBotClient("1331063915:AAEnGb1XocJod9d6digo_q7hlnkAxpKp8R4");
            bot.OnMessage += (s, arg) =>
            {
                try
                {
                    Console.WriteLine($"{arg.Message.Chat.FirstName}: {arg.Message.Text}");
                    CheckNumber(Int32.Parse(arg.Message.Text), ref statusNumber);
                    bot.SendTextMessageAsync(arg.Message.Chat.Id, $"Статус вашего числа: {statusNumber}");
                }
                catch
                {
                    bot.SendTextMessageAsync(arg.Message.Chat.Id, $"{arg.Message.Chat.FirstName}, TU DYRAK");
                }       
            };
            
            bot.StartReceiving();
            Console.ReadKey();
        }
    }
}
