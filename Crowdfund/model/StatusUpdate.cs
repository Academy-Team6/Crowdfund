using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.model
{
    public class StatusUpdate
    {
        public int Id { get; set; }
        public string Overload { get; set; }
        public Project Project { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
