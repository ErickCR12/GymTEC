import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import {MessagesComponent} from './messages/messages.component';
import {UsersService} from './users.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ServiciosComponent } from './components/servicios/servicios.component';
import { RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';

import { TratamientosComponent } from './components/tratamientos/tratamientos.component';
import { SucursalesComponent } from './components/sucursales/sucursales.component';
import { PuestosComponent } from './components/puestos/puestos.component';
import { PlanillaComponent } from './components/planilla/planilla.component';
import { EmpleadosComponent } from './components/empleados/empleados.component';
import { TiposEquiposComponent } from './components/tipos-equipos/tipos-equipos.component';
import { InventarioComponent } from './components/inventario/inventario.component';

import { ProductManagerComponent } from './components/product-manager/product-manager.component';
import { LoginScreen } from './components/loginComponent/login.component';
import { RegisterComponent } from './components/register-component/register-component.component';
import { GymConfigComponent } from './components/gym-config/gym-config.component';
import { VPlanillaComponent } from './components/view-planilla/planilla.component';
import { ClassesComponent } from './components/classes/classes.component';
import { CreateClassComponent } from './components/create-class/create-class.component';
import { CopySemComponent } from './components/copy-sem/copy-sem.component';
import { CopyGymComponent } from './components/copy-gym/copy-gym.component';
import { TableInventarioComponent } from './components/table-inventario/table-inventario.component';
import { TableTratamientosComponent } from './components/table-tratamientos/table-tratamientos.component';
import { TableProductosComponent } from './components/table-productos/table-productos.component';
import { CalendarComponent } from './components/calendar/calendar.component';



@NgModule({
  declarations: [
    AppComponent,
    MessagesComponent,
    ServiciosComponent,
    TratamientosComponent,
    SucursalesComponent,
    PuestosComponent,
    PlanillaComponent,
    EmpleadosComponent,
    TiposEquiposComponent,
    InventarioComponent,
    ProductManagerComponent,
    RegisterComponent,
    LoginScreen,
    GymConfigComponent,
    VPlanillaComponent,
    ClassesComponent,
    CreateClassComponent,
    CopySemComponent,
    CopyGymComponent,
    TableInventarioComponent,
    TableTratamientosComponent,
    TableProductosComponent,
    CalendarComponent

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
    RouterModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
    }),
  ],
  providers: [UsersService],
  bootstrap: [AppComponent]
})
export class AppModule { }
