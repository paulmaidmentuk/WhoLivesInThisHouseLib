using System;
using System.Collections.Generic;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;

namespace WhoLivesInThisHouse
{
    public class RoomController : WebApiController
    {
        private GameContext gameContext;

        public RoomController(IHttpContext context) : base(context)
        {
            gameContext = GameContext.Instance;
        }

        [WebApiHandler(HttpVerbs.Get, "/api/room")]
        public bool GetRoom()
        {
            try
            {
                RoomSerializer roomSerializer = new RoomSerializer();
                return this.JsonResponse(roomSerializer.Serialize(gameContext.CurrentRoom));
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
