
using AIDocumentAssistant.Domain.Entities;

namespace AIDocumentAssistant.Application.Interfaces;

public interface IDocumentRepository
{
    Task AddAsync(Document document);

    Task<Document?> GetByIdAsync(Guid id);
    Task<List<Document>> GetAllAsync();
}
