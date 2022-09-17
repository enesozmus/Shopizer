import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, firstValueFrom } from 'rxjs';
import { IPaginationWithParameters } from 'src/app/shared/contracts/paginations/paginationWithParamaters';
import { Create_Product } from 'src/app/shared/contracts/products/create_product.ts';
import { HttpClientService } from '../common/http-client.service';


@Injectable({
  providedIn: 'root'
})

export class ProductService {

  constructor(private httpClientService: HttpClientService) { }


  // ürünleri listele

  async list(index: number, size: number, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void): Promise<IPaginationWithParameters> {

    const promiseData: Promise<IPaginationWithParameters> = this.httpClientService.get<IPaginationWithParameters>(
      {
        controller: "products/withParamaters",
        queryString: `pageRequest.pageIndex=${index}&pageRequest.pageSize=${size}`
      }).toPromise();

    promiseData.then(s => successCallBack())
      .catch((errorResponse: HttpErrorResponse) => errorCallBack(errorResponse.message));

    return await promiseData;
  }



  // ürün ekle
  create(product: Create_Product, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {

    this.httpClientService.post(
      {
        controller: "products"
      }, product)
      .subscribe(result => {
        successCallBack();
      }, (errorResponse: HttpErrorResponse) => {
        const _fluentErrors: Array<{ PropertyName: string, ErrorMessage: string, ErrorCode: string }> = errorResponse.error.Errors;

        let message = '';
        _fluentErrors.forEach((value, index) => {
          message += `${value.ErrorMessage}<br>`;
        });
        console.log(message);
        errorCallBack(message);
        //_fluentErrors[0].PropertyName;
        //_fluentErrors[0].ErrorMessage;
        //_fluentErrors[0].ErrorCode;
      });
  }

  // ürün sil
  async delete(id: number) {

    const deleteObservable: Observable<any> = this.httpClientService.delete<any>({
      controller: "products",
      //queryString: `pageRequest.pageIndex=${index}&pageRequest.pageSize=${size}`
    }, id);

    await firstValueFrom(deleteObservable);
  }
}

