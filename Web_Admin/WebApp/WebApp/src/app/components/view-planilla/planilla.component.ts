import { Component, OnInit } from '@angular/core';
import { DataService } from '../../data.service';
import { Sucursal } from '../../models/sucursal';
import { Planilla } from '../../models/planilla';

@Component({
  selector: 'app-planilla',
  templateUrl: './planilla.component.html',
  styleUrls: ['./planilla.component.css']
})
export class VPlanillaComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
