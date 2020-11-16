using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.model
{
    public class Backer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        // a list for different projects involved
        public List<Project> Projects { get; set; }
        // a list consists of different reward packages
        public List<RewardPackage> RewardPackage { get; set; }
    }
}
