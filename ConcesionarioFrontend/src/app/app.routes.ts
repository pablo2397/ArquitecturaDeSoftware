import { Routes } from '@angular/router';
import { VehiculoComponent } from './vehiculo/vehiculo.component';
import { TipoVehiculoComponent } from './tipo-vehiculo/tipo-vehiculo.component';
import { AsesorComponent } from './asesor/asesor.component';
import { HomeComponent } from './home/home.component';
import { authGuard } from './guards/guard-guard';

export const routes: Routes = [
    {path: 'app-home', component: HomeComponent},
    {path: 'app-vehiculo',canActivate: [authGuard], component: VehiculoComponent},
    {path: 'app-tipo-vehiculo', canActivate: [authGuard], component: TipoVehiculoComponent},
    {path: 'app-asesor', canActivate: [authGuard], component: AsesorComponent}
];