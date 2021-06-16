import { Component, OnInit } from '@angular/core';
import { Sucursal } from '../../models/sucursal';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-copy-gym',
  templateUrl: './copy-gym.component.html',
  styleUrls: ['./copy-gym.component.css']
})
export class CopyGymComponent implements OnInit {

  sucursalesDisp: Sucursal[] = [];
  sucursalSeleccionada = {} as Sucursal;

  constructor() { }

  ngOnInit(): void {
    this.getSucursales();
  }

  onChange(idSucursal: string): void {
    //this.sucursalSeleccionada = this.sucursalesDisp.find(x => x.id === Number(idSucursal));
  }

  getSucursales(): void {
    //this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
  }

  crearSucursal(name: string, province: string, canton: string, district: string,
    openingDate: string, openingTime: string, closingTime: string,
    idAdminStr: string, capacityStr: string) {
  }

  modificarSucursal(idStr: string, name: string, province: string, canton: string, district: string,
    openingDate: string, openingTime: string, closingTime: string,
    idAdminStr: string, capacityStr: string): void {

  }

  eliminarSucursal(idStr: string): void {

  }

}
