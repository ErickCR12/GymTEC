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
    this.puestoSeleccionado = this.puestosDisp.find(x => x.idPuesto === Number(idPuestoS));
  }


  getPuestos(): void{
    this.dataService.getAllPuestos().subscribe(data => this.puestosDisp = data);
  }

  crearPuesto(idStr: string, nombrePuesto: string): void{
    const idPuesto = Number(idStr);
    const nuevoPuesto = {nombrePuesto, idPuesto} as Puesto;
    this.dataService.addPuesto(nuevoPuesto).subscribe();
  }

  // tslint:disable-next-line:typedef
  modificarPuesto(idStrSelect: string, idStr: string, nombrePuesto: string){
    const idSelect = Number(idStrSelect);
    const idPuesto = Number(idStr);
    const PuestoporModificar = {idSelect, nombrePuesto, idPuesto} as Puesto;
    this.dataService.updatePuesto(PuestoporModificar).subscribe();
  }

  eliminarPuesto(idStrSelect: string): void{
    const idPuesto = Number(idStrSelect);
    this.dataService.deletePuesto(idPuesto).subscribe();
  }

}
