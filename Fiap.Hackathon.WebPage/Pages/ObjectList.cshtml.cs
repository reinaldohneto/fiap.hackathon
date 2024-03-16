using Fiap.Hackathon.Application.Dtos;
using Fiap.Hackathon.WebPage.Models;
using Fiap.Hackathon.WebPage.Services.Videos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiap.Hackathon.WebPage.Pages
{
    public class ObjectListModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IVideoService _videoService;

        [BindProperty]
        public ICollection<VideoResponseDto> Videos { get; set; } = new List<VideoResponseDto>();

        public ObjectListModel(ILogger<IndexModel> logger, IVideoService videoService)
        {
            _logger = logger;
            _videoService = videoService;
        }

        public void OnGet()
        {
            Videos = _videoService.GetAll().Result;
        }
    }
}
