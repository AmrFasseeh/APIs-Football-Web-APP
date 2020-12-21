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
            var allteams = db.teams.ToList();

            foreach (var item in allteams)
            {
                if (item.TeamMatches.Count != 0)
                {
                    var matches = item.TeamMatches.Where(a => a.team_id == item.team_id);
                    item.points = 0;
                    item.wins = 0;
                    item.loss = 0;
                    item.draws = 0;
                    foreach (var m in matches)
                    {
                        if (m.home_Away == "home" && m.match.status == "Finished")
                        {
                            if (m.match.team1_score > m.match.team2_score)
                            {
                                item.points += 3;
                                item.wins++;
                            }
                            else if (m.match.team1_score < m.match.team2_score)
                            {
                                item.loss++;
                            }
                            else if (m.match.team1_score == m.match.team2_score)
                            {
                                item.points++;
                                item.draws++;
                            }
                        }
                        else if (m.home_Away == "away" && m.match.status == "Finished")
                        {
                            if (m.match.team1_score < m.match.team2_score)
                            {
                                item.points += 3;
                                item.wins++;
                            }
                            else if (m.match.team1_score > m.match.team2_score)
                            {
                                item.loss++;
                            }
                            else if (m.match.team1_score == m.match.team2_score)
                            {
                                item.points++;
                                item.draws++;
                            }
                        }
                    }
                }
            }
            return db.teams;
        }

        // GET: api/teams/5
        [ResponseType(typeof(team))]
        public IHttpActionResult Getteam(int id)
        {
            team team = db.teams.Find(id);
            var allteams = db.teams.ToList();

            foreach (var item in allteams)
            {
                if (item.TeamMatches.Count != 0)
                {
                    var matches = item.TeamMatches.Where(a => a.team_id == item.team_id);
                    item.points = 0;
                    item.wins = 0;
                    item.loss = 0;
                    item.draws = 0;
                    foreach (var m in matches)
                    {
                        if (m.home_Away == "home" && m.match.status == "Finished")
                        {
                            if (m.match.team1_score > m.match.team2_score)
                            {
                                item.points += 3;
                                item.wins++;
                            }
                            else if (m.match.team1_score < m.match.team2_score)
                            {
                                item.loss++;
                            }
                            else if (m.match.team1_score == m.match.team2_score)
                            {
                                item.points++;
                                item.draws++;
                            }
                        }
                        else if (m.home_Away == "away" && m.match.status == "Finished")
                        {
                            if (m.match.team1_score < m.match.team2_score)
                            {
                                item.points += 3;
                                item.wins++;
                            }
                            else if (m.match.team1_score > m.match.team2_score)
                            {
                                item.loss++;
                            }
                            else if (m.match.team1_score == m.match.team2_score)
                            {
                                item.points++;
                                item.draws++;
                            }
                        }
                    }
                }
            }
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
            var allteams = db.teams.ToList();

            foreach (var item in allteams)
            {
                if (item.TeamMatches.Count != 0)
                {
                    var matches = item.TeamMatches.Where(a => a.team_id == item.team_id);
                    item.points = 0;
                    item.wins = 0;
                    item.loss = 0;
                    item.draws = 0;
                    foreach (var m in matches)
                    {
                        if (m.home_Away == "home" && m.match.status == "Finished")
                        {
                            if (m.match.team1_score > m.match.team2_score)
                            {
                                item.points += 3;
                                item.wins++;
                            }
                            else if (m.match.team1_score < m.match.team2_score)
                            {
                                item.loss++;
                            }
                            else if (m.match.team1_score == m.match.team2_score)
                            {
                                item.points++;
                                item.draws++;
                            }
                        }
                        else if (m.home_Away == "away" && m.match.status == "Finished")
                        {
                            if (m.match.team1_score < m.match.team2_score)
                            {
                                item.points += 3;
                                item.wins++;
                            }
                            else if (m.match.team1_score > m.match.team2_score)
                            {
                                item.loss++;
                            }
                            else if (m.match.team1_score == m.match.team2_score)
                            {
                                item.points++;
                                item.draws++;
                            }
                        }
                    }
                }
            }
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }
    }
}