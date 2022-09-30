import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products.component';
import { RouterModule } from '@angular/router';
import { ProductItemComponent } from './product-item/product-item.component';

import { SharedModule } from 'src/app/shared/shared.module';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { ProductsListTwoComponent } from './products-list-two/products-list-two.component';


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
