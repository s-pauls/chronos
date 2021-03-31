import { Component, OnDestroy } from '@angular/core';
import { ProductService } from '../service';
import { Product } from '../models/Product';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnDestroy {
  private destroy: Subject<void> = new Subject<void>();

  public products: Product[];

  constructor(private productService: ProductService) {
    productService.getProducts()
      .pipe(takeUntil(this.destroy))
      .subscribe(result => {
        this.products = result;
      }, 
      error => console.error(error));
  }

  ngOnDestroy(): void {
    this.destroy.next();
    this.destroy.complete();
  }
}
