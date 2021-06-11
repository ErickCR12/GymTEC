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
    this.tipoSeleccionado = this.tiposDisp.find(x => x.idEquipo === Number(idEquipo));
  }

  getEquipo(): void{
    this.dataService.getAllEquipos().subscribe(data => this.tiposDisp = data);
  }

  crearEquipo(idStr: string, name: string): void{
    const idEquipo = Number(idStr);
    const nuevoEquipo = {name, idEquipo} as Equipo;
    this.dataService.addEquipo(nuevoEquipo).subscribe();
  }

  modificarEquipo(idStrSelect: string, idStr: string, name: string){
    const idSelect = Number(idStrSelect);
    const idEquipo = Number(idStr);
    const EquipoaModificar = {idSelect, name, idEquipo} as Equipo;
    this.dataService.updateEquipo(EquipoaModificar).subscribe();
  }

  eliminarEquipo(idStrSelect: string): void{
    const idEquipo = Number(idStrSelect);
    this.dataService.deleteEquipo(idEquipo).subscribe();
  }

}
