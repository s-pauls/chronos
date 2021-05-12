import { Component, OnDestroy, OnInit, TemplateRef } from '@angular/core';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { forkJoin, Subject } from 'rxjs';
import { switchMap, takeUntil } from 'rxjs/operators';
import { CheckedItem, CommentModel, Estimate, Filter, Product, RequestOfWork, RequestOfWorkFilter } from 'src/app/models';
import { ProductService, RequestOfWorkService, RequestsOfWorkCommentsService, RequestsOfWorkEstimatesService } from 'src/app/service';
import { FeatureComponent } from '../../feature/feature.component';
import { EstimateComponent } from '../estimate/estimate.component';
import { FeatureDefinitionDocumentComponent } from '../feature-definition-document/feature-definition-document.component';
import { FixRequestComponent } from '../fix-request/fix-request.component';
import { StatementOfWorkComponent } from '../statement-of-work/statement-of-work.component';

@Component({
  selector: 'app-requests-of-work',
  templateUrl: './requests-of-work.component.html',
  styleUrls: ['./requests-of-work.component.css']
})
export class RequestsOfWorkComponent implements OnInit, OnDestroy {
  private destroy: Subject<void> = new Subject<void>();
  private bsModalRef: BsModalRef = null;
  private estimatesSubject: Subject<void> = new Subject();  
  private commentsSubject: Subject<void> = new Subject();  

  columnMode = ColumnMode;
  selectionType = SelectionType;
  requestsOfWork: RequestOfWork[] = null;
  selectedRequestOfWork: RequestOfWork[] = [];
  estimates: Estimate[] = null;
  comments: CommentModel[] = null;
  products: Product[] = null;
  requestOfWorkFilter: RequestOfWorkFilter = null;
  requestOfWorkFilters: Filter<string | number>[] = null;

  constructor(
    private productService: ProductService,
    private requestOfWorkService: RequestOfWorkService,
    private requestsOfWorkEstimatesService: RequestsOfWorkEstimatesService,    
    private requestsOfWorkCommentsService: RequestsOfWorkCommentsService,
    private modalService: BsModalService
  ) { }

  ngOnInit(): void {
    this.initEstimatesSubject();
    this.initCommentsSubject();

    this.initRequestsOfWork();
  }

  onAddFeatureDefinitionDocument(): void {
    let initialState = {
      products: this.products
    };

    this.showModal(FeatureDefinitionDocumentComponent, () => this.loadRequestsOfWork(), initialState);
  }

  onAddStatementOfWorkt(): void {
    let initialState = {
      products: this.products
    };

    this.showModal(StatementOfWorkComponent, () => this.loadRequestsOfWork(), initialState);
  }

  onAddFixRequest(): void {
    let initialState = {
      products: this.products
    };

    this.showModal(FixRequestComponent, () => this.loadRequestsOfWork(), initialState);
  }

  onSelectionChanged(filters: Filter<string | number>[]): void {
    this.requestOfWorkFilter = new RequestOfWorkFilter();

    filters.forEach(filter => {
      if (filter.name === 'Product') {
        this.fillArrayByCheckedItems(filter, this.requestOfWorkFilter.productIds);
      }

      if (filter.name === 'Status') {
        this.fillArrayByCheckedItems(filter, this.requestOfWorkFilter.statusIds);
      }

      if (filter.name === 'Type') {
        this.fillArrayByCheckedItems(filter, this.requestOfWorkFilter.typeIds);
      }
    });

    this.loadRequestsOfWork();
  }

  onSelect(): void {
    this.loadEstimatesAndComments();
  }

  onEnter(textarea: HTMLTextAreaElement): void {
    if (textarea.value) {
      var message = textarea.value;
      textarea.value = null;     
      textarea.blur();
      this.getSelectedRequestOfWorkId();

      this.requestsOfWorkCommentsService
        .add(this.selectedRequestOfWork[0].requestOfWorkId, message)
        .pipe(takeUntil(this.destroy))
        .subscribe(() => {
          this.loadComments();
        });
    }
  }

  onAddEstimate(): void {
    let initialState = {
      requestOfWorkId: this.selectedRequestOfWork[0].requestOfWorkId,
      requestOfWorkName: this.selectedRequestOfWork[0].name
    };

    this.showModal(EstimateComponent, () => this.loadEstimatesAndComments(), initialState);
  }

