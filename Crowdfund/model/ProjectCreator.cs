using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Crowdfund.model
{
    public class ProjectCreator
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter description"), MaxLength(300)]
        [StringLength(100)]
        public string Description { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter last name"), MaxLength(30)]
        public string LastName { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter first name"), MaxLength(30)]
        public string FirstName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter Email ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        public List<Project> Projects { get; set; }
        public ProjectCreator()
        {
            Projects = new List<Project>();
        }
    }
}
