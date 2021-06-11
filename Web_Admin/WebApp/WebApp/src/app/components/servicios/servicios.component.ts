import { Component, OnInit } from '@angular/core';
import {DataService} from '../../data.service';
import {Servicio} from '../../models/servicio';

@Component({
  selector: 'app-servicios',
  templateUrl: './servicios.component.html',
  styleUrls: ['./servicios.component.css']
})
export class ServiciosComponent implements OnInit {

  serviciosDisp: Servicio[] = [];
  servicioSeleccionado: Servicio = new Servicio();

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getServicios();
  }

  onChange(idServicio: string): void{
    this.servicioSeleccionado = this.serviciosDisp.find(x => x.id === Number(idServicio));
  }

  getServicios(): void{
    this.dataService.getAllServicios().subscribe(data => this.serviciosDisp = data);
  }

  crearServicio(idStr: string, name: string): void{
    const id = Number(idStr);
    const nuevoServicio = {id, name} as Servicio;
    this.dataService.crearTratamiento(nuevoServicio).subscribe();
  }

  modificarServicio(idStrSelect: string, idStr: string, name: string){
    const idSelect = Number(idStrSelect);
    const id = Number(idStr);
    const ServicioporModificar = {idSelect, id, name} as Servicio;
    this.dataService.updateTratamiento(ServicioporModificar).subscribe();
  }

  eliminarServicio(idStrSelect: string): void{
    const id = Number(idStrSelect);
    this.dataService.deleteTratamiento(id).subscribe();
  }

}
