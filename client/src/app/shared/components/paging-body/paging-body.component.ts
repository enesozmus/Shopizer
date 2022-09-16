import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-paging-body',
  templateUrl: './paging-body.component.html',
  styleUrls: ['./paging-body.component.scss']
})
export class PagingBodyComponent implements OnInit {

  @Input() totalCount: number;
  @Input() pageIndex: number;
  @Input() pageSize: number;
  @Output() pageChanged = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }

  onPagerChange(event: any) {
    this.pageChanged.emit(event.page);
  }

}
