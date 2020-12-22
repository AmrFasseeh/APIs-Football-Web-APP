using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIs_FinalProject.Models;

namespace APIs_FinalProject.Controllers
{
    public class red_cardsController : ApiController
    {
        private APIModel db = new APIModel();

        // GET: api/red_cards
        public IQueryable<red_cards> Getred_cards()
        {
            return db.red_cards;
        }


        // GET: api/red_cards/5
        [ResponseType(typeof(RedCardsViewModel))]
        [Route("api/redPlayer/{id}")]
        public IHttpActionResult Getred_cardsPerplayer(int id)
        {
            int? red_cards = db.red_cards.Where(n => n.player_id == id).Count();
            RedCardsViewModel cards = new RedCardsViewModel();
            if (red_cards == null)
            {
                return NotFound();
            }
            if (red_cards != null)
            {
                cards.count = red_cards;
            }

            return Ok(cards);
        }

        // GET: api/red_cards/5
        [ResponseType(typeof(RedCardsViewModel))]
        [Route("api/redMatch/{id}")]
        public IHttpActionResult Getred_cardsPerMatch(int id)
        {
            int? red_cards = db.red_cards.Where(n => n.match_id == id).Count();
            RedCardsViewModel cards = new RedCardsViewModel();
            if (red_cards == null)
            {
                return NotFound();
            }
            if (red_cards != null)
            {
                cards.count = red_cards;
            }

            return Ok(cards);
        }

        // GET: api/red_cards/5
        [ResponseType(typeof(RedCardsViewModel))]
        [Route("api/redTeam/{id}")]
        public IHttpActionResult Getred_cardsPerTeam(int id)
        {
            int? red_cards = db.red_cards.Where(n => n.team_id == id).Count();
            RedCardsViewModel cards = new RedCardsViewModel();
            if (red_cards == null)
            {
                return NotFound();
            }
            if (red_cards != null)
            {
                cards.count = red_cards;
            }

            return Ok(cards);
        }
    }
}