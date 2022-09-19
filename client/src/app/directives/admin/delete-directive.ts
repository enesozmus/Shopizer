import { Directive, ElementRef, Renderer2, HostListener, Input, Output, EventEmitter } from '@angular/core';

import { HttpClientService } from 'src/app/services/common/http-client.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from '../../base/base.component';

import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogComponent, DeleteState } from 'src/app/dialogs/delete-dialog/delete-dialog.component';
import { HttpErrorResponse } from '@angular/common/http';
import { DialogService } from 'src/app/services/common/dialog.service';


// JavaScript
declare var $: any;

@Directive({
  selector: '[appDelete]'
})

export class DeleteDirective {

  constructor(private element: ElementRef, private _renderer: Renderer2, private httpClientService: HttpClientService,
    private spinner: NgxSpinnerService, public dialog: MatDialog, private dialogService: DialogService) {
    // icon'lar için i elementi
    const icon = _renderer.createElement("i");
    // class
    icon.setAttribute("class", "fa-regular fa-trash-can fa-xl");
    // style
    icon.setAttribute("style", "cursor: pointer; color: red; margin-left: 12px;");
    // oluştur
    _renderer.appendChild(element.nativeElement, icon);
    // image şeklinde de çalışılabilirdi.
    //img.width = 25;
    //img.height = 25;
  }

  @Input() id: number;
  @Input() controller: string;
  @Output() updatelistwhendeleted: EventEmitter<any> = new EventEmitter();

  // click olunduğunda
  @HostListener("click")
  async onclick() {

    // dialog module
    this.dialogService.openDialog({
      componentType: DeleteDialogComponent,
      data: DeleteState.Yes,
      afterClosed: async () => {
        // spinner show
        this.spinner.show(SpinnerType.BallSpinClockwiseFadeRotating);
        const td: HTMLTableCellElement = this.element.nativeElement;

        // request
        this.httpClientService.delete({
          controller: this.controller
        }, this.id).subscribe(response => {
          $(td.parentElement).fadeOut(900, () => {
            this.updatelistwhendeleted.emit();
          });
        }, (errorResponse: HttpErrorResponse) => {
          this.spinner.hide(SpinnerType.BallSpinClockwiseFadeRotating);
          alert(errorResponse);
        })

      }
    });
    // // analiz
    //console.log(this.element)
    // console.log(td.parentElement) => tr
    // console.log(this.id)
    //$(td.parentElement).fadeOut(2000)
  }
}
