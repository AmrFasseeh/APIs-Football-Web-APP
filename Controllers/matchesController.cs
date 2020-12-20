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
        public List<FullMatch> Getmatches()
        {
            List<FullMatch> fmatches = new List<FullMatch>();
            foreach(var match in db.matches)
            {
                FullMatch fmatch = new FullMatch();
                fmatch.match_id = match.match_id;
                fmatch.team1_name = match.TeamMatches.First(m => m.match_id == match.match_id).team.name;
                fmatch.team2_name = match.TeamMatches.Last(m => m.match_id == match.match_id).team.name;
                fmatch.team1_score = match.team1_score;
                fmatch.team2_score = match.team2_score;
                fmatch.date = match.date;
                fmatch.status = match.status;
                fmatches.Add(fmatch);
            }
            return fmatches;
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