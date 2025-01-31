import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Revisor } from '../interfaces/revisor-model';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RevisorService {
 
  private readonly _apiUrl = `${environment.endpoint}Revisores/`;

  constructor(private _http: HttpClient) { }

  registrar(revisor: Revisor): Observable<any> {
    return this._http.post(`${this._apiUrl}`, revisor);
  }

  editar(revisor: Revisor): Observable<any> {
    return this._http.put(`${this._apiUrl}`, revisor);
  }

  eliminar(id: number): Observable<any> {
    return this._http.delete(`${this._apiUrl}${id}`);
  }

  listarTodos(): Observable<Revisor[]> {
    return this._http.get<Revisor[]>(`${this._apiUrl}`);
  }
}
