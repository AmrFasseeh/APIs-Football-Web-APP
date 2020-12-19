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
    public class TeamMatchesController : ApiController
    {
        private APIModel db = new APIModel();

        // GET: api/TeamMatches
        public IQueryable<TeamMatch> GetTeamMatches()
        {
            return db.TeamMatches;
        }

        // GET: api/TeamMatches/5
        [ResponseType(typeof(TeamMatch))]
        public IHttpActionResult GetTeamMatch(int id)
        {
            var teamMatch = db.TeamMatches.Where(n => n.team_id == id);
            if (teamMatch == null)
            {
                return NotFound();
            }

            return Ok(teamMatch);
        }
    }
}