using Fiap.Hackathon.Application.Dtos.User;
using Fiap.Hackathon.Application.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiap.Hackathon.WebPage.Pages
{
    public class CreateUserModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public CreateUserModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
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
