using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Options
{
    public class MediaOption
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Payload { get; set; }
        public int ProjectId { get; set; }
    }
}
