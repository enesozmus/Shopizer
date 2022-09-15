import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { List_Product } from 'src/app/contracts/products/list_product';
import { ProductService } from 'src/app/services/product/product.service';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.scss']
})


export class ListProductComponent extends BaseComponent implements OnInit {

  
  constructor(spinner: NgxSpinnerService, private productService: ProductService) {
    super(spinner)
  }


  displayedColumns: string[] = ['name', 'stock', 'price', 'createdDate', 'lastModifiedDate'];
  dataSource: MatTableDataSource<List_Product> = null;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  async ngOnInit() {
    await this.getProducts();
  }

  async getProducts() {

    this.showSpinner(SpinnerType.BallSpinClockwiseFadeRotating);

    const allProducts: List_Product[] = await this.productService.list(() => this.hideSpinner(SpinnerType.BallSpinClockwiseFadeRotating),
      errorMessage => alert(errorMessage));

    this.dataSource = new MatTableDataSource<List_Product>(allProducts);
    this.dataSource.paginator = this.paginator;
  }
}
