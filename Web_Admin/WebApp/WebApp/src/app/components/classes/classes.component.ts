import { Component, OnInit } from '@angular/core';
import { DataService } from '../../data.service';
import { FiltrosBusqueda } from '../../models/filtrosBusqueda';
import { Empleado } from '../../models/empleado';
import { Clase } from '../../models/clase';
import { Sucursal } from '../../models/sucursal';
@Component({
  selector: 'app-classes',
  templateUrl: './classes.component.html',
  styleUrls: ['./classes.component.css']
})
export class ClassesComponent implements OnInit {

  constructor(private dataService: DataService) { }

  clasesDisp: Clase[] = [];
  claseSeleccionado = {} as Clase;

  sucursalesDisp: Sucursal[] = [];
  sucursalSeleccionado = {} as Sucursal;


  ngOnInit(): void {
    this.getclases();
  }

  getclases() {
    const idGym=0;
    const idService=0;
    const startTime="";
    const endTime = "";
    const date = "";
    const filtro = { idGym, idService, startTime, endTime, date } as FiltrosBusqueda;
    //this.dataService.getClasesFiltradas(filtro).subscribe(data => this.clasesDisp = data);
  }

  realizarBusqueda(idGym, date, startTime, endTime, idService ) {
    const filtro = { idGym, idService, startTime, endTime, date } as FiltrosBusqueda;

    this.dataService.getClasesFiltradas(filtro).subscribe();
  }

  getSucursales(): void {
    this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
  }

}
