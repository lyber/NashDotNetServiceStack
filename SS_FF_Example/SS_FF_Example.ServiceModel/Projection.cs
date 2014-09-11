using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_FF_Example.ServiceModel
{
    public class Projection
    {
        [AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Team { get; set; }
        public string Position { get; set; }
        public string Opponent { get; set; }
        public string GameTime { get; set; }
        public string Completions { get; set; }
        public string Attempts { get; set; }
        public string Yards { get; set; }
        public string PassingTouchdowns { get; set; }
        public string Interceptions { get; set; }
        public string RushAttempts { get; set; }
        public string RushingYards { get; set; }
        public string Touchdowns { get; set; }
        public string Receptions { get; set; }
        public string ReceivingYards { get; set; }
        public string ReceivingTouchdowns { get; set; }
        public string Points { get; set; }

    }
}
