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
  modoEmpleo = '';

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getSucursales();
  }

  getSucursales(): void {
    this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
  }

  planillaH(sedeId): void {
    this.modoEmpleo = 'Horas Trabajadas';
    this.dataService.pagoPorHora(+sedeId).subscribe(data => this.planillasVisibles = data);
  }

  planillaM(sedeId): void {
    this.modoEmpleo = 'Salario Mensual';
    this.dataService.pagoMensual(+sedeId).subscribe(data => {
      this.planillasVisibles = data;
      console.log(this.planillasVisibles);
      }
    );
  }

  planillaC(sedeId): void {
    this.modoEmpleo = 'Clases Impartidas';
    this.dataService.pagoPorClase(+sedeId).subscribe(data => this.planillasVisibles = data);
  }
}
