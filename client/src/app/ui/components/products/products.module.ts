import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products.component';
import { RouterModule } from '@angular/router';
import { ProductItemComponent } from './product-item/product-item.component';

import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [
    ProductsComponent,
    ProductItemComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([{path: "", component: ProductsComponent }]),
    
    SharedModule
  ]
})
export class ProductsModule { }
