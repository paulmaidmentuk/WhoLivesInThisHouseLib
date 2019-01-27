using System;
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

        public GameServer()
        {
            String url = "http://localhost:9595/";
            server = new WebServer(url, RoutingStrategy.Regex);
            server.RegisterModule(new WebApiModule());
            server.Module<WebApiModule>().RegisterController<CharacterListController>();
            server.Module<WebApiModule>().RegisterController<ItemListController>();
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
    }
}
