import { Component, OnInit } from '@angular/core';
import {Tratamiento} from '../../models/tratamiento';

@Component({
  selector: 'app-tratamientos',
  templateUrl: './tratamientos.component.html',
  styleUrls: ['./tratamientos.component.css']
})
export class TratamientosComponent implements OnInit {

  tratamientosDisp: Tratamiento[] = [];
  tratamientos: Tratamiento = new Tratamiento();

  constructor() { }

  ngOnInit(): void {
  }

  agregarTratamientos(){
    this.tratamientosDisp.push(this.tratamientos);
    this.tratamientos = new Tratamiento();
  }

}
