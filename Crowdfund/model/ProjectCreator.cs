using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.model
{
    public class ProjectCreator
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        List<Project> Projects { get; set; }
        public ProjectCreator()
        {
            Projects = new List<Project>();
        }
    }
}
