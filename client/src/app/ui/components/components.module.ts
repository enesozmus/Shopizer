import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsModule } from './products/products.module';
import { HomeModule } from './home/home.module';
import { RegisterModule } from './register/register.module';
import { BasketsModule } from './baskets/baskets.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HomeModule,
    ProductsModule,
    RegisterModule,
    BasketsModule
    //LoginModule
  ],
  exports: [
    BasketsModule
  ]
})
export class ComponentsModule { }
