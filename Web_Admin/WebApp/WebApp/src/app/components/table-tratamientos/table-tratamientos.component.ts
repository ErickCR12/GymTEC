import { Component, OnInit } from '@angular/core';
import { Sucursal } from '../../models/sucursal';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-table-tratamientos',
  templateUrl: './table-tratamientos.component.html',
  styleUrls: ['./table-tratamientos.component.css']
})
export class TableTratamientosComponent implements OnInit {

  constructor() { }

  sucursalesDisp: Sucursal[] = [];
  sucursalSeleccionada = {} as Sucursal;

  ngOnInit(): void {
  }

  onChange(idSucursal: string): void {
    //this.sucursalSeleccionada = this.sucursalesDisp.find(x => x.id === Number(idSucursal));
  }

  getSucursales(): void {
    //this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
  }



  eliminarSucursal(idStr: string): void {

  }

}
