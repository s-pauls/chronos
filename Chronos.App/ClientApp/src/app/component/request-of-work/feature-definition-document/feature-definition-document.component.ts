import { Component, OnDestroy, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { FeatureDefinitionDocumentForAdd, Product } from 'src/app/models';
import { RequestOfWorkService } from 'src/app/service';

@Component({
  selector: 'app-feature-definition-document',
  templateUrl: './feature-definition-document.component.html',
  styleUrls: ['./feature-definition-document.component.css']
})
export class FeatureDefinitionDocumentComponent implements OnInit, OnDestroy {
  private destroy: Subject<void> = new Subject<void>();

  featureDefinitionDocument: FeatureDefinitionDocumentForAdd = new FeatureDefinitionDocumentForAdd();
  products: Product[] = [];

  constructor(
    public bsModalRef: BsModalRef,
    private readonly requestOfWorkService: RequestOfWorkService
  ) { }

  ngOnInit(): void {
  }

  onSave(): void {
    this.requestOfWorkService
      .addFeatureDefinitionDocument(this.featureDefinitionDocument)
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
