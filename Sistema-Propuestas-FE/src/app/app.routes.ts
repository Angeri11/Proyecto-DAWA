import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AsignarRevisoresComponent } from './components/asignar-revisores/asignar-revisores.component';
import { GenerarInformeComponent } from './components/generar-informe/generar-informe.component';
import { NotificarAlumnoComponent } from './components/notificar-alumno/notificar-alumno.component';
import { RegistrarPropuestaComponent } from './components/registrar-propuesta/registrar-propuesta.component';
import { RevisarPropuestasComponent } from './components/revisar-propuestas/revisar-propuestas.component';

//import { PruebaAComponent } from './components/prueba/prueba-a/prueba-a.component';
//import { PruebaBComponent } from './components/prueba/prueba-b/prueba-b.component';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'asignar-revisores', component: AsignarRevisoresComponent },
  { path: 'generar-informe', component: GenerarInformeComponent},
  { path: 'notificar-alumno', component: NotificarAlumnoComponent },
  { path: 'registrar-propuesta' , component: RegistrarPropuestaComponent},
  { path:'revisar-propuesta' , component: RevisarPropuestasComponent},

  { path: '**', redirectTo: 'home', pathMatch: 'full' },
];
