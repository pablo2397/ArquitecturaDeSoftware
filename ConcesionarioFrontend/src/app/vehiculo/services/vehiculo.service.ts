import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Vehiculo } from './vehiculo.object';

@Injectable({
  providedIn: 'root'
})
export class VehiculoService {
urlBase: string = 'https://localhost:7199/Vehiculo/';
  constructor(private http: HttpClient) { }

  Get() : Observable<Vehiculo[]>{
    return this.http.get<Vehiculo[]>(`${this.urlBase}GetAll`);
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
}
