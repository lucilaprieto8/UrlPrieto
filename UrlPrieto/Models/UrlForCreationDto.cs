using System.ComponentModel.DataAnnotations;

namespace UrlPrieto.Models
{
    public class UrlForCreationDTO
    { 
        public int Id { get; set; }
        public string largeUrl { get; set; }
        public int categoryId { get; set; }
           
    }
}
