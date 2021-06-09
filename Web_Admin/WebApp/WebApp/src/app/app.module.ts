import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { LoginScreen } from './components/loginComponent/login.component';

import { RegisterComponent } from './components/register-component/register-component.component';
import { EditProfileComponent } from './components/edit-profile/edit-profile.component';
import { ShopComponent } from './components/shop/shop.component';
import { ReportsComponent } from './components/reports/reports.component';
import { DeviceMaganerComponent } from './components/device-maganer/device-maganer.component';
import { DevicesComponent } from './components/devices/devices.component';
import { DevicesPerUserComponent } from './components/devices-per-user/devices-per-user.component';
import { UploadpageComponent } from './components/uploadpage/uploadpage.component';
import { DeviceListTableComponent } from './components/device-list-table/device-list-table.component';
import { DasboardComponent } from './components/dasboard/dasboard.component';
import { ConfirmationComponent } from './components/confirmation/confirmation.component';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import {MessagesComponent} from './messages/messages.component';
import {UsersService} from './users.service';
import { DevicesPerRegionComponent } from './components/devices-per-region/devices-per-region.component';
import { DeviceTypesUsageComponent } from './components/device-types-usage/device-types-usage.component';
import { DeviceDailyUsageComponent } from './components/device-daily-usage/device-daily-usage.component';
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
    LoginScreen,
    RegisterComponent,
    EditProfileComponent,
    ShopComponent,
    ReportsComponent,
    DeviceMaganerComponent,
    DevicesComponent,
    DevicesPerUserComponent,
    UploadpageComponent,
    DeviceListTableComponent,
    MessagesComponent,
    DasboardComponent,
    DevicesPerRegionComponent,
    DeviceDailyUsageComponent,
    DeviceTypesUsageComponent,
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
  bootstrap: [AppComponent, LoginScreen]
})
export class AppModule { }
