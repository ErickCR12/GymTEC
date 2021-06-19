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
    this.Inventario = false;
    this.tratamientos = false;
    this.createClass = false;
  }

  clickInventario() {
    this.Inventario = true;
    this.Asosiacion = false;
    this.tratamientos = false;
    this.createClass = false;
  }

  clickTramiento() {
    this.tratamientos = true;
    this.Asosiacion = false;
    this.Inventario = false;
    this.createClass = false;
  }

  clickCreateClass() {
    this.createClass = true;
    this.Asosiacion = false;
    this.Inventario = false;
    this.tratamientos = false;
  }
}
