using System.Drawing;
using System.IO.Compression;
using FFMpegCore;
using Fiap.Hackathon.Domain.Video.Commands;
using Fiap.Hackathon.Domain.Video.Entities;
using Fiap.Hackathon.Infra.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Identity;

namespace Fiap.Hackathon.Worker.Consumers;

public class CreateVideoSnapshotsConsumer(IVideoRepository videoRepository, 
    UserManager<IdentityUser> userManager) : IConsumer<CreateVideoCommand>
{
    public async Task Consume(ConsumeContext<CreateVideoCommand> context)
    {
        var bytes = Convert.FromBase64String(context.Message.Base64);
        var stream = new MemoryStream(bytes);
        var outputFolder = @"C:\Projetos\Fiap.Hackathon\Videos\" + context.Message.Name + DateTime.Now.Ticks + @"\";

        Directory.CreateDirectory(outputFolder);
        
        var videoPath = outputFolder + "video.mp4";
        
        var fileStream = File.Create(videoPath);
        fileStream.CopyTo(stream);
        fileStream.Close();
        
        var videoInfo = FFProbe.Analyse(stream);
        var duration = videoInfo.Duration;

        var interval = TimeSpan.FromSeconds(20);
        
        for (var currentTime = TimeSpan.Zero; currentTime < duration; currentTime += interval)
        {
            Console.WriteLine($"Processando frame: {currentTime}");
            
            var outputPath = Path.Combine(outputFolder, $"frame_at_{currentTime.TotalSeconds}.jpg");
            FFMpeg.Snapshot(videoPath, outputPath, new Size(1920, 1080), currentTime);
        }
        
        string destinationZipFilePath = @"C:\Projetos\FIAP_HACK\FIAPProcessaVideo\FIAPProcessaVideo\images.zip";

        var streamZip = new MemoryStream();
        
        ZipFile.CreateFromDirectory(outputFolder, streamZip);

        var zipBytes = streamZip.ToArray();
        
        var video = new Video
        {
            SnapshotsBase64 = Convert.ToBase64String(zipBytes),
            FinishProcessedDate = DateTime.Now,
            Name = context.Message.Name,
            User = context.Message.User
        };

        await videoRepository.Create(video);
    }
}