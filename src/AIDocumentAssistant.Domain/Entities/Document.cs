using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIDocumentAssistant.Domain.Entities
{
    public class Document
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string FileName { get; private set; } = string.Empty;
        public string ExtractedText { get; private set; } = string.Empty;
        public DateTime UploadedAtUtc { get; private set; } = DateTime.UtcNow;

        private Document()
            {
                
            }

        public Document(string fileName, string extractedText)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException(
                    "File name is required.", nameof(fileName));

            if (string.IsNullOrWhiteSpace(extractedText))
                throw new ArgumentException(
                    "Extracted text is required.", nameof(extractedText));

            FileName = fileName;
            ExtractedText = extractedText;
        }
    }
}