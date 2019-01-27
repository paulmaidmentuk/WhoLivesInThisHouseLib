using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;

namespace WhoLivesInThisHouse
{
    public class GameServer
    {
        private WebServer server;
        private Task webServerTask;
        private CancellationTokenSource cancellationTokenSource;
        private String url;

        public GameServer()
        {
            url = "http://" + GetLocalIP() + ":9595/";
            server = new WebServer(url, RoutingStrategy.Regex);
            server.RegisterModule(new WebApiModule());
            server.Module<WebApiModule>().RegisterController<CharacterListController>();
            server.Module<WebApiModule>().RegisterController<ItemListController>();
            server.Module<WebApiModule>().RegisterController<TagListController>();
            server.Module<WebApiModule>().RegisterController<RoomController>();
            server.Module<WebApiModule>().RegisterController<GameController>();
        }

        public void StartServer()
        {
            cancellationTokenSource = new CancellationTokenSource();
            webServerTask = server.RunAsync(cancellationTokenSource.Token);
        }

        public bool StopServer()
        {
            cancellationTokenSource.Cancel();
            webServerTask.Wait();
            webServerTask.Dispose();
            server.Dispose();
            return true;
        }

        public String Url
        {
            get
            {
                return this.url;
            }

        }

        public string GetLocalIP()
        {
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress addr in localIPs)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    return addr.ToString();
                }
            }
            return "";
        }
    }
}
