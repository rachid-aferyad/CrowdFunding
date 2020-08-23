using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Models
{
    public class BankAccountBO
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Country { get; set; }
    }
}
