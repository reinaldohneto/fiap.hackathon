using Fiap.Hackathon.Application.Dtos.User;
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

        public async Task<IActionResult> OnPostAsync(string username, string password)
        {
            var user = new UserLoginDto() { UserName = username, Password = password };
            return Redirect("./ObjectList");
        }
    }
}
