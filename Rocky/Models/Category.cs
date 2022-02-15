using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rocky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Заполните имя категори")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Required(ErrorMessage = "Заполните порядок категори")] //Обязательное
        [Range(1, int.MaxValue, ErrorMessage = "Порядок категорий должен быть больше нуля")]
        public int DisplayOrder { get; set; }
    }
}
