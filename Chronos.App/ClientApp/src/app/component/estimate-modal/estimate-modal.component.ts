import { Component, OnDestroy, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { EstimateTemplate } from 'src/app/models';
import { EstimateTemplateService, RequestsOfWorkEstimatesService } from 'src/app/service';

@Component({
  selector: 'app-estimate-modal',
  templateUrl: './estimate-modal.component.html',
  styleUrls: ['./estimate-modal.component.css']
})
export class EstimateModalComponent implements OnInit {
  private destroy: Subject<void> = new Subject<void>();

  requestOfWorkName = '';
  version = '';
  estimateTemplates: EstimateTemplate[] = [];
  selectedEstimateTemplateValue = 0;
  file: File = null;

  constructor(
    public bsModalRef: BsModalRef,
    private readonly requestOfWorkerEstimatesService: RequestsOfWorkEstimatesService,
    private readonly estimateTemplateService: EstimateTemplateService
  ) { }

  ngOnInit(): void {
    this.initEstimateTemplates();
  }

  onChange(fileList: FileList): void {
    if (fileList.length > 0) {
      this.file = fileList[0];
    } else {
      this.file = null;
    }
  }

  onSave(): void {
    this.requestOfWorkerEstimatesService
      .add(1, this.selectedEstimateTemplateValue, this.version, this.file)
      .pipe(takeUntil(this.destroy))
      .subscribe(() => {
        this.bsModalRef.hide();
        this.bsModalRef.onHide.emit({ success: true });        
      });
  }

  private initEstimateTemplates(): void {
    this.estimateTemplateService
      .getList()
      .pipe(takeUntil(this.destroy))
      .subscribe((result => {
        this.estimateTemplates = result;
      }));
  }

  ngOnDestroy(): void {
    this.destroy.next();
    this.destroy.complete();
  }
}
