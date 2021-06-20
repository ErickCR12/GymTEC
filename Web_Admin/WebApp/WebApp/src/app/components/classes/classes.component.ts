import { Component, OnInit } from '@angular/core';
import { DataService } from '../../data.service';
import { FiltrosBusqueda } from '../../models/filtrosBusqueda';
import { Empleado } from '../../models/empleado';
import { Clase } from '../../models/clase';
import { Sucursal } from '../../models/sucursal';
import {Servicio} from '../../models/servicio';
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

  servicios: Servicio[] = [];


  ngOnInit(): void {
    this.getServicios();
    this.getSucursales();
  }

  getSucursales(): void{
    this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
  }

  getServicios(): void{
    this.dataService.getAllServicios().subscribe(data => this.servicios = data);
  }

  realizarBusqueda(idGymStr, date, startTime, endTime, idServiceStr ): void {
    const idGym = Number(idGymStr);
    const idService = Number(idServiceStr);
    const nullHolder = null;
    date = (date === '') ? null : date;
    startTime = (startTime === '') ? null : startTime;
    endTime = (endTime === '') ? null : endTime;
    const filtro = { idGym, idService, startTime, endTime, date } as FiltrosBusqueda;
    console.log(filtro);
    this.dataService.getClasesFiltradas(filtro).subscribe(data => this.clasesDisp = data);
  }

}
