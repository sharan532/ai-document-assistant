import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { DocumentResponse, DocumentService } from '../../../core/services/document';
import { DatePipe } from '@angular/common';

@Component({
  imports: [DatePipe],
  selector: 'app-document-list',
  styleUrl: './document-list.scss',
  templateUrl: './document-list.html',
})
export class DocumentListComponent implements OnInit {
  private documentService = inject(DocumentService);

  documents: DocumentResponse[] = [];
  isLoading = false;
  private cdr = inject(ChangeDetectorRef);

  ngOnInit(): void {
    this.loadDocuments();
  }

  loadDocuments(): void {
    this.isLoading = true;

    this.documentService.getDocuments().subscribe({
      next: (result) => {
        this.documents = result;
        this.isLoading = false;
        this.cdr.markForCheck();
      },
      error: (error) => {
        console.error('Failed to load documents:', error);
        this.isLoading = false;
        this.cdr.markForCheck();
      }
    });
  }
}
