import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from './services/auth.service';
import { isPlatformBrowser } from '@angular/common';
import { PLATFORM_ID } from '@angular/core';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  formulario: FormGroup;

  // Inyecciones modernas
  private authservice = inject(AuthService);
  private formBuilder = inject(FormBuilder);
  private router = inject(Router);
  private platformId = inject(PLATFORM_ID);

  ngOnInit(): void {

    if (this.isBrowser() && this.isAuthenticated()) {
      this.router.navigateByUrl('app-asesor');
    }

    this.formulario = this.formBuilder.group({
      usuario: ['', Validators.required],
      clave: ['', Validators.required]
    });
  }

  login() {
    if (!this.formulario.valid) return;

    const { usuario, clave } = this.formulario.value;

    this.authservice.Login(usuario, clave).subscribe({
      next: (res) => {
        if (res.message === 'Bienvenido') {

          if (this.isBrowser()) {
            localStorage.setItem('auth', 'true');
          }

          this.router.navigateByUrl('app-asesor');

        } else {
          alert('No se pudo guardar');
        }
      },

      error: (error) => {
        console.log(error);
      }
    });
  }

  isBrowser(): boolean {
    return isPlatformBrowser(this.platformId);
  }

  isAuthenticated(): boolean {
    return this.isBrowser() && localStorage.getItem('auth') === 'true';
  }
}