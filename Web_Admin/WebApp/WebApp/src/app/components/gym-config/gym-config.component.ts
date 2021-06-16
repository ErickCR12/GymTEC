import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-gym-config',
  templateUrl: './gym-config.component.html',
  styleUrls: ['./gym-config.component.css']
})
export class GymConfigComponent implements OnInit {

  createClass: boolean = false;
  tratamientos: boolean = false;
  Inventario: boolean = false;
  Asosiacion: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  clickAso() {
    this.Asosiacion = true;
    this.Inventario, this.tratamientos, this.createClass = false;
  }

  clickInventario() {
    this.Inventario = true;
    this.Asosiacion, this.tratamientos, this.createClass = false;
  }

  clickTramiento() {
    this.tratamientos = true;
    this.Asosiacion, this.Inventario, this.createClass = false;
  }

  clickCreateClass() {
    this.createClass = true;
    this.Asosiacion, this.Inventario, this.tratamientos = false;
  }
}
