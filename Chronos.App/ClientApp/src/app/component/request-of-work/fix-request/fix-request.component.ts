import { Component, OnDestroy, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { FixRequestForAdd, Product } from 'src/app/models';
import { RequestOfWorkService } from 'src/app/service';

@Component({
  selector: 'app-fix-request',
  templateUrl: './fix-request.component.html',
  styleUrls: ['./fix-request.component.css']
})
export class FixRequestComponent implements OnInit, OnDestroy {
  private destroy: Subject<void> = new Subject<void>();

  fixRequest: FixRequestForAdd = new FixRequestForAdd();
  products: Product[] = [];

  constructor(
    public bsModalRef: BsModalRef,
    private readonly requestOfWorkService: RequestOfWorkService
  ) { }

  ngOnInit(): void {
  }

  onSave(): void {
    this.requestOfWorkService
      .addFixRequest(this.fixRequest)
      .pipe(takeUntil(this.destroy))
      .subscribe(() => {
        this.bsModalRef.hide();
        this.bsModalRef.onHide.emit({ success: true });        
      });
  }

  ngOnDestroy(): void {
    this.destroy.next();
    this.destroy.complete();
  }
}
