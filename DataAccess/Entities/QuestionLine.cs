using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccess.Entities
{
    [Table("Questions")]
    public class QuestionLine : Base.BaseIdEntity
    {
        public DateTime Date { get; set; }

        public bool IsPublic { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(2000)]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Author { get; set; }

        [EmailAddress(ErrorMessage = "Неверный Email адрес")]
        [MaxLength(2000)]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Email { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public int ThemeId { get; set; }

        [ForeignKey("ThemeId")]
        public virtual Theme Theme { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(2000)]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Question { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(2000)]
        public string Answer { get; set; }
    }
}
