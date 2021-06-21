import { Component, OnInit } from '@angular/core';
import { DataService } from '../../data.service';
import { Sucursal } from '../../models/sucursal';
import { GeneracionPlanilla } from '../../models/generacionPlanilla';

@Component({
  selector: 'app-planilla',
  templateUrl: './planilla.component.html',
  styleUrls: ['./planilla.component.css']
})
export class VPlanillaComponent implements OnInit {

  planillasVisibles: GeneracionPlanilla[] = [];

  sucursalesDisp: Sucursal[] = [];
  sucursalSeleccionada = {} as Sucursal;
  modoEmpleo: string="";

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getSucursales();
  }

  onChange(idSucursal: string): void {
    this.sucursalSeleccionada = this.sucursalesDisp.find(x => x.id === Number(idSucursal));
  }

  getSucursales(): void {
    this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
  }

  planillaH(sedeId) {
    this.planillasVisibles = [];
    this.modoEmpleo = 'Horas Trabajadas';
    this.dataService.pagoPorHora(+sedeId).subscribe(data => this.planillasVisibles = data);
  }

  planillaM(sedeId) {
    this.planillasVisibles = [];
    this.modoEmpleo = 'Salario Mensual';
    this.dataService.pagoMensual(+sedeId).subscribe(data => this.planillasVisibles = data);
  }

  planillaC(sedeId) {
    this.planillasVisibles = [];
    this.modoEmpleo = 'Clases Impartidas';
    this.dataService.pagoPorClase(+sedeId).subscribe(data => this.planillasVisibles = data);
  }
}
