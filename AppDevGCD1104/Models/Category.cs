using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppDevGCD1104.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Display Order of Category")]
        [Range(1,20)]
        public int DisplayOrder { get; set; }
    }
}
