import { Component, OnInit } from '@angular/core';

import { Sucursal } from '../../models/sucursal';
import { DataService } from '../../data.service';

import { SemanasGym } from '../../models/SemanasGym';

import { toInteger } from '@ng-bootstrap/ng-bootstrap/util/util';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-copy-sem',
  templateUrl: './copy-sem.component.html',
  styleUrls: ['./copy-sem.component.css']
})
export class CopySemComponent implements OnInit {

  sucursalesDisp: Sucursal[] = [];
  sucursalSeleccionada = {} as Sucursal;

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getSucursales();
  }

  onChange(idSucursal: string): void {
    this.sucursalSeleccionada = this.sucursalesDisp.find(x => x.id === Number(idSucursal));
  }

  getSucursales(): void {
    this.dataService.getAllSucursales().subscribe(data => this.sucursalesDisp = data);
  }

  getDates(originalDate: string, copyDate: string, sucursalId:string): void {
    /**Esta funcion se encarga de enviar las fechas de inicio y final de semana para que las actividades sean copiadas
    I/O:
    originalDate: Numero de semana Original
    copyDate:  Numero de semana por Copiar
    sucursalId:  Id de la sucursal Duena de ambas semanas

    **/
    var Oweek: string[];
    var Cweek: string[];

    Oweek = this.getDatesAux(originalDate);
 
    Cweek = this.getDatesAux(copyDate);

    var resDates: string[][] = [Oweek, Cweek];

    //console.log(resDates[0][0]);

    var startingDate: string = resDates[0][0];
    var finishingDate: string = resDates[0][0];
    var startingDateToCopy: string = resDates[0][0];
    var finishingDateToCopy: string = resDates[0][0];

    const semanaPorCopiar = { startingDate, finishingDate, startingDateToCopy, finishingDateToCopy };
    
    this.dataService.copiarSemanasGym(semanaPorCopiar,+sucursalId).subscribe();

  }

  getDatesAux(originalDate: string) {

    // truncates strings from week html for further process
    //O for Original C for CopyWeek
    //Como solo tenemos el numero de semana y el ao calculamos la fecha del primer dia de la semana, Retorna como res un array de strings
    var year: number = +originalDate.slice(0, -4);
    var week: number = +originalDate.slice(6);
    var firstDay: string = this.getDateOfISOWeek(week, year);
    //Una vez obtenida la fecha del primer dia se calcula el ultimo dia de esa semana y se trunca la string para obtener la fecha del dia final
    var last: Date;
    var calcday: number;

    calcday = +firstDay.slice(-2) + 6;
    last = new Date(firstDay.slice(0, -2) + calcday.toString()); //Error Conocido, no se puede seleccionar como semana por copiar, una semana que tenga dias en 2 mese distintos
    var lastDay: string = last.toISOString().slice(0, 10);
    var dates: string[]

    dates = [firstDay, lastDay];
    return dates;

  }

  getDateOfISOWeek(w, y) {
  //Esta funcion obtiene el numero de la semana (w) y el ano (y), y obtiene el primer dia de la semana
  var simple = new Date(y, 0, 1 + (w - 1) * 7);
  var dow = simple.getDay();
  var ISOweekStart = simple;
  if (dow <= 4)
    ISOweekStart.setDate(simple.getDate() - simple.getDay() + 1);
  else
      ISOweekStart.setDate(simple.getDate() + 8 - simple.getDay());
    return this.formatDate(ISOweekStart.toDateString().slice(4));
  }

  formatDate(date: string) {
    //esta funcion obtiene una string de fecha con el formato ISO y lo convierte a un formato numerio simplificado (YYYY-MM-DD)
    var resDate: string;
    resDate = date.slice(-4) + "-" + this.getMonthNumb(date.slice(0, -8)) + "-" + date.slice(4, -5);
    return resDate;
  }

  getMonthNumb(month: string) {
    //Solo convierto de nombre a Num
    switch (month) {
      case "Jan":
        return "01";
      case "Feb":
        return "02";
      case "Mar":
        return "03";
      case "Apr":
        return "04";
      case "May":
        return "05";
      case "Jun":
        return "06";
      case "Jul":
        return "07";
      case "Aug":
        return "08";
      case "Sep":
        return "09";
      case "Oct":
        return "10";
      case "Nov":
        return "11";
      case "Dec":
        return "12";
    }}


}
