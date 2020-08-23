using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.DAL.Models
{
    public class Rejection
    {
        public int RejectorId { get; set; }
        public int ProjectId { get; set; }
        public DateTime RejectionDate { get; set; }
        public string Comment { get; set; }
    }
}
