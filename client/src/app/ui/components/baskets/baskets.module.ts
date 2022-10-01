import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketsComponent } from './baskets.component';


@NgModule({
  declarations: [
    BasketsComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    BasketsComponent
  ]
})

export class BasketsModule { }
