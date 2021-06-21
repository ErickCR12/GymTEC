import { Component, OnInit } from '@angular/core';
import { Sucursal } from '../../models/sucursal';
import { DataService } from '../../data.service';
import { Tratamiento } from '../../models/tratamiento';

@Component({
  selector: 'app-table-tratamientos',
  templateUrl: './table-tratamientos.component.html',
  styleUrls: ['./table-tratamientos.component.css']
})
export class TableTratamientosComponent implements OnInit {

  constructor(private dataService: DataService) { }

  sucursalesDisp: Sucursal[] = [];
  tratamientosDisp: Tratamiento[] = [];

  ngOnInit(): void {
    this.getSucursales();
    this.getTratamientos();
  }

  getTratamientos(): void{
    this.dataService.getAllTratamientos().subscribe(data => this.tratamientosDisp = data);
  }

  getSucursales(): void {
    this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
  }

  asociar(tratamiento: Tratamiento, sede): void {
    this.dataService.asociarSpa(tratamiento, +sede).subscribe();
  }

}
