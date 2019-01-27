using System;
using System.Collections.Generic;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;

namespace WhoLivesInThisHouse
{
    public class TagListController : WebApiController
    {
        private GameContext gameContext;

        public TagListController(IHttpContext context) : base(context)
        {
            gameContext = GameContext.Instance;
        }

        [WebApiHandler(HttpVerbs.Get, "/api/tags")]
        public bool GetTags()
        {
            try
            {
                TagListSerializer tagListSerializer = new TagListSerializer();
                return this.JsonResponse(tagListSerializer.Serialize(gameContext.AllTags));
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
