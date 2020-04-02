    using System;
using System.Collections.Generic;
using System.Text;

namespace realSafewayz.Models
{
    public class IncidentReport
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string Incident { get; set; }
        public int UpvotesAmount { get; set; }
        public Comment[] Comment { get; set; }
        public int DislikesAmount { get; set; }
        public string IncidentDescription { get; set; }
    }
}
