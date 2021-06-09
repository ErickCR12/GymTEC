import { Component, OnInit } from '@angular/core';
import {Servicio} from '../../models/servicio';

@Component({
  selector: 'app-tratamientos',
  templateUrl: './tratamientos.component.html',
  styleUrls: ['./tratamientos.component.css']
})
export class TratamientosComponent implements OnInit {

  tratamientosDisp: Servicio[] = [];
  tratamientos: Servicio = new Servicio();

  constructor() { }

  ngOnInit(): void {
  }

  agregarTratamientos(){
    this.tratamientosDisp.push(this.tratamientos);
    this.tratamientos = new Servicio();
  }

}
