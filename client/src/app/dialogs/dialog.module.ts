import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploadModule } from '../services/common/file-upload/file-upload.module';

import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component';
import { UploadProductImageDialogComponent } from './upload-product-image-dialog/upload-product-image-dialog.component';

import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';



@NgModule({

  declarations: [
    DeleteDialogComponent,
    UploadProductImageDialogComponent
  ],

  imports: [
    CommonModule,
    FileUploadModule,
    MatDialogModule, MatButtonModule, MatCardModule
  ]
})

export class DialogModule { }
