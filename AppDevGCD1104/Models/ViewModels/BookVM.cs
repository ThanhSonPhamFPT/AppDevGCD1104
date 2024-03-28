using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppDevGCD1104.Models.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
