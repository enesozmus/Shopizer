import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module';
import { RouterModule } from '@angular/router';

import { ProductsComponent } from './products.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { ProductDetailsComponent } from './product-details/product-details.component';

import { ProductsListComponent } from './products-list/products-list.component';
import { ProductsListTwoComponent } from './products-list-two/products-list-two.component';
import { BasketsComponent } from '../baskets/baskets.component';


@NgModule({
  declarations: [
    ProductsComponent,
    ProductItemComponent,
    ProductDetailsComponent,
    ProductsListComponent,
    ProductsListTwoComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: ProductsComponent },
      { path: 'products/:id', component: ProductDetailsComponent },
    ]),

    SharedModule
  ]
})
export class ProductsModule { }
