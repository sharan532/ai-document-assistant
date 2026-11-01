using AIDocumentAssistant.Application.Interfaces;
using AIDocumentAssistant.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace AIDocumentAssistant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly IDocumentService _documentService;
    private readonly PdfTextExtractor _pdfTextExtractor;

    public DocumentsController(
        IDocumentService documentService,
        PdfTextExtractor pdfTextExtractor)
    {
        _documentService = documentService;
        _pdfTextExtractor = pdfTextExtractor;
    }

    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(10 * 1024 * 1024)]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Please upload a valid PDF.");

        if (file.Length > 10 * 1024 * 1024)
            return BadRequest("File size cannot exceed 10 MB.");

        if (!Path.GetExtension(file.FileName)
            .Equals(".pdf", StringComparison.OrdinalIgnoreCase))
            return BadRequest("Only PDF files are allowed.");

        using var stream = file.OpenReadStream();

        var extractedText = _pdfTextExtractor.ExtractText(stream);

        if (string.IsNullOrWhiteSpace(extractedText))
            return BadRequest("No readable text found in the PDF.");

        var result = await _documentService.UploadAsync(
            file.FileName,
            extractedText);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var document = await _documentService.GetByIdAsync(id);

        if (document == null)
            return NotFound("Document not found.");

        return Ok(document);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var documents = await _documentService.GetAllAsync();
        return Ok(documents);
    }
}