using NUnit.Framework;
using System;
using WhoLivesInThisHouse;

namespace WhoLivesInThisHouseTest
{
    [TestFixture()]
    public class GameServerTest
    {
        [Test()]
        public void it_should_detemine_the_local_hostname()
        {
            GameServer gameServer = new GameServer();
            Console.WriteLine(gameServer.GetLocalIP());
        }
    }
}
