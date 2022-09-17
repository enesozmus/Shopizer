import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { List_Product } from 'src/app/shared/contracts/products/list_product';
import { ProductService } from 'src/app/services/product/product.service';
import { MatPaginator } from '@angular/material/paginator';
import { IPaginationWithParameters } from 'src/app/shared/contracts/paginations/paginationWithParamaters';

declare var $: any;

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.scss']
})


export class ListProductComponent extends BaseComponent implements OnInit {

  constructor(private productService: ProductService, spinner: NgxSpinnerService) {
    super(spinner)
  }

  /*** Angular Material */
  displayedColumns: string[] = ['name', 'stock', 'price', 'createdDate', 'lastModifiedDate', 'update', 'delete'];
  dataSource: MatTableDataSource<List_Product> = null;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  /*** Angular Material */

  async getProducts() {

    this.showSpinner(SpinnerType.BallSpinClockwiseFadeRotating);

    const getBigList: IPaginationWithParameters
      = await this.productService.list(this.paginator ? this.paginator.pageIndex : 0, this.paginator ? this.paginator.pageSize : 5, () => this.hideSpinner(SpinnerType.BallSpinClockwiseFadeRotating),
        errorMessage => alert(errorMessage));

    this.dataSource = new MatTableDataSource<List_Product>(getBigList.items);
    this.paginator.length = getBigList.count;
  }

  async pageChanged() {
    await this.getProducts();
  }

  /* delete(id, event) {
    alert(id)
    const icon: HTMLImageElement = event.srcElement;
    $(icon.parentElement.parentElement).fadeOut(2000);
    //console.log(icon.parentElement.parentElement)
  }*/

  async ngOnInit() {
    await this.getProducts();
  }
}
