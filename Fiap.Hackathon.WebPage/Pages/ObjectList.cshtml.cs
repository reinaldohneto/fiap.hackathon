using Fiap.Hackathon.WebPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiap.Hackathon.WebPage.Pages
{
    public class ObjectListModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public ICollection<VideoDto> Videos { get; set; } = new List<VideoDto>();

        public ObjectListModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
    }
}
