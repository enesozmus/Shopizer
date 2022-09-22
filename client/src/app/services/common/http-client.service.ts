import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})


export class HttpClientService {

  // buradaki çalışmamız özünde HttpClient servisinin özelleştirilmesidir.
  // baseUrl app.module.ts'den alınarak string olarak constructor'a eklendi.
  constructor(private httpClient: HttpClient, @Inject("baseUrl") private baseUrl: string) { }


  private url(requestParameter: Partial<RequestParameters>): string {
    return `${requestParameter.baseUrl ? requestParameter.baseUrl : this.baseUrl}/${requestParameter.controller}${requestParameter.action
      ? `/${requestParameter.action}` : ""}`;
  }


  // temel crud işlemlerinin url'ler aracılığıyla karşılanması
  get<T>(requestParameter: Partial<RequestParameters>, id?: number): Observable<T> {

    // baseUrl'in /api/... devamı için
    let url: string = "";

    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint;
    else
      url = `${this.url(requestParameter)}${id ? `/${id}` : ""}${requestParameter.queryString ? `?${requestParameter.queryString}` : ""}`;

    return this.httpClient.get<T>(url, { headers: requestParameter.headers });
  }


  post<T>(requestParameter: Partial<RequestParameters>, body: Partial<T>): Observable<T> {

    let url: string = "";

    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint;
    else
      url = `${this.url(requestParameter)}${requestParameter.queryString ? `?${requestParameter.queryString}` : ""}`

    return this.httpClient.post<T>(url, body, { headers: requestParameter.headers });
  }


  put<T>(requestParameter: Partial<RequestParameters>, body: Partial<T>): Observable<T> {

    let url: string = "";

    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint;
    else
      url = `${this.url(requestParameter)}${requestParameter.queryString ? `?${requestParameter.queryString}` : ""}`;

    return this.httpClient.put<T>(url, body, { headers: requestParameter.headers });
  }


  delete<T>(requestParameter: Partial<RequestParameters>, id: number): Observable<T> {

    let url: string = "";

    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint;
    else
      url = `${this.url(requestParameter)}/${id}${requestParameter.queryString ? `?${requestParameter.queryString}` : ""}`;

    return this.httpClient.delete<T>(url, { headers: requestParameter.headers });
  }
}


export class RequestParameters {
  controller?: string;
  action?: string;
  queryString?: string;

  headers?: HttpHeaders;
  baseUrl?: string;         // istisnai durumları yönetmek | eğer buradaki baseUrl doluysa bu kullanılacak
  fullEndPoint?: string;    // istisnai durumları yönetmek | eğer buradaki fullEndPoint doluysa bu kullanılacak
}
