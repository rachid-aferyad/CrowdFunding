using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrowdFunding.ASP.Models.Projects
{
    public class Level
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le titre est obligatoire")]
        [DisplayName("TITRE DU PALIER")]
        public string Title { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Le montant doit être supérieur à 1")]
        [DisplayName("MONTANT DU PALIER")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "La récompense est obligatoire")]
        [DisplayName("RECOMPENSE")]
        public string Award { get; set; }
        public int ProjectId { get; set; }
    }
}