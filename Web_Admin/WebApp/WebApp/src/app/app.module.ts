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
import { TratamientosComponent } from './components/tratamientos/tratamientos.component';
import { SucursalesComponent } from './components/sucursales/sucursales.component';
import { PuestosComponent } from './components/puestos/puestos.component';
import { PlanillaComponent } from './components/planilla/planilla.component';
import { EmpleadosComponent } from './components/empleados/empleados.component';
import { TiposEquiposComponent } from './components/tipos-equipos/tipos-equipos.component';
import { InventarioComponent } from './components/inventario/inventario.component';



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

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
    RouterModule,
    AppRoutingModule
  ],
  providers: [UsersService],
  bootstrap: [AppComponent]
})
export class AppModule { }
