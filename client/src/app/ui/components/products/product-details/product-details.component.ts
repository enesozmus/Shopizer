import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Item_Product } from 'src/app/shared/contracts/products/item_product';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  constructor(private productService: ProductsService, private activatedRoute: ActivatedRoute) { }

  product: Item_Product;

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    this.productService.getProduct(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe(product => {
      this.product = product;
    }, error => {
      console.log(error);
    })
  }

}
