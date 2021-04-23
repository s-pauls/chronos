import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Product, StatementOfWorkForAdd } from 'src/app/models';
import { RequestOfWorkService } from 'src/app/service';

@Component({
  selector: 'app-statement-of-work',
  templateUrl: './statement-of-work.component.html',
  styleUrls: ['./statement-of-work.component.css']
})
export class StatementOfWorkComponent implements OnInit {
  private destroy: Subject<void> = new Subject<void>();

  statementOfWork: StatementOfWorkForAdd = new StatementOfWorkForAdd();
  products: Product[] = [];

  constructor(
    public bsModalRef: BsModalRef,
    private readonly requestOfWorkService: RequestOfWorkService
  ) { }

  ngOnInit(): void {
  }

  onSave(): void {
    this.requestOfWorkService
      .addStatementOfWork(this.statementOfWork)
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
