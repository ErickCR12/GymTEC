import { Component, OnInit } from '@angular/core';
import {Equipo} from '../../models/equipo';
import {DataService} from '../../data.service';

@Component({
  selector: 'app-tipos-equipos',
  templateUrl: './tipos-equipos.component.html',
  styleUrls: ['./tipos-equipos.component.css']
})
export class TiposEquiposComponent implements OnInit {

  tiposDisp: Equipo[] = [];
  tipoSeleccionado = {} as Equipo;

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getEquipo();
  }

  onChange(idEquipo: string): void{
    this.tipoSeleccionado = this.tiposDisp.find(x => x.id === Number(idEquipo));
  }

  getEquipo(): void{
    this.dataService.getAllEquipos().subscribe(data => this.tiposDisp = data);
  }

  crearEquipo(name: string): void{
    const nuevoEquipo = {name} as Equipo;
    this.dataService.addEquipo(nuevoEquipo).subscribe(data => {
      if (data){
        this.getEquipo();
      }
    });
  }

  modificarEquipo(idStr: string, name: string){
    const id = Number(idStr);
    const EquipoaModificar = {name, id} as Equipo;
    this.dataService.updateEquipo(EquipoaModificar).subscribe(data => {
        this.getEquipo();
      });
  }

  eliminarEquipo(idStrSelect: string): void{
    const idEquipo = Number(idStrSelect);
    this.dataService.deleteEquipo(idEquipo).subscribe();
    this.tiposDisp = this.tiposDisp.filter(x => x.id !== idEquipo);
  }

}
