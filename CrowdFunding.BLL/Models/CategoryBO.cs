using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Models
{
    public class CategoryBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CategoryBO()
        {

        }
        public CategoryBO(string name, string description)
        {
            Name = name;
            Description = description;
        }

        internal CategoryBO(int id, string name, string description)
            : this(name, description)
        {
            Id = id;
        }
    }
}
