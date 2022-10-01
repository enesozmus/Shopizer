import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { BasketService } from 'src/app/services/basket/basket.service';
import { List_Basket_Item } from 'src/app/shared/contracts/baskets/list_basket_item';
import { Update_Basket_Item } from 'src/app/shared/contracts/baskets/update_basket_item';

declare var $: any;


@Component({
  selector: 'app-baskets',
  templateUrl: './baskets.component.html',
  styleUrls: ['./baskets.component.scss']
})


export class BasketsComponent extends BaseComponent implements OnInit {


  constructor(spinner: NgxSpinnerService, private basketService: BasketService) {
    super(spinner)
  }


  basketItems: List_Basket_Item[];


  async ngOnInit(): Promise<void> {
    this.showSpinner(SpinnerType.BallSpinClockwiseFadeRotating);
    this.basketItems = await this.basketService.get();
    this.hideSpinner(SpinnerType.BallSpinClockwiseFadeRotating);
  }

  // sepetteki ürün adedini güncelle
  async changeQuantity(object: any) {

    this.showSpinner(SpinnerType.BallSpinClockwiseFadeRotating);

    const basketItemId: number = object.target.attributes["id"].value;
    const quantity: number = object.target.value;

    const basketItem: Update_Basket_Item = new Update_Basket_Item();
    basketItem.basketItemId = basketItemId;
    basketItem.quantity = quantity;

    await this.basketService.updateQuantity(basketItem);

    this.hideSpinner(SpinnerType.BallSpinClockwiseFadeRotating);
  }

  // sepetteki ürünü kaldır
  async removeBasketItem(basketItemId: number) {

    //this.showSpinner(SpinnerType.BallSpinClockwiseFadeRotating);

    await this.basketService.remove(basketItemId);

    var a = $("." + basketItemId);
    console.log("problem var");
    $("." + basketItemId).fadeOut(500, () => this.hideSpinner(SpinnerType.BallSpinClockwiseFadeRotating));
  }

}
