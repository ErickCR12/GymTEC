import { Component, OnInit } from '@angular/core';
import {Planilla} from '../../models/planilla';

@Component({
  selector: 'app-planilla',
  templateUrl: './planilla.component.html',
  styleUrls: ['./planilla.component.css']
})
export class PlanillaComponent implements OnInit {

  planillaDisp: Planilla[] = [];
  planillaD: Planilla = new Planilla();

  constructor() { }

  ngOnInit(): void {
  }
  agregarPlanilla(){
    console.log(this.planillaDisp);
    this.planillaDisp.push(this.planillaD);
    this.planillaD = new Planilla();
  }

}
