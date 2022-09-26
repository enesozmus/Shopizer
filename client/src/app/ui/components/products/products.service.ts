import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { IBrand } from 'src/app/shared/contracts/brand';
import { IColor } from 'src/app/shared/contracts/color';
import { IPagination } from 'src/app/shared/contracts/paginations/pagination';
import { ProductParams } from 'src/app/shared/contracts/parameters/productParams';
import { Item_Product } from 'src/app/shared/contracts/products/item_product';
import { IProduct } from 'src/app/shared/contracts/products/product';
import { ISize } from 'src/app/shared/contracts/size';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private http: HttpClient) { }


  getProducts(productParams: ProductParams) {

    let params = new HttpParams();

    if (productParams.brandId !== 0) {
      params = params.append('brandId', productParams.brandId.toString());
    }

    if (productParams.colorId !== 0) {
      params = params.append('colorId', productParams.colorId.toString());
    }

    if (productParams.sizeId !== 0) {
      params = params.append('sizeId', productParams.sizeId.toString());
    }

    params = params.append('sort', productParams.sort);
    params = params.append('pageIndex', productParams.pageIndex.toString());
    params = params.append('pageSize', productParams.pageSize.toString());


    return this.http.get<IPagination>('http://localhost:5153/api/products', { observe: 'response', params })
      .pipe(map(response => { return response.body; }));
  }

  getProduct(id: number){
    return this.http.get<Item_Product>('http://localhost:5153/api/products/' + id);
  }

  getBrands() {
    return this.http.get<IBrand[]>('http://localhost:5153/api/brands');
  }

  getColors() {
    return this.http.get<IColor[]>('http://localhost:5153/api/colors');
  }
  getSizes() {
    return this.http.get<ISize[]>('http://localhost:5153/api/sizes');
  }
}
