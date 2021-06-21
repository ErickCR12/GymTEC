import { Component, OnInit } from '@angular/core';
import { Producto } from '../../models/producto';
import { DataService } from '../../data.service';

@Component({
  selector: 'app-product-manager',
  templateUrl: './product-manager.component.html',
  styleUrls: ['./product-manager.component.css']
})
export class ProductManagerComponent implements OnInit {

  productos: Producto[] = [];
  productoSeleccionado: Producto = {} as Producto;
  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.getProductos();
  }

  onChange(idProductoStr: string): void{
    this.productoSeleccionado = this.productos.find(x => x.barCode === Number(idProductoStr));
  }


  getProductos(): void {
    this.dataService.getAllProductos().subscribe( data => this.productos = data);
  }

  addProduct(name: string, description: string, barCodeStr: string, priceStr: string): void {
    const barCode = Number(barCodeStr);
    const price = Number(priceStr);
    const newProd = {barCode, name, description, price} as Producto;
    console.log(newProd);
    this.dataService.addProducto(newProd).subscribe(data => {
      if (data) {
        this.getProductos();
      }
    });
  }

  modificarProducto(name: string, description: string, barCodeStr: string, priceStr: string): void{
    const barCode = Number(barCodeStr);
    const price = Number(priceStr);
    const PLanillaporModificar = {barCode, name, description, price} as Producto;
    this.dataService.updateProducto(PLanillaporModificar).subscribe(data => {
      this.getProductos();
    });
  }

  eliminarProducto(barCodeStr: string): void{
    const barCode = Number(barCodeStr);
    this.dataService.deleteProducto(barCode).subscribe();
    this.productos = this.productos.filter(x => x.barCode !== barCode);

  }

}
