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
                province: string, canton: string, district: string, salaryStr: string, phone_numbersTR: string): void{
    const idCard = Number(idCardStr);
    const idGym = Number(idGymStr);
    const idJobPosition = Number(idJobPositionStr);
    const idPayroll = Number(idPayrollStr);
    const salary = Number(salaryStr);
    const phonenumber = Number(phone_numbersTR);
    const nuevoEmpleado = {idCard, idGym, idJobPosition, idPayroll, email, password, name, last_name1, last_name2,
          province, canton, district, salary, phonenumber} as Empleado;
    this.dataService.addEmpleado(nuevoEmpleado).subscribe();
  }

  modificarEmpleado(idSelectStr: string, idCardStr: string,
                    idGymStr: string, idJobPositionStr: string, idPayrollStr: string, email: string,
                    password: string, name: string, last_name1: string, last_name2: string,
                    province: string, canton: string, district: string, salaryStr: string, phone_numbersTR: string): void{
    const idSelect = Number(idSelectStr);
    const idCard = Number(idCardStr);
    const idGym = Number(idGymStr);
    const idJobPosition = Number(idJobPositionStr);
    const idPayroll = Number(idPayrollStr);
    const salary = Number(salaryStr);
    const phonenumber = Number(phone_numbersTR);
    const empleadoAmodiciar = {idSelect, idCard, idGym, idJobPosition, idPayroll, email, password, name, last_name1, last_name2,
      province, canton, district, salary, phonenumber} as Empleado;
    this.dataService.updateEmpleado(empleadoAmodiciar).subscribe();
  }

  eliminarEmpleado(idStr: string): void{
    const idCard = Number(idStr);
    this.dataService.deleteEmpleado(idCard).subscribe();
  }

}
