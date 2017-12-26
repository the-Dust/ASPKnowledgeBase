using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    [Table("Themes")]
    public class Theme : Base.BaseIdEntity
    {
        [Column(TypeName = "nvarchar")]
        [MaxLength(2000)]
        [Required(ErrorMessage = "Field can't be empty")]
        public string Description { get; set; }
    }
}
