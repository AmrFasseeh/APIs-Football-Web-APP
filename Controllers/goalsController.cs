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
    public class goalsController : ApiController
    {
        private APIModel db = new APIModel();

        // GET: api/goals
        public IQueryable<goal> Getgoals()
        {
            return db.goals;
        }

        // GET: api/goals/5
        [ResponseType(typeof(goal))]
        public IHttpActionResult GetgoalPerPlayer(int id)
        {
            int? goal = db.goals.Where(n => n.player_id == id).Count();
            if (goal == null)
            {
                return NotFound();
            }

            return Ok(goal);
        }
    }
}