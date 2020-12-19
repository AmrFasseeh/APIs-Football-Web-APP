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
    public class teamsController : ApiController
    {
        private APIModel db = new APIModel();

        // GET: api/teams
        public IQueryable<team> Getteams()
        {
            return db.teams;
        }

        // GET: api/teams/5
        [ResponseType(typeof(team))]
        public IHttpActionResult Getteam(int id)
        {
            team team = db.teams.Find(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        [Route("api/LeagueTeams/{id}")]
        [ResponseType(typeof(team))]
        public IHttpActionResult GetteamsPerLeague(int id)
        {
            var team = db.teams.Where(n =>n.league_id == id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }
    }
}