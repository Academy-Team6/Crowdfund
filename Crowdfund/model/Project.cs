using System.Collections.Generic;

namespace Crowdfund.model
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public List<Photo> Photos { get; set; }
        public List<Video> Videos { get; set; }
        public decimal TargetBudget { get; set; }
        public decimal CurrentBudget { get; set; }
        public decimal BudgetRatio { get; set; }
        public ProjectCreator ProjectCreator { get; set; }
        public List<RewardPackage> RewardPackages { get; set; }
        public Project()
        {
            Photos = new List<Photo>();
            Videos = new List<Video>();
            RewardPackages = new List<RewardPackage>();
        }
    }
    public enum ProjectCategory { 
        Tech, 
        Art, 
        Sports, 
        Health, 
        Industry, 
        Buisness, 
        Gadget, 
        Clothing 
    }
}
