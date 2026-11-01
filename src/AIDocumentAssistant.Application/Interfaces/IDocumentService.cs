using AIDocumentAssistant.Application.DTOs;

namespace AIDocumentAssistant.Application.Interfaces;

public interface IDocumentService
{
    Task<DocumentResponseDto> UploadAsync( string fileName, string extractedText);
    Task<DocumentResponseDto?> GetByIdAsync(Guid id);
    Task<List<DocumentResponseDto>> GetAllAsync();
}