  onGenerateFeature(id: number): void {
    let initialState = {
      featureId: id
    };

    this.showModal(FeatureComponent, () => { }, initialState);
  }

  //todo
  getDate(date: string): Date {
    return new Date(date);
  }

  //todo
  getDayOfWeek(date: string): string {
    return new Date(date).toLocaleString('en-us', {  weekday: 'long' });
  }

  getInitials(userName: string): string {
    if (!userName)
      return '';

    return userName.split(' ').reduce((previousValue, currentValue) => previousValue + currentValue[0], '');
  }

  getRowClass(row): string {
    return 'border-bottom';
  }

  private showModal<T = Object>(component: { new (...args: any[]): T; }, onSuccess: () => void, initialState?: Partial<T>): void {    
    let config = {
      animated: true,
      class: 'message-box modal-dialog-centered',
      initialState: initialState  
    };

    this.bsModalRef = this.modalService.show(component, config);
    this.bsModalRef.onHide
      .pipe(takeUntil(this.destroy))
      .subscribe((result) => {
        if (result && result.success) {
          onSuccess();
        }
      });
  }

  private initRequestsOfWork(): void {
    forkJoin([
      this.productService.getProducts(),
      this.requestOfWorkService.getStatuses(),
      this.requestOfWorkService.getTypes()
    ])
    .pipe(takeUntil(this.destroy))
    .subscribe((results) => {
      let filters: Filter<string | number>[] = [];

      this.products = results[0];

      filters.push(new Filter ({
        name: 'Product',
        checkedItems: results[0].map((product) => {
          return new CheckedItem({
            id: product.uid,
            value: product.name
          });
        })
      }));

      filters.push(new Filter ({
        name: 'Status',
        checkedItems: results[1].map((status) => {
          return new CheckedItem({
            id: status.id,
            value: status.name
          });
        })
      }));

      filters.push(new Filter ({
        name: 'Type',
        checkedItems: results[2].map((type) => {
          return new CheckedItem({
            id: type.id,
            value: type.name
          });
        })
      }));
      
      this.requestOfWorkFilters = filters;
    });

    this.loadRequestsOfWork();
  }

  private loadRequestsOfWork(): void {
    this.requestOfWorkService
      .getList(this.requestOfWorkFilter)
      .pipe(takeUntil(this.destroy))
      .subscribe((requestsOfWork) => {
        let selectedRequestOfWorkId = this.getSelectedRequestOfWorkId();
        this.requestsOfWork = requestsOfWork;

        if (this.requestsOfWork.length > 0) {
          let index = requestsOfWork.findIndex(x => x.requestOfWorkId === selectedRequestOfWorkId);
          index = index === -1 ? 0 : index;
          
          this.selectedRequestOfWork = [requestsOfWork[index]];

          this.loadEstimatesAndComments();
        } else {
          this.estimates = [];
          this.comments = [];
        }
      });
  }

  private loadEstimatesAndComments(): void {
    this.loadEstimates()
    this.loadComments();
  }

  private loadEstimates(): void {
    this.estimates = null;
    this.estimatesSubject.next();
  }

  private loadComments(): void {
    this.comments = null;
    this.commentsSubject.next();
  }

  private initEstimatesSubject(): void {
    this.estimatesSubject
    .pipe(switchMap(() => {
      return this.requestsOfWorkEstimatesService
              .getList(this.getSelectedRequestOfWorkId());
    }))
    .pipe(takeUntil(this.destroy))
    .subscribe((result) => {
      this.estimates = result;
    });
  }

  private initCommentsSubject(): void {
    this.commentsSubject
      .pipe(switchMap(() => {
        return this.requestsOfWorkCommentsService
                .getList(this.getSelectedRequestOfWorkId());
      }))
      .pipe(takeUntil(this.destroy))
      .subscribe((result) => {
        this.comments = result;
      });
  }

  private fillArrayByCheckedItems<T>(filter: Filter<T>,  array: T[]): void {
    if (filter.anyChecked) {      
      filter.checkedItems.forEach(checkedItem => {
        if (checkedItem.checked) {
          array.push(checkedItem.id);
        }
      });
    }
  }

  private getSelectedRequestOfWorkId(): number {
    return this.selectedRequestOfWork.length > 0 ? this.selectedRequestOfWork[0].requestOfWorkId : -1;
  }

  ngOnDestroy(): void {
    this.destroy.next();
    this.destroy.complete();
  }
}
