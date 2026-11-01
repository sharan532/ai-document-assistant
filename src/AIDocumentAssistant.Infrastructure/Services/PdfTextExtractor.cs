using UglyToad.PdfPig;

namespace AIDocumentAssistant.Infrastructure.Services;

public class PdfTextExtractor
{
    public string ExtractText(Stream pdfStream)
    {
        using var document = PdfDocument.Open(pdfStream);

        var text = new System.Text.StringBuilder();

        foreach (var page in document.GetPages())
        {
            text.AppendLine(page.Text);
        }

        return text.ToString();
    }
}