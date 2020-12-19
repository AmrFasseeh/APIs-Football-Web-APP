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
    public class yellow_cardsController : ApiController
    {
        private APIModel db = new APIModel();

        // GET: api/yellow_cards
        public IQueryable<yellow_cards> Getyellow_cards()
        {
            return db.yellow_cards;
        }

        // GET: api/yellow_cards/5
        [ResponseType(typeof(yellow_cards))]
        [Route("api/yellowPlayer/{id}")]
        public IHttpActionResult Getyellow_cardsPerplayer(int id)
        {
            int? yellow_cards = db.yellow_cards.Where(n => n.player_id == id).Count();
            if (yellow_cards == null)
            {
                return NotFound();
            }

            return Ok(yellow_cards);
        }

        // GET: api/yellow_cards/5
        [ResponseType(typeof(yellow_cards))]
        [Route("api/yellowMatch/{id}")]
        public IHttpActionResult Getyellow_cardsPerMatch(int id)
        {
            int? yellow_cards = db.yellow_cards.Where(n => n.match_id == id).Count();
            if (yellow_cards == null)
            {
                return NotFound();
            }

            return Ok(yellow_cards);
        }

        // GET: api/yellow_cards/5
        [ResponseType(typeof(yellow_cards))]
        [Route("api/yellowTeam/{id}")]
        public IHttpActionResult Getyellow_cardsPerTeam(int id)
        {
            int? yellow_cards = db.yellow_cards.Where(n => n.team_id == id).Count();
            if (yellow_cards == null)
            {
                return NotFound();
            }

            return Ok(yellow_cards);
        }
    }
}