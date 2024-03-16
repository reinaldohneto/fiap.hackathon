using Fiap.Hackathon.WebPage.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiap.Hackathon.WebPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnPostAsync(string email, string senha)
        {
            var user = new UserLoginDto(email, senha);
            return Redirect("./ObjectList");
        }
    }
}
