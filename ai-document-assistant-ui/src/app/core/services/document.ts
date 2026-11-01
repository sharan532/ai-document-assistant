import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface DocumentResponse {
  id: string;
  fileName: string;
  uploadedAtUtc: string;
}

@Injectable({
  providedIn: 'root'
})
export class DocumentService {

  private http = inject(HttpClient);

  private apiUrl = `${environment.apiUrl}/Documents`;

  uploadDocument(file: File): Observable<DocumentResponse> {
    const formData = new FormData();
    formData.append('file', file);

    return this.http.post<DocumentResponse>(
      `${this.apiUrl}/upload`,
      formData
    );
  }

  getDocuments(): Observable<DocumentResponse[]> {
    return this.http.get<DocumentResponse[]>(this.apiUrl);
  }

  getDocumentById(id: string): Observable<DocumentResponse> {
    return this.http.get<DocumentResponse>(`${this.apiUrl}/${id}`);
  }
}