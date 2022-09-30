import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, firstValueFrom } from 'rxjs';
import { IPaginationWithParameters } from 'src/app/shared/contracts/paginations/paginationWithParamaters';
import { Create_Product } from 'src/app/shared/contracts/products/create_product.ts';
import { List_Product_Image } from 'src/app/shared/contracts/products/list_product_image';
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

  // ürüne ait resimleri listele
  async listImages(id: number, successCallBack?: () => void): Promise<List_Product_Image[]> {
    const getObservable: Observable<List_Product_Image[]> = this.httpClientService.get<List_Product_Image[]>({
      action: "getproductimages",
      controller: "products"
    }, id);

    const images: List_Product_Image[] = await firstValueFrom(getObservable);
    successCallBack();
    return images;
  }
  // resim sil
  async deleteImage(id: number, imageId: number, successCallBack?: () => void) {
    const deleteObservable = this.httpClientService.delete({
      action: "deleteproductimage",
      controller: "products",
      queryString: `imageId=${imageId}`
    }, id);
    await firstValueFrom(deleteObservable);
    successCallBack();
  }

  // vitrin resmini değiştir
  async changeShowcase(imageId: number, productId: number, successCallBack?: () => void): Promise<void>{

    const changeShowcaseImageObservable = this.httpClientService.get({
      controller: "products",
      action: "changeshowcaseimage",
      queryString: `imageId=${imageId}&productId=${productId}`
    });

    await firstValueFrom(changeShowcaseImageObservable);
    successCallBack();
  }
  
}
