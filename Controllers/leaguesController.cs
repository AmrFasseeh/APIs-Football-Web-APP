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
    public class leaguesController : ApiController
    {
        private APIModel db = new APIModel();

        // GET: api/leagues
        public IQueryable<league> Getleagues()
        {
            return db.leagues;
        }

        // GET: api/leagues/5
        [ResponseType(typeof(league))]
        public IHttpActionResult Getleague(int id)
        {
            league league = db.leagues.Find(id);
            if (league == null)
            {
                return NotFound();
            }

            return Ok(league);
        }
    }
}