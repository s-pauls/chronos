import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Filter } from 'src/app/models';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent implements OnInit {

  @Input() filterItems: Filter[] = [];

  @Output() selectionChanged = new EventEmitter<Filter[]>();

  constructor() { }

  ngOnInit(): void {
  }

  onCheck(filterItem: any, checkedItem:any): void {
    checkedItem.checked = !checkedItem.checked;
    filterItem.anyChecked = filterItem.checkedItems.some(currentValue => currentValue.checked);
    this.selectionChanged.emit(this.filterItems);
  }

  onClear(filterItem: any): void {
    filterItem.checkedItems.forEach(item => item.checked = false);
    filterItem.anyChecked = false;
    this.selectionChanged.emit(this.filterItems);
  }
}
