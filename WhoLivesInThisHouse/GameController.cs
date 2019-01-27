using System;
using System.Collections.Generic;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;

namespace WhoLivesInThisHouse
{
    public class GameController : WebApiController
    {
        private GameContext gameContext;

        public GameController(IHttpContext context) : base(context)
        {
            gameContext = GameContext.Instance;
        }

        [WebApiHandler(HttpVerbs.Get, "/api/game/new")]
        public bool NewGame()
        {
            try
            {
                gameContext.NewGame(6);
                return this.JsonResponse(true);
            }
            catch (Exception ex)
            {
                return this.JsonExceptionResponse(ex);
            }
        }

        // You can override the default headers and add custom headers to each API Response.
        public override void SetDefaultHeaders() => this.NoCache();
    }
}
