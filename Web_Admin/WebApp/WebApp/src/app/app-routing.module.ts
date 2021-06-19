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

import { LoginScreen } from './components/loginComponent/login.component';
import { RegisterComponent } from './components/register-component/register-component.component';
import { ProductManagerComponent } from './components/product-manager/product-manager.component';
import { GymConfigComponent } from './components/gym-config/gym-config.component';
import { VPlanillaComponent } from './components/view-planilla/planilla.component';
import { ClassesComponent } from './components/classes/classes.component';
import { CreateClassComponent } from './components/create-class/create-class.component';
import { CopySemComponent } from './components/copy-sem/copy-sem.component';
import { CopyGymComponent } from './components/copy-gym/copy-gym.component';


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
  },
    //_______________________________________________________
  {
    path: 'login',
    component: LoginScreen,
  },

  {
    path: 'register',
    component: RegisterComponent,
  },

  {
    path: 'clases',
    component: ClassesComponent,
  },

  {
    path: 'copiarGym',
    component: CopyGymComponent,
  },

  {
    path: 'copiarSem',
    component: CopySemComponent,
  },

  {
    path: 'cProducto',
    component: ProductManagerComponent,
  },

  {
    path: 'vPlanilla',
    component: VPlanillaComponent,
  },

  {
    path: 'configGym',
    component: GymConfigComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
