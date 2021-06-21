import { Component, OnInit } from '@angular/core';
import { Sucursal } from '../../models/sucursal';
import { DataService } from '../../data.service';
import { Empleado } from '../../models/empleado';
import { Clase } from '../../models/clase';
import { Servicio } from '../../models/servicio';

@Component({
  selector: 'app-create-class',
  templateUrl: './create-class.component.html',
  styleUrls: ['./create-class.component.css']
})
export class CreateClassComponent implements OnInit {

  ind: boolean = false;

  sucursalesDisp: Sucursal[] = [];
  empleadosDisp: Empleado[] = [];
  servDisp: Servicio[] = [];
  clasesDisp: Clase[] = [];

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getSucursales();
    this.getServicios();
    this.getEmpleados();
  }

  onChangeIndv(): void {
    this.ind = !this.ind;
  }

  getSucursales(): void {
    this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
  }

  getEmpleados(): void {
    this.dataService.getAllEmpleados().subscribe(data => this.empleadosDisp = data);
  }

  getServicios(): void {
    this.dataService.getAllServicios().subscribe(data => this.servDisp = data);
  }

  createClass(idGymIO, idServiceIO, idInstructorIO, startTime, endTime, date, capacityIO): void {
    const isGroup = !this.ind;
    const idGym = +idGymIO;
    const idInstructor = +idInstructorIO;
    const idService = +idServiceIO;
    const capacity = (isGroup) ? +capacityIO : 1;

    const newClass = { idGym, idService, idInstructor, startTime, endTime, date, capacity, isGroup} as Clase;
    this.dataService.crearClase(newClass).subscribe();
  }

}
