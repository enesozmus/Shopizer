import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

 /* @ViewChild(ListProductComponent) listComponents: ListProductComponent;

  createdProduct(createdProduct: Create_Product){
    this.listComponents.getProducts();

  }*/

}
