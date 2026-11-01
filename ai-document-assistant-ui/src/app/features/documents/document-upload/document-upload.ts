import { Component, EventEmitter, inject, Output } from '@angular/core';
import { DocumentService } from '../../../core/services/document';

@Component({
  imports: [],
  selector: 'app-document-upload',
  styleUrl: './document-upload.scss',
  templateUrl: './document-upload.html',
})
export class DocumentUploadComponent {
  private documentService = inject(DocumentService);

  @Output() uploadCompleted = new EventEmitter<void>();

  selectedFile: File | null = null;
  message = '';
  isUploading = false;

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    this.selectedFile = input.files?.[0] ?? null;
    this.message = '';
  }

  upload(): void {
    if (!this.selectedFile) {
      this.message = 'Please select a PDF file.';
      return;
    }

    this.isUploading = true;
    this.message = '';

    this.documentService.uploadDocument(this.selectedFile).subscribe({
      next: () => {
        this.message = 'Document uploaded successfully!';
        this.selectedFile = null;
        this.isUploading = false;
        this.uploadCompleted.emit();
      },
      error: (error) => {
        this.message = error.error || 'Upload failed. Please try again.';
        this.isUploading = false;
      }
    });
  }
}
