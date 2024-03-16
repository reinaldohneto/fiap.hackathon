using Fiap.Hackathon.Application.Dtos.Common;

namespace Fiap.Hackathon.Application.Dtos.Video;

public class VideoCreateInputDto : BaseDto
{
    public required string Base64 { get; set; }
    public required string Name { get; set; }
}