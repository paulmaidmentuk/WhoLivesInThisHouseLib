using System;
using WhoLivesInThisHouse;

namespace WhoLivesHereServerApp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            GameServer gameServer = new GameServer();
            gameServer.StartServer();
            Console.WriteLine("Waiting for keypress");
            Console.ReadLine();
        }
    }
}
