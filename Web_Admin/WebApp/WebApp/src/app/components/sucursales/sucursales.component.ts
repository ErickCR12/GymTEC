import { Component, OnInit } from '@angular/core';
import {Sucursal} from '../../models/sucursal';
import {DataService} from '../../data.service';
// @ts-ignore


@Component({
  selector: 'app-sucursales',
  templateUrl: './sucursales.component.html',
  styleUrls: ['./sucursales.component.css']
})
export class SucursalesComponent implements OnInit {

  sucursalesDisp: Sucursal[] = [];
  sucursalSeleccionada = {} as Sucursal;

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getSucursales();
  }

  onChange(idSucursal: string): void{
     this.sucursalSeleccionada = this.sucursalesDisp.find(x => x.id === Number(idSucursal));
  }

  getSucursales(): void{
    this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
  }

  crearSucursal(name: string, province: string, canton: string, district: string,
                openingDate: string, openingTime: string, closingTime: string,
                idAdminStr: string, capacityStr: string): void{
    const idAdmin = Number(idAdminStr);
    const capacity = Number(capacityStr);
    const nuevaSucursal = {name, province, canton, district, openingDate, openingTime,
      closingTime, idAdmin, capacity} as Sucursal;
    this.dataService.addSucursal(nuevaSucursal).subscribe();
  }

  modificarSucursal(idStr: string, name: string, province: string, canton: string, district: string,
                    openingDate: string, openingTime: string, closingTime: string,
                    idAdminStr: string, capacityStr: string): void{
    const id = Number(idStr);
    const idAdmin = Number(idAdminStr);
    const capacity = Number(capacityStr);
    const sucursalPorModificar = {id, name, province, canton, district, openingDate, openingTime,
      closingTime, idAdmin, capacity} as Sucursal;
    this.dataService.updateSucursal(sucursalPorModificar).subscribe();
  }

  eliminarSucursal(idStr: string): void{
    const id = Number(idStr);
    this.dataService.deleteSucursal(id).subscribe();
  }

}
