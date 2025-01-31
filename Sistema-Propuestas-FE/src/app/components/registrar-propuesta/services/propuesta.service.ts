import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Propuesta } from '../interfaces/propuesta-model';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PropuestaService {

  private readonly _apiUrl = `${environment.endpoint}Propuestas/`;

  constructor(private _http: HttpClient) { }

  registrar(propuesta: Propuesta): Observable<any> {
    return this._http.post(`${this._apiUrl}`, propuesta);
  }

  editar(propuesta: Propuesta): Observable<any> {
    return this._http.put(`${this._apiUrl}`, propuesta);
  }

  eliminar(id: number): Observable<any> {
    return this._http.delete(`${this._apiUrl}${id}`);
  }

  listarTodas(): Observable<Propuesta[]> {
    return this._http.get<Propuesta[]>(`${this._apiUrl}`);
  }

  aceptar(id: number): Observable<any> {
    return this._http.put(`${this._apiUrl}aceptar/${id}`, {});
  }

  rechazar(id: number): Observable<any> {
    return this._http.put(`${this._apiUrl}rechazar/${id}`, {});
  }
  
}
