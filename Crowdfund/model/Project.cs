using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Crowdfund.model
{
    public class Project
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter title of project"), MaxLength(300)]
        [StringLength(20)]
        public string Title { get; set; }
        public string Category { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter title of project"), MaxLength(300)]
        [StringLength(100)]
        public string Description { get; set; }
        public List<Media> Medias { get; set; }
        public decimal TargetBudget { get; set; }
        public decimal CurrentBudget { get; set; }
        public decimal BudgetRatio => CurrentBudget / TargetBudget;
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