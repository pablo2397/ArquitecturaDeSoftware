import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tipoVehiculo } from './tipo-vehiculo.objetec';

@Injectable({
  providedIn: 'root'
})
export class TipoVehiculoService {
urlBase: string = 'https://localhost:7199/TipoVehiculo/';
  constructor(private http: HttpClient) { }

  Get(): Observable<tipoVehiculo[]>{
    return this.http.get<tipoVehiculo[]>(`${this.urlBase}GetAll`);
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
