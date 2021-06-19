import { Component, OnInit } from '@angular/core';
import { Producto } from '../../models/producto';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-product-manager',
  templateUrl: './product-manager.component.html',
  styleUrls: ['./product-manager.component.css']
})
export class ProductManagerComponent implements OnInit {

  //deviceTypes: Productos[];
  //private dataService: DataService
  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    //this.getProductos();
  }

  getProductos(): void {
    //this.dataService.getAllProductos().subscribe( data => this.Productos = data);
  }

  addProduct(name: string, description:string , barCode: number, price: number): void {
    
    const newProd = { barCode, name, description, price } as Producto;

    this.dataService.addProducto(newProd).subscribe(data => {
      if (data) {
        this.getProductos
      }
    });

  }

}
