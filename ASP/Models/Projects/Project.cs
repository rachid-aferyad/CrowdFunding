using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CrowdFunding.ASP.Models.Projects
{
    public class Project
    {
        public int Id { get; set; }
        [DisplayName("TITRE")]
        public string Title { get; set; }
    }
}