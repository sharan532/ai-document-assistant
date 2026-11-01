import { Component, signal, ViewChild } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DocumentUploadComponent } from './features/documents/document-upload/document-upload';
import { DocumentListComponent } from './features/documents/document-list/document-list';

@Component({
  imports: [DocumentUploadComponent,
    DocumentListComponent
  ],
  selector: 'app-root',
  styleUrl: './app.scss',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('ai-document-assistant-ui');
    @ViewChild(DocumentListComponent)
  documentList!: DocumentListComponent;

  refreshDocuments(): void {
    this.documentList?.loadDocuments();
  }
}
