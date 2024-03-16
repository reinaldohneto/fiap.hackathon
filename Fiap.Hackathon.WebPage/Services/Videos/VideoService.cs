using Fiap.Hackathon.Application.Dtos;
using Fiap.Hackathon.WebPage.Services.Client;
using Newtonsoft.Json;

namespace Fiap.Hackathon.WebPage.Services.Videos
{
    public class VideoService : IVideoService
    {
        private readonly string? _baseUrl;
        private readonly IClientService _clientService;

        public VideoService(IClientService clientService, IConfiguration configuration)
        {
            _clientService = clientService;
            _baseUrl = configuration.GetValue<string>("ApiUrl");
        }

        public async Task<ICollection<VideoResponseDto>> GetAll()
        {
            var res = await _clientService.Client.GetAsync(_baseUrl + "video");
            var videos = JsonConvert.DeserializeObject<ICollection<VideoResponseDto>>(res.Content.ReadAsStringAsync().Result);

            return videos;
        }
    }
}
