using System;
using System.Collections.Generic;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;

namespace WhoLivesInThisHouse
{
    public class CharacterListController : WebApiController
    {
        private GameContext gameContext;

        public CharacterListController(IHttpContext context) : base(context)
        {
            gameContext = GameContext.Instance;
        }

        [WebApiHandler(HttpVerbs.Get, "/api/characters")]
        public bool GetCharacters()
        {
            try
            {
                CharacterListSerializer characterListSerializer = new CharacterListSerializer();
                return this.JsonResponse(characterListSerializer.Serialize(gameContext.Characters));
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
