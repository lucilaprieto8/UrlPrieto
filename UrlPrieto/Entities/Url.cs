using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlPrieto.Entities
{
    public class Url
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string largeUrl { get; set; }
        public string smallUrl { get; set; }
        public int Cont { get; set; }
        public Categories Category { get; set; }
        public int IdCategory { get; set; }

        public Users Users { get; set; }

        public int IdUser { get; set; }

    }
}
