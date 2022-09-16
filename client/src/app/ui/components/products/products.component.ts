import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { IBrand } from 'src/app/shared/contracts/brand';
import { IColor } from 'src/app/shared/contracts/color';
import { IPagination } from 'src/app/shared/contracts/paginations/pagination';
import { ProductParams } from 'src/app/shared/contracts/parameters/productParams';
import { IProduct } from 'src/app/shared/contracts/products/product';
import { ISize } from 'src/app/shared/contracts/size';
import { ProductsService } from './products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  products: IProduct[];
  brands: IBrand[];
  colors: IColor[];
  sizes: ISize[];

  productParams = new ProductParams();
  totalCount: number;

  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low ', value: 'priceDesc' },
  ];

  constructor(private productService: ProductsService) { }

  ngOnInit(): void {

    this.getProducts();
    this.getBrands();
    this.getColors();
    this.getSizes();
  }


  getProducts() {
    this.productService.getProducts(this.productParams).subscribe(response => {
      this.products = response.data;
      this.productParams.pageIndex = response.pageIndex;
      this.productParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    }
    )
  }


  getBrands() {
    this.productService.getBrands().subscribe(response => {
      this.brands = [{ id: 0, name: 'All' }, ...response];
    }, error => {
      console.log(error);
    })
  }


  getColors() {
    this.productService.getColors().subscribe(response => {
      this.colors = [{ id: 0, name: 'All' }, ...response];
    }, error => {
      console.log(error);
    })
  }


  getSizes() {
    this.productService.getSizes().subscribe(response => {
      this.sizes = [{ id: 0, name: 'All' }, ...response];
    }, error => {
      console.log(error);
    })
  }

  onBrandSelected(brandId: number) {
    this.productParams.brandId = brandId;
    this.getProducts();
  }

  onColorSelected(colorId: number) {
    this.productParams.colorId = colorId;
    this.getProducts();
  }

  onSizeSelected(sizeId: number) {
    this.productParams.sizeId = sizeId;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    this.productParams.sort = sort;
    this.getProducts();
  }

  onPageChanged(event: any) {
    this.productParams.pageIndex = event;
    this.getProducts();
  }
}
