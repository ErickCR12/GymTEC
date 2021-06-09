import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ServiciosComponent } from './components/servicios/servicios.component';
import { SucursalesComponent } from './components/sucursales/sucursales.component';
import { TratamientosComponent } from './components/tratamientos/tratamientos.component';
import { PuestosComponent } from './components/puestos/puestos.component';
import { PlanillaComponent } from './components/planilla/planilla.component';
import { EmpleadosComponent } from './components/empleados/empleados.component';
import { TiposEquiposComponent } from './components/tipos-equipos/tipos-equipos.component';
import { InventarioComponent } from './components/inventario/inventario.component';

const routes: Routes = [
  {
    path: 'servicios',
    component: ServiciosComponent,
  },

  {
    path: 'sucursales',
    component: SucursalesComponent,
  },

  {
    path: 'tratamientos',
    component: TratamientosComponent,
  },

  {
    path: 'puestos',
    component: PuestosComponent,
  },

  {
    path: 'planilla',
    component: PlanillaComponent,
  },

  {
    path: 'empleados',
    component: EmpleadosComponent,
  },

  {
    path: 'tipos',
    component: TiposEquiposComponent,
  },

  {
    path: 'inventario',
    component: InventarioComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
