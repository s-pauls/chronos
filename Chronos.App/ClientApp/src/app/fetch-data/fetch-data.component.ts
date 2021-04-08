import { Component, OnDestroy } from '@angular/core';
import { ProductService } from '../service';
import { Product } from '../models/Product';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { ColumnMode } from '@swimlane/ngx-datatable';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnDestroy {
  private destroy: Subject<void> = new Subject<void>();

  columnMode = ColumnMode;

  products: Product[] = null;
  pageLimit = 5;
  columns = [
    {
      prop: 'id',
      name: 'Id'
    },
    {
      prop: 'name',
      name: 'Name'
    }
  ];

  constructor(private productService: ProductService) {
    productService.getProducts()
      .pipe(takeUntil(this.destroy))
      .subscribe(result => {
        this.products = result;
      });
  }

  ngOnDestroy(): void {
    this.destroy.next();
    this.destroy.complete();
  }
}
