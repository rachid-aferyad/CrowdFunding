using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Models
{
    public class Modification
    {
        public int ProjectId { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
