import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Create_Product } from 'src/app/contracts/products/create_product.ts';
import { HttpClientService } from '../common/http-client.service';


@Injectable({
  providedIn: 'root'
})

export class ProductService {

  constructor(private httpClientService: HttpClientService) { }

  // ürün ekle
  create(product: Create_Product, errorCallBack?: (errorMessage: string) => void) {

    this.httpClientService.post(
      {
        controller: "products"
      },
      product)

      .subscribe(result => {
        alert("başarılı")
      }, (errorResponse: HttpErrorResponse) => {
        const _fluentErrors: Array<{ PropertyName: string, ErrorMessage: string, ErrorCode: string }> = errorResponse.error.Errors;

        let message = '';
        _fluentErrors.forEach((value, index) => {
          message += `${value.ErrorMessage}<br>`;
        });

        _fluentErrors[0].PropertyName;
        _fluentErrors[0].ErrorMessage;
        _fluentErrors[0].ErrorCode;

        console.log(message);
        errorCallBack(message);
      });
  }
}

