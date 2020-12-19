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
    public class playersController : ApiController
    {
        private APIModel db = new APIModel();

        // GET: api/players
        public IQueryable<player> Getplayers()
        {
            return db.players;
        }

        // GET: api/players/5
        [ResponseType(typeof(player))]
        public IHttpActionResult Getplayer(int id)
        {
            player player = db.players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }
    }
}