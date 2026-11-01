
namespace AIDocumentAssistant.Application.DTOs;

public class DocumentResponseDto
{
    public Guid Id { get; set; }

    public string FileName { get; set; } = string.Empty;

    public DateTime UploadedAtUtc { get; set; }
}
