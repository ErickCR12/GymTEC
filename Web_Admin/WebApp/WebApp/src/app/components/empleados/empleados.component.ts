import { Component, OnInit } from '@angular/core';
import {Empleado} from '../../models/empleado';
import {DataService} from '../../data.service';
import {Sucursal} from '../../models/sucursal';

@Component({
  selector: 'app-empleados',
  templateUrl: './empleados.component.html',
  styleUrls: ['./empleados.component.css']
})
export class EmpleadosComponent implements OnInit {

  empleadosDisp: Empleado[] = [];
  empleadoSeleccionado = {} as Empleado;

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getEmpleados();
  }

  onChange(idSucursal: string): void{
    this.empleadoSeleccionado = this.empleadosDisp.find(x => x.idCard === Number(idSucursal));
  }

  getEmpleados(): void{
    this.dataService.getAllEmpleados().subscribe(data => this.empleadosDisp = data);
  }

  crearEmpleado(idCardStr: string,
                idGymStr: string, idJobPositionStr: string, idPayrollStr: string, email: string,
                password: string, name: string, last_name1: string, last_name2: string,
                province: string, canton: string, district: string, salaryStr: string): void{
    const idCard = Number(idCardStr);
    const idGym = Number(idGymStr);
    const idJobPosition = Number(idJobPositionStr);
    const idPayroll = Number(idPayrollStr);
    const salary = Number(salaryStr);
    const nuevoEmpleado = {idCard, idGym, idJobPosition, idPayroll, email, password, name, last_name1, last_name2,
          province, canton, district, salary} as Empleado;
    this.dataService.addEmpleado(nuevoEmpleado).subscribe(data => {
      if (data){
        this.getEmpleados();
      }
    });
  }

  modificarEmpleado(idCardStr: string,
                    idGymStr: string, idJobPositionStr: string, idPayrollStr: string, email: string,
                    password: string, name: string, last_name1: string, last_name2: string,
                    province: string, canton: string, district: string, salaryStr: string): void{
    const idCard = Number(idCardStr);
    const idGym = Number(idGymStr);
    const idJobPosition = Number(idJobPositionStr);
    const idPayroll = Number(idPayrollStr);
    const salary = Number(salaryStr);
    const empleadoAModificar = {idCard, idGym, idJobPosition, idPayroll, email, password, name, last_name1, last_name2,
      province, canton, district, salary} as Empleado;
    this.dataService.updateEmpleado(empleadoAModificar).subscribe(data => {
        this.getEmpleados();
      });
  }

  eliminarEmpleado(idStr: string): void{
    const idCard = Number(idStr);
    this.dataService.deleteEmpleado(idCard).subscribe();
    this.empleadosDisp = this.empleadosDisp.filter(x => x.idCard !== idCard);
  }

}
