import { Component, Input } from '@angular/core';
import { NgxFileDropEntry } from 'ngx-file-drop';
import { HttpClientService } from '../http-client.service';
import { HttpErrorResponse, HttpHeaders } from '@angular/common/http';

import { FileUploadDialogComponent, FileUploadDialogState } from 'src/app/dialogs/file-upload-dialog/file-upload-dialog.component';
import { DialogService } from '../dialog.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from 'src/app/base/base.component';


@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})
export class FileUploadComponent {

  constructor(private httpClientService: HttpClientService, private dialogService: DialogService, private spinner: NgxSpinnerService) {
  }

  // Dışarıdan alacağımız parametreler
  @Input() options: Partial<FileUploadOptions>;

  // template'den gelen tür
  public files: NgxFileDropEntry[];

  public selectedFiles(files: NgxFileDropEntry[]) {

    // mapleme
    this.files = files;
    // dosyaları içine atacağımız nesnenin instance'ı
    const fileData: FormData = new FormData();

    // for döngüsü
    for (const file of files) {
      (file.fileEntry as FileSystemFileEntry).file((_file: File) => {
        fileData.append(_file.name, _file, file.relativePath);
      });
    }

    // dialog window
    this.dialogService.openDialog({

      componentType: FileUploadDialogComponent,
      data: FileUploadDialogState.Yes,
      afterClosed: () => {

        // spinner
        this.spinner.show(SpinnerType.BallSpinClockwiseFadeRotating);

        // post request
        this.httpClientService.post({
          controller: this.options.controller,
          action: this.options.action,
          queryString: this.options.queryString,
          headers: new HttpHeaders({ "responseType": "blob" })
        }, fileData).subscribe(data => {
          this.spinner.hide(SpinnerType.BallSpinClockwiseFadeRotating);
          alert("dosyalar başarıyla yüklendi");
        }, (errorResponse: HttpErrorResponse) => {
          this.spinner.hide(SpinnerType.BallSpinClockwiseFadeRotating);
          alert(errorResponse.error)
        });
      }
    })
  }
}

export class FileUploadOptions {
  controller?: string;
  action?: string;
  queryString?: string;
  explanation?: string;
  accept?: string;
  //isAdminPage?: boolean = false;
}