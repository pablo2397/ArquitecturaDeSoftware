import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { asesor } from './asesor.objetec';
import { departamento } from './departamento.objetec';
import { ciudad } from './ciudad.objetec';

@Injectable({
  providedIn: 'root'
})
export class AsesorService {
  urlBase: string = 'https://localhost:7199/Asesor/';
  constructor(private http: HttpClient) { }

  Get(): Observable<asesor[]>{
    return this.http.get<asesor[]>(`${this.urlBase}GetAll`);
  }

  Post(formulario: any): Observable<number>{
    return this.http.post<number>(`${this.urlBase}Create`, formulario);
  }

  Delete(id: number): Observable<number>{
    return this.http.delete<number>(`${this.urlBase}${id}`);
  }

  Edit(formulario: any): Observable<number>{
    return this.http.put<number>(`${this.urlBase}Edit`, formulario);
  }
  GetDepartamento(): Observable<departamento[]>{
    return this.http.get<departamento[]>(`https://localhost:7199/Departamento/GetAll`);
  }
  GetCiudad(): Observable<ciudad[]>{
    return this.http.get<ciudad[]>(`https://localhost:7199/Ciudad/GetAll`);
  }
}
