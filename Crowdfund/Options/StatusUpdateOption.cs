using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Options
{
    public class StatusUpdateOption
    {
        public int Id { get; set; }
        public string Payload{ get; set; }
        public int ProjectId { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
