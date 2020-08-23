using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.ASP.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        [DisplayName("NUMERO DE COMPTE DU PROJET")]
        public string AccountNumber { get; set; }

        [DisplayName("PAYS")]
        public string Country { get; set; }

        public BankAccount()
        {

        }
    }
}
