using System;
using System.Collections.Generic;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;

namespace WhoLivesInThisHouse
{
    public class ItemListController : WebApiController
    {
        private GameContext gameContext;

        public ItemListController(IHttpContext context) : base(context)
        {
            gameContext = GameContext.Instance;
        }

        [WebApiHandler(HttpVerbs.Get, "/api/items")]
        public bool GetCharacters()
        {
            try
            {
                ItemListSerializer itemListSerializer = new ItemListSerializer();
                return this.JsonResponse(itemListSerializer.Serialize(gameContext.AllItems));
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
