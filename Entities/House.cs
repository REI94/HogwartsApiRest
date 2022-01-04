using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class House : EntityBase
    {
        [Required(ErrorMessage = "Please enter House Name")]
        [Column(TypeName = "varchar(10)")]
        public string Name { get; set; } = string.Empty;
    }
}
