import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component';
import { FileUploadDialogComponent } from './file-upload-dialog/file-upload-dialog.component';

import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';


@NgModule({

  declarations: [
    DeleteDialogComponent,
    FileUploadDialogComponent
  ],

  imports: [
    CommonModule,
    MatDialogModule, MatButtonModule, MatCardModule
  ]
})

export class DialogModule { }
