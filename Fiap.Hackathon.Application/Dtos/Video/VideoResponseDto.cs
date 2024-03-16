namespace Fiap.Hackathon.Application.Dtos;

public class VideoResponseDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime FinishProcessedDate { get; set; }
    public string SnapshotsBase64 { get; set; } = string.Empty;
    public string Username { get; set; }
}