using Fiap.Hackathon.Application.Dtos.User;
using Fiap.Hackathon.WebPage.Services.Users;
using Fiap.Hackathon.Application.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiap.Hackathon.WebPage.Pages
{
    public class CreateUserModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ILogger<IndexModel> _logger;

        public CreateUserModel(ILogger<IndexModel> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public async Task<IActionResult> OnPostAsync(string username, string email, string password, string passwordConfirmation)
        {
            var user = new UserInputDto()
            {
                UserName = username,
                Email = email,
                Password = password,
                PasswordConfirmation = passwordConfirmation
            };

            if (user.Validate(new UserInputDtoValidator()))
            {
                await _userService.CreateAsync(user);
                return Redirect("./ObjectList");
            }

            WarnInvalidData("Usuário inválido. Corrija as informações e tente novamente");
            return Page();
        }

        private IActionResult WarnInvalidData(string message)
        {
            TempData["ErrorMessage"] = message;
            return RedirectToAction("CreateUser");
        }
    }
}
