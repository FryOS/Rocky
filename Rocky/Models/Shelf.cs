using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rocky.Models
{
    public class Shelf
    {
        [Key]
        public int ShelfId { get; set; }
        
        public string ShaelfName { get; set; }
      
    }
}
