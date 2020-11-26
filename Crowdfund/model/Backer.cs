using System.Collections.Generic;

namespace Crowdfund.model
{
    public class Backer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //public List<Project> Projects { get; set; }
        public List<Transaction> Transactions { get; set; }
        //public Backer()
        //{
        //    RewardPackages = new List<RewardPackage>();
        //}
    }
}
