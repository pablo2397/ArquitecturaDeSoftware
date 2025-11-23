import { Injectable, inject, PLATFORM_ID } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { isPlatformBrowser } from '@angular/common';
import { Observable } from 'rxjs';
import { LoginResponse } from './usuarios.object';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private platformId = inject(PLATFORM_ID);

  urlBase: string = 'https://localhost:7199/User/';

  constructor(private http: HttpClient) { }

  Login(Usuario: string, Clave: string): Observable<LoginResponse> {
    const login = {
      username: Usuario,
      password: Clave
    };
    return this.http.post<LoginResponse>(`${this.urlBase}Login`, login);
  }

  isAuthenticated(): boolean {
    // 👇 Verifica si estamos en el navegador
    if (isPlatformBrowser(this.platformId)) {
      return localStorage.getItem('auth') === 'true';
    }
    return false; // SSR no puede autenticar
  }

  setAuth(value: boolean) {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.setItem('auth', value ? 'true' : 'false');
    }
  }

  logout() {
    if (isPlatformBrowser(this.platformId)) {
      localStorage.removeItem('auth');
    }
  }
}
