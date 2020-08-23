using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Models
{
    public class CategoriesProjectsBO
    {
        public int ProjectId { get; set; }
        public int CategoryId { get; set; }
        
        public CategoriesProjectsBO()
        {

        }

        public CategoriesProjectsBO(int projectId, int categoryId)
        {
            ProjectId = projectId;
            CategoryId = categoryId;
        }
    }
}
