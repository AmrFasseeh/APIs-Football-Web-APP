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
    public class matchesController : ApiController
    {
        private APIModel db = new APIModel();

        // GET: api/matches
        public IQueryable<match> Getmatches()
        {
            return db.matches;
        }

        // GET: api/matches/5
        [ResponseType(typeof(match))]
        public IHttpActionResult Getmatch(int id)
        {
            match match = db.matches.Find(id);
            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }
    }
}