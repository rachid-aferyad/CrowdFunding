using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrowdFunding.BLL.Models
{
    public enum LevelType
    {
        [Display(Name = "Fixe")]
        FIXED,
        [Display(Name = "Cumulé")]
        CUMULATED
    }
}
