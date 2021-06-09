import { Component, OnInit } from '@angular/core';
import {Puesto} from '../../models/puesto';

@Component({
  selector: 'app-puestos',
  templateUrl: './puestos.component.html',
  styleUrls: ['./puestos.component.css']
})
export class PuestosComponent implements OnInit {

  puestosDisp: Puesto[] = [];
  puestosD: Puesto = new Puesto();

  constructor() { }

  ngOnInit(): void {
  }

  agregarPuesto(){
    this.puestosDisp.push(this.puestosD);
    this.puestosD = new Puesto();
  }
}
