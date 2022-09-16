import { Component, OnInit } from '@angular/core';
import { Create_Product } from 'src/app/shared/contracts/products/create_product.ts';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.scss']
})
export class CreateProductComponent implements OnInit {

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
  }

  create(name: HTMLInputElement, stock: HTMLInputElement, price: HTMLInputElement,
    isOfferable: HTMLInputElement, isSold: HTMLInputElement,
    categoryId: HTMLInputElement, brandId: HTMLInputElement,
    colorId: HTMLInputElement, sizeId: HTMLInputElement,
    appUserId: HTMLInputElement) {

      const create_product: Create_Product = new Create_Product();

      // mapleme yapılır
      create_product.name = name.value;
      create_product.stock = parseInt(stock.value);
      create_product.price = parseFloat(price.value);
      create_product.isOfferable = JSON.parse((isOfferable.value));
      create_product.isSold = JSON.parse((isSold.value));
      create_product.categoryId = parseInt(categoryId.value);
      create_product.brandId = parseInt(brandId.value);
      create_product.colorId = parseInt(colorId.value);
      create_product.sizeId = parseInt(sizeId.value);
      create_product.appUserId = parseInt(appUserId.value);

      // servis çağrılır
      this.productService.create(create_product, errorMessage => {
        alert(errorMessage)
      });
  }
}
