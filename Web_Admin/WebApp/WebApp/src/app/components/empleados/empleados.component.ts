import { Component, OnInit } from '@angular/core';
import {Empleado} from '../../models/empleado';
import {DataService} from '../../data.service';
import {Sucursal} from '../../models/sucursal';
import {Planilla} from '../../models/planilla';
import {Puesto} from '../../models/puesto';

@Component({
  selector: 'app-empleados',
  templateUrl: './empleados.component.html',
  styleUrls: ['./empleados.component.css']
})
export class EmpleadosComponent implements OnInit {

  empleadosDisp: Empleado[] = [];
  empleadoSeleccionado = {} as Empleado;

  sucursales: Sucursal[] = [];
  sucursalSeleccionada = {} as Sucursal;

  planillas: Planilla[] = [];
  planillaSeleccionada: Planilla = new Planilla();

  puestos: Puesto[] = [];
  puestoSeleccionado: Puesto = new Puesto();

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getEmpleados();
    this.getSucursale();
    this.getPlanilla();
    this.getPuesto();
  }

  onChange(idSucursal: string): void{
    this.empleadoSeleccionado = this.empleadosDisp.find(x => x.idCard === Number(idSucursal));
  }

  onChangeS(idS: string): void{
    this.sucursalSeleccionada = this.sucursales.find(x => x.id === Number(idS));
  }

  onChangePL(idpl: string): void{
    this.planillaSeleccionada = this.planillas.find(x => x.id === Number(idpl));
  }

  onChangeP(idp: string): void{
    this.puestoSeleccionado = this.puestos.find(x => x.id === Number(idp));
  }

  getEmpleados(): void{
    this.dataService.getAllEmpleados().subscribe(data => this.empleadosDisp = data);
  }

  getSucursale(): void{
    this.dataService.getAllSucursales().subscribe(data => this.sucursales = data);
  }

  getPlanilla(): void{
    this.dataService.getAllPlanillas().subscribe(data => this.planillas = data);
  }

  getPuesto(): void{
    this.dataService.getAllPuestos().subscribe(data => this.puestos = data);
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
