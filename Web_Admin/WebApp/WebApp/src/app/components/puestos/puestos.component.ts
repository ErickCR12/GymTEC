import { Component, OnInit } from '@angular/core';
import {Puesto} from '../../models/puesto';
import {DataService} from '../../data.service';


@Component({
  selector: 'app-puestos',
  templateUrl: './puestos.component.html',
  styleUrls: ['./puestos.component.css']
})

export class PuestosComponent implements OnInit {

  puestosDisp: Puesto[] = [];
  puestoSeleccionado: Puesto = new Puesto();

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getPuestos();
  }

  onChange(idPuestoS: string): void{
    this.puestoSeleccionado = this.puestosDisp.find(x => x.id === Number(idPuestoS));
  }


  getPuestos(): void{
    this.dataService.getAllPuestos().subscribe(data => this.puestosDisp = data);
  }

  crearPuesto(name: string): void{
    const nuevoPuesto = {name} as Puesto;
    this.dataService.addPuesto(nuevoPuesto).subscribe(data => {
      if (data){
        this.getPuestos();
      }
    });
  }

  modificarPuesto(idStr: string, name: string): void{
    const id = Number(idStr);
    const PuestoporModificar = {id, name} as Puesto;
    this.dataService.updatePuesto(PuestoporModificar).subscribe(data => {
      this.getPuestos();
    });
  }

  eliminarPuesto(idStrSelect: string): void{
    const idPuesto = Number(idStrSelect);
    this.dataService.deletePuesto(idPuesto).subscribe();
    this.puestosDisp = this.puestosDisp.filter(x => x.id !== idPuesto);
  }

}
