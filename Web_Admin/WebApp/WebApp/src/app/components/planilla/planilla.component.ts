import { Component, OnInit } from '@angular/core';
import {Planilla} from '../../models/planilla';
import {DataService} from '../../data.service';

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

  crearPlanilla(description: string): void{
    const nuevaPlanilla = {description} as Planilla;
    this.dataService.addPlanilla(nuevaPlanilla).subscribe(data => {
      if (data){
        this.getPlanilla();
      }
    });
  }

  modificarPlanilla(idStr: string, description: string): void{
    const id = Number(idStr);
    const PLanillaporModificar = {id, description} as Planilla;
    this.dataService.updatePlanilla(PLanillaporModificar).subscribe(data => {
        this.getPlanilla();
      });
  }

  eliminarPlanilla(idStr: string): void{
    const id = Number(idStr);
    this.dataService.deletePlanilla(id).subscribe();
    this.planillaDisp = this.planillaDisp.filter(x => x.id !== id);

  }

}
