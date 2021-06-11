import { Component, OnInit } from '@angular/core';
import {Planilla} from '../../models/planilla';
import {DataService} from '../../data.service';
import {Sucursal} from '../../models/sucursal';

@Component({
  selector: 'app-planilla',
  templateUrl: './planilla.component.html',
  styleUrls: ['./planilla.component.css']
})
export class PlanillaComponent implements OnInit {

  planillaDisp: Planilla[] = [];
  planillaSeleccionada: Planilla = new Planilla();

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getPlanilla();
  }

  onChange(idPlanillaS: string): void{
    this.planillaSeleccionada = this.planillaDisp.find(x => x.id === Number(idPlanillaS));
  }

  getPlanilla(): void{
    this.dataService.getAllPlanillas().subscribe(data => this.planillaDisp = data);
  }

  crearPlanilla(idStr: string, description: string, hourlyPayStr: string, monthlyPayStr: string, payPerClassStr: string): void{
    const id = Number(idStr);
    const hourlyPay = Number(hourlyPayStr);
    const monthlyPay = Number(monthlyPayStr);
    const payPerClass = Number(payPerClassStr);
    const nuevaPlanilla = {id, description, hourlyPay, monthlyPay, payPerClass} as Planilla;
    this.dataService.addPlanilla(nuevaPlanilla).subscribe();
  }

  modificarPlanilla(IdStrSelect: string, idStr: string, description: string, hourlyPayStr: string, monthlyPayStr: string, payPerClassStr: string): void{
    const idSelect = Number(IdStrSelect);
    const id = Number(idStr);
    const hourlyPay = Number(hourlyPayStr);
    const monthlyPay = Number(monthlyPayStr);
    const payPerClass = Number(payPerClassStr);
    const PLanillaporModificar = {IdStrSelect, id, description, hourlyPay, monthlyPay, payPerClass} as Planilla;
    this.dataService.updatePlanilla(PLanillaporModificar).subscribe();
  }

  eliminarPlanilla(idStr: string): void{
    const id = Number(idStr);
    this.dataService.deletePlanilla(id).subscribe();
  }

}
