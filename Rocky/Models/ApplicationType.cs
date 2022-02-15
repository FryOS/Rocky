using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rocky.Models
{
    public class ApplicationType
    {
        [Key]
        public int AppId { get; set; }
        
        [DisplayName("Application Type")]
        [Required(ErrorMessage = "Заполните имя Application")]
        public string ApplicationTypeName { get; set; }
      
    }
}
