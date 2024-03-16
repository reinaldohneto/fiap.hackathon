using Fiap.Hackathon.Application.Dtos.User;
using Fiap.Hackathon.WebPage.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiap.Hackathon.WebPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public async Task<IActionResult> OnPostAsync(string username, string password)
        {
            var user = new UserLoginDto() { UserName = username, Password = password };
            await _userService.LoginAsync(user);

            return Redirect("./ObjectList");
        }
    }
}
