import { Component, OnInit, Inject, Output } from '@angular/core';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BaseDialog } from '../base/base-dialog';
import { FileUploadOptions } from 'src/app/services/common/file-upload/file-upload.component';
import { DialogService } from 'src/app/services/common/dialog.service';
import { DeleteDialogComponent, DeleteState } from '../delete-dialog/delete-dialog.component';

import { ProductService } from 'src/app/services/product/product.service';
import { List_Product_Image } from 'src/app/shared/contracts/products/list_product_image';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from 'src/app/base/base.component';



declare var $: any


@Component({
  selector: 'app-upload-product-image-dialog',
  templateUrl: './upload-product-image-dialog.component.html',
  styleUrls: ['./upload-product-image-dialog.component.scss']
})


export class UploadProductImageDialogComponent extends BaseDialog<UploadProductImageDialogComponent> implements OnInit {


  constructor(dialogRef: MatDialogRef<UploadProductImageDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: SelectProductImageState | number,
    private productService: ProductService,
    private spinner: NgxSpinnerService,
    private dialogService: DialogService) { super(dialogRef) }


  @Output() options: Partial<FileUploadOptions> = {
    accept: ".png, .jpg, .jpeg, .gif",
    action: "upload",
    controller: "products",
    explanation: "Drag or select pictures...",
    queryString: `id=${this.data}`
  };


  // images referans
  images: List_Product_Image[];


  async ngOnInit() {
    this.spinner.show(SpinnerType.BallSpinClockwiseFadeRotating);
    this.images = await this.productService.listImages(this.data as number,
      () => this.spinner.hide(SpinnerType.BallSpinClockwiseFadeRotating));
  }
  // delete image
  async deleteImage(imageId: number, event: any) {
    this.dialogService.openDialog({
      componentType: DeleteDialogComponent,
      data: DeleteState.Yes,
      afterClosed: async () => {
        this.spinner.show(SpinnerType.BallSpinClockwiseFadeRotating);
        await this.productService.deleteImage(this.data as number, imageId, () => {
          this.spinner.hide(SpinnerType.BallSpinClockwiseFadeRotating);
          var card = $(event.srcElement).parent().parent();
          debugger;
          card.fadeOut(500);
        })
      }
    });
  }

  changeShowcase(imageId: number) {
    /*alert("imageId: " + imageId + "- productId: " + this.data)*/
    this.spinner.show(SpinnerType.BallSpinClockwiseFadeRotating);

    this.productService.changeShowcase(imageId, this.data as number, () => {
      this.spinner.hide(SpinnerType.BallSpinClockwiseFadeRotating);
    })
  }


}


export enum SelectProductImageState {
  Close
}
