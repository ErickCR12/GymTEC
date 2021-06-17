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

  crearServicio(name: string): void{
    const nuevoServicio = {name} as Servicio;
    this.dataService.crearServicio(nuevoServicio).subscribe(data => {
      if (data){
        this.getServicios();
      }
    });
  }

  modificarServicio(idStr: string, name: string): void{
    const id = Number(idStr);
    const ServicioporModificar = {id, name} as Servicio;
    this.dataService.updateServicio(ServicioporModificar).subscribe(data => {
        this.getServicios();
      });
  }

  eliminarServicio(idStrSelect: string): void{
    const id = Number(idStrSelect);
    this.dataService.deleteServicio(id).subscribe();
    this.serviciosDisp = this.serviciosDisp.filter(x => x.id !== id);
  }

}
