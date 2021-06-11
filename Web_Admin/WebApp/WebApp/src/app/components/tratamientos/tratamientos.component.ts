import { Component, OnInit } from '@angular/core';
import {Servicio} from '../../models/servicio';
import {DataService} from '../../data.service';
import {Tratamiento} from '../../models/tratamiento';

@Component({
  selector: 'app-tratamientos',
  templateUrl: './tratamientos.component.html',
  styleUrls: ['./tratamientos.component.css']
})
export class TratamientosComponent implements OnInit {

    tratamientosDisp: Tratamiento[] = [];
  tratamientoSeleccionado: Tratamiento = new Tratamiento();

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getTratamientos();
  }

  onChange(idServicio: string): void{
    this.tratamientoSeleccionado = this.tratamientosDisp.find(x => x.id === Number(idServicio));
  }

  getTratamientos(): void{
    this.dataService.getAllTratamientos().subscribe(data => this.tratamientosDisp = data);
  }

  crearTratamiento(idStr: string, name: string): void{
    const id = Number(idStr);
    const nuevoServicio = {id, name} as Servicio;
    this.dataService.crearTratamiento(nuevoServicio).subscribe();
  }

  modificarTratamiento(idStrSelect: string, idStr: string, name: string){
    const idSelect = Number(idStrSelect);
    const id = Number(idStr);
    const ServicioporModificar = {idSelect, id, name} as Servicio;
    this.dataService.updateTratamiento(ServicioporModificar).subscribe();
  }

  eliminarTratamiento(idStrSelect: string): void{
    const id = Number(idStrSelect);
    this.dataService.deleteTratamiento(id).subscribe();
  }

}
