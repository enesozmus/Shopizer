import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FileService } from 'src/app/services/common/file.service';
import { ProductService } from 'src/app/services/product/product.service';
import { BaseStorageUrl } from 'src/app/shared/contracts/base_storage_url';
import { List_Product } from 'src/app/shared/contracts/products/list_product';
import { List_Product_Image } from 'src/app/shared/contracts/products/list_product_image';


@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss']
})

export class ProductsListComponent implements OnInit {


  constructor(private productService: ProductService, private activatedRoute: ActivatedRoute
    , private fileService: FileService) { }


  images: List_Product_Image[];
  products: List_Product[];
  currentPageNo: number;
  totalProductCount: number;
  totalPageCount: number;
  pageSize: number = 32;
  pageList: number[] = [];
  baseStorageUrl: BaseStorageUrl;


  async ngOnInit() {


    this.baseStorageUrl = await this.fileService.getBaseStorageUrl();
    console.log(this.baseStorageUrl);

    this.activatedRoute.params.subscribe(async params => {

      this.currentPageNo = parseInt(params["pageNo"] ?? 1);

      const data = await this.productService.list(this.currentPageNo - 1, this.pageSize, () => {

      }, errorMessage => {
        alert(errorMessage);
      });
      //debugger;
      this.products = data.items;
      this.totalProductCount = data.count;
      this.totalPageCount = data.pages;
      this.pageList = [];

      if (this.totalPageCount >= 7) {
        if (this.currentPageNo - 3 <= 0) {
          for (let i = 1; i <= 7; i++) {
            this.pageList.push(i);
          }
        }
        else if (this.currentPageNo + 3 >= this.totalPageCount) {
          for (let i = this.totalPageCount - 6; i <= this.totalPageCount; i++) {
            this.pageList.push(i);
          }
        }
        else {
          for (let i = this.currentPageNo - 3; i <= this.currentPageNo + 3; i++) {
            this.pageList.push(i);
          }
        }
      }
      else {
        for (let i = 1; i <= this.totalPageCount; i++) {
          this.pageList.push(i);
        }
      }
    });

  }
}
