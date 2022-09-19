import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products.component';
import { RouterModule } from '@angular/router';


import { MatSidenavModule } from '@angular/material/sidenav';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import {MatDialogModule} from '@angular/material/dialog';


import { CreateProductComponent } from './create-product/create-product.component';
import { ListProductComponent } from './list-product/list-product.component';

import { FileUploadModule } from 'src/app/services/common/file-upload/file-upload.module';
import { DialogModule } from 'src/app/dialogs/dialog.module';
import { DeleteDirective } from 'src/app/directives/admin/delete-directive';




@NgModule({
  declarations: [
    ProductsComponent,
    CreateProductComponent,
    ListProductComponent,
    DeleteDirective
  ],
  imports: [
    CommonModule,

    RouterModule.forChild([
      { path: "", component: ProductsComponent },
      { path: "create-product", component: CreateProductComponent },
    ]),

    MatGridListModule,
    MatSidenavModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,

    DialogModule,
    FileUploadModule
  ]
})
export class ProductsModule { }
