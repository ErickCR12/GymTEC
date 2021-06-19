import { Component, OnInit } from '@angular/core';
import {Sucursal} from '../../models/sucursal';
import {DataService} from '../../data.service';
import {Empleado} from '../../models/empleado';
// @ts-ignore


@Component({
  selector: 'app-sucursales',
  templateUrl: './sucursales.component.html',
  styleUrls: ['./sucursales.component.css']
})
export class SucursalesComponent implements OnInit {

  sucursalesDisp: Sucursal[] = [];
  sucursalSeleccionada = {} as Sucursal;

  empleados: Empleado[] = [];
  empleadoSeleccionado = {} as Empleado;

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getSucursales();
    this.getEmpleados();
  }

  onChange(idSucursal: string): void{
     this.sucursalSeleccionada = this.sucursalesDisp.find(x => x.id === Number(idSucursal));
  }

  onChangeE(idEmpleado: string): void{
    this.empleadoSeleccionado = this.empleados.find(x => x.idCard === Number(idEmpleado));
  }

  getSucursales(): void{
    this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
  }

  getEmpleados(): void{
    this.dataService.getAllEmpleados().subscribe(data => this.empleados = data);
  }

  crearSucursal(name: string, province: string, canton: string, district: string,
                openingDate: string, openingTime: string, closingTime: string,
                idAdminStr: string, capacityStr: string): void{
    const idAdmin = Number(idAdminStr);
    const capacity = Number(capacityStr);
    const nuevaSucursal = {name, province, canton, district, openingDate, openingTime,
      closingTime, idAdmin, capacity} as Sucursal;
    this.dataService.addSucursal(nuevaSucursal).subscribe(data => {
      if (data){
        this.getSucursales();
      }
    });
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
    this.getSucursales();
  }

  eliminarSucursal(idStr: string): void{
    const id = Number(idStr);
    this.dataService.deleteSucursal(id).subscribe();
    this.sucursalesDisp = this.sucursalesDisp.filter(x => x.id !== id);
  }

}
