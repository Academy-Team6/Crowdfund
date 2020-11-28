using System.Collections.Generic;
namespace Crowdfund.model
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public List<Media> Medias { get; set; }
        public decimal TargetBudget { get; set; }
        public decimal CurrentBudget { get; set; }
        public decimal BudgetRatio { get; set; }
        public ProjectCreator ProjectCreator { get; set; }
        public List<RewardPackage> RewardPackages { get; set; }
        public Project()
        {
            Medias = new List<Media>();
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