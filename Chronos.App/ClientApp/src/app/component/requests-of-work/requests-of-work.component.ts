import { Component, OnDestroy, OnInit } from '@angular/core';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { forkJoin, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { CheckedItem, CommentModel, Estimate, Filter, RequestOfWork, RequestOfWorkFilter } from 'src/app/models';
import { AuthService, ProductService, RequestOfWorkService, RequestsOfWorkCommentsService, RequestsOfWorkEstimatesService, User } from 'src/app/service';

@Component({
  selector: 'app-requests-of-work',
  templateUrl: './requests-of-work.component.html',
  styleUrls: ['./requests-of-work.component.css']
})
export class RequestsOfWorkComponent implements OnInit, OnDestroy {
  private destroy: Subject<void> = new Subject<void>();
  private user: User = null;

  columnMode = ColumnMode;
  selectionType = SelectionType;
  requestsOfWork: RequestOfWork[] = null;
  selectedRequestOfWork: RequestOfWork[] = [];
  estimates: Estimate[] = null;
  comments: CommentModel[] = null;
  
  requestOfWorkFilters = null;

  constructor(
    private authService: AuthService,
    private productService: ProductService,
    private requestOfWorkService: RequestOfWorkService,
    private requestsOfWorkEstimatesService: RequestsOfWorkEstimatesService,    
    private requestsOfWorkCommentsService: RequestsOfWorkCommentsService,
  ) {
    this.authService
      .user()
      .pipe(takeUntil(this.destroy))
      .subscribe((user) => this.user = user);
  }

  ngOnInit(): void {
    this.initRequestsOfWork();
  }

  onSelectionChanged(filters: Filter[]): void {
    let requestsOfWorkFilter = new RequestOfWorkFilter();

    filters.forEach(filter => {
      if (filter.name === 'Product') {
        this.fillArrayByCheckedItems(filter, requestsOfWorkFilter.productIds);
      }

      if (filter.name === 'Status') {
        this.fillArrayByCheckedItems(filter, requestsOfWorkFilter.statusIds);
      }

      if (filter.name === 'Type') {
        this.fillArrayByCheckedItems(filter, requestsOfWorkFilter.typeIds);
      }
    });

    this.requestOfWorkService
      .getList(requestsOfWorkFilter)
      .pipe(takeUntil(this.destroy))
      .subscribe((requestsOfWork) => {
        this.requestsOfWork = [];
        this.selectedRequestOfWork = [];

        if(requestsOfWork.length > 0){
          this.selectedRequestOfWork = [requestsOfWork[0]];
          this.initEstimatesAndComments();
          this.requestsOfWork = requestsOfWork;
        }
      });
  }

  onSelect(): void {    
    this.initEstimatesAndComments();
  }

  onEnter(textarea: HTMLTextAreaElement): void {
    if (textarea.value) {
      this.comments.unshift({
        commentId: 0,
        userName: this.user.displayName,
        dateTime: new Date(),
        message: textarea.value,
        isCustom: true
      });
  
      textarea.value = null;
      textarea.blur();
    }
  }

  getInitials(userName: string): string {
    return userName.split(' ').reduce((previousValue, currentValue) => previousValue + currentValue[0], '');
  }

  private initRequestsOfWork(): void {
    forkJoin([
      this.productService.getProducts(),
      this.requestOfWorkService.getStatuses(),
      this.requestOfWorkService.getTypes()
    ])
    .subscribe((results) => {
      let filters: Filter[] = [];

      filters.push(new Filter ({
        name: 'Product',
        checkedItems: results[0].map((product) => {
          return new CheckedItem({
            id: product.id,
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

    this.requestOfWorkService
      .getList()
      .pipe(takeUntil(this.destroy))
      .subscribe((requestsOfWork) => {
        this.selectedRequestOfWork = [requestsOfWork[0]];
        this.initEstimatesAndComments();
        this.requestsOfWork = requestsOfWork;
      });
  }

  private initEstimatesAndComments(): void {
    this.estimates = null;
    this.comments = null;

    let selectedRequestOfWork = this.selectedRequestOfWork[0];

    this.requestsOfWorkEstimatesService
      .getList(selectedRequestOfWork.requestOfWorkId)
      .pipe(takeUntil(this.destroy))
      .subscribe((result) => {
        this.estimates = result;
      });

    this.requestsOfWorkCommentsService
      .getList(selectedRequestOfWork.requestOfWorkId)
      .pipe(takeUntil(this.destroy))
      .subscribe((result) => {
        this.comments = result;
      });
  }

  private fillArrayByCheckedItems<T>(filter: Filter,  array: number[]): void {
    if (filter.anyChecked) {      
      filter.checkedItems.forEach(checkedItem => {
        if (checkedItem.checked) {
          array.push(checkedItem.id);
        }
      });
    }
  }

  ngOnDestroy(): void {
    this.destroy.next();
    this.destroy.complete();
  }
}
