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
        public IHttpActionResult Getyellow_cards(int id)
        {
            yellow_cards yellow_cards = db.yellow_cards.Find(id);
            if (yellow_cards == null)
            {
                return NotFound();
            }

            return Ok(yellow_cards);
        }

        // PUT: api/yellow_cards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putyellow_cards(int id, yellow_cards yellow_cards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != yellow_cards.yellow_card_id)
            {
                return BadRequest();
            }

            db.Entry(yellow_cards).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!yellow_cardsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/yellow_cards
        [ResponseType(typeof(yellow_cards))]
        public IHttpActionResult Postyellow_cards(yellow_cards yellow_cards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.yellow_cards.Add(yellow_cards);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = yellow_cards.yellow_card_id }, yellow_cards);
        }

        // DELETE: api/yellow_cards/5
        [ResponseType(typeof(yellow_cards))]
        public IHttpActionResult Deleteyellow_cards(int id)
        {
            yellow_cards yellow_cards = db.yellow_cards.Find(id);
            if (yellow_cards == null)
            {
                return NotFound();
            }

            db.yellow_cards.Remove(yellow_cards);
            db.SaveChanges();

            return Ok(yellow_cards);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool yellow_cardsExists(int id)
        {
            return db.yellow_cards.Count(e => e.yellow_card_id == id) > 0;
        }
    }
}