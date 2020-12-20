using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIs_FinalProject.Models
{
    public class FullMatch
    {
        public int match_id { get; set; }
        public int league_id { get; set; }

        public string team1_name { get; set; }

        public string team2_name { get; set; }

        public int team1_score { get; set; }

        public int team2_score { get; set; }

        public string date { get; set; }

        public string status { get; set; }
    }
}