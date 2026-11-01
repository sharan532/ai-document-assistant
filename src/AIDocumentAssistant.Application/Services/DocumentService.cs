using AIDocumentAssistant.Application.DTOs;
using AIDocumentAssistant.Application.Interfaces;
using AIDocumentAssistant.Domain.Entities;

namespace AIDocumentAssistant.Application.Services;

public class DocumentService : IDocumentService
{
    private readonly IDocumentRepository _documentRepository;

    public DocumentService(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public async Task<DocumentResponseDto> UploadAsync(
        string fileName,
        string extractedText)
    {
        var document = new Document(fileName, extractedText);

        await _documentRepository.AddAsync(document);

        return new DocumentResponseDto
        {
            Id = document.Id,
            FileName = document.FileName,
            UploadedAtUtc = document.UploadedAtUtc
        };
    }

    public async Task<DocumentResponseDto?> GetByIdAsync(Guid id)
    {
        var document = await _documentRepository.GetByIdAsync(id);

        if (document == null)
            return null;

        return new DocumentResponseDto
        {
            Id = document.Id,
            FileName = document.FileName,
            UploadedAtUtc = document.UploadedAtUtc
        };
    }

    public async Task<List<DocumentResponseDto>> GetAllAsync()
    {
        var documents = await _documentRepository.GetAllAsync();

        return documents.Select(document => new DocumentResponseDto
        {
            Id = document.Id,
            FileName = document.FileName,
            UploadedAtUtc = document.UploadedAtUtc
        }).ToList();
    }
}