using System.ComponentModel.DataAnnotations;

namespace UrlPrieto.Entities
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Url>urls { get; set; }
    }
}
