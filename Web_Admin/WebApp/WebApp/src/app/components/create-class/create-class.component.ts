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
  sucursalSeleccionada = {} as Sucursal;

  empleadosDisp: Empleado[] = [];
  empleadoSeleccionada = {} as Empleado;

  servDisp: Servicio[] = [];
  servicioSeleccionada = {} as Servicio;

  clasesDisp: Clase[] = [];
  claseSeleccionada = {} as Clase;

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getSucursales();
  }

  onChangeIndv(): void {
    this.ind = !this.ind;
  }

  onChange(idSucursal: string): void {
    this.sucursalSeleccionada = this.sucursalesDisp.find(x => x.id === Number(idSucursal));
  }
  onChangeEmp(idEmpleado: string): void {
    this.empleadoSeleccionada = this.empleadosDisp.find(x => x.email === idEmpleado);
  }
  onChangeClass(idEmpleado: string): void {
    this.claseSeleccionada = this.clasesDisp.find(x => x.id === +idEmpleado);
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
    const capacity = +capacityIO;

    const newClass = { idGym, idService, idInstructor, startTime, endTime, date, capacity, isGroup} as Clase;
  }

}
