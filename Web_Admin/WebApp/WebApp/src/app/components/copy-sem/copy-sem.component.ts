import { Component, OnInit } from '@angular/core';

import { Sucursal } from '../../models/sucursal';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-copy-sem',
  templateUrl: './copy-sem.component.html',
  styleUrls: ['./copy-sem.component.css']
})
export class CopySemComponent implements OnInit {

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