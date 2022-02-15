using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rocky.Models
{
    public class ApplicationType
    {
        [Key]
        public int Id { get; set; }
        
        [DisplayName("Application Type")]
        [Required(ErrorMessage = "Заполните имя Application")]
        public string Name { get; set; }
      
    }
}
