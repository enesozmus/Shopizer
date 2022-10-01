import { Injectable } from '@angular/core';
import { HttpClientService } from '../common/http-client.service';
import { firstValueFrom, Observable } from 'rxjs';
import { List_Basket_Item } from 'src/app/shared/contracts/baskets/list_basket_item';
import { Create_Basket_Item } from 'src/app/shared/contracts/baskets/create_basket_item';
import { Update_Basket_Item } from 'src/app/shared/contracts/baskets/update_basket_item';


@Injectable({
    providedIn: 'root'
})


export class BasketService {

    constructor(private httpClientService: HttpClientService) { }

    // sepeti getir
    async get(): Promise<List_Basket_Item[]> {
        const observable: Observable<List_Basket_Item[]> = this.httpClientService.get({
            controller: "baskets",
        });

        return await firstValueFrom(observable);
    }

    // sepete ürün ekle
    async add(basketItem: Create_Basket_Item): Promise<void> {
        const observable: Observable<any> = this.httpClientService.post({
            controller: "baskets"
        }, basketItem);

        await firstValueFrom(observable);
    }

    // sepetteki ürün adedini güncelle
    async updateQuantity(basketItem: Update_Basket_Item): Promise<void> {
        const observable: Observable<any> = this.httpClientService.put({
            controller: "baskets"
        }, basketItem)

        await firstValueFrom(observable);
    }

    // sepetteki ürünü kaldır
    async remove(basketItemId: number) {
        const observable: Observable<any> = this.httpClientService.delete({
            controller: "baskets"
        }, basketItemId);

        await firstValueFrom(observable);
    }
}