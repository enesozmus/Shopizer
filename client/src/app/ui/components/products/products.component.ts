import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  constructor(private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.spinner.show("spinnerSquare")

    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide("spinnerSquare");
    }, 1000);
  }

}
