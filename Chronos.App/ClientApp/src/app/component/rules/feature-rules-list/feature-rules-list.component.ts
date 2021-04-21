import { Component, OnInit } from '@angular/core';
import { ColumnMode } from '@swimlane/ngx-datatable';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { FeatureRules } from 'src/app/models';
import { FeatureRulesService } from 'src/app/service';

@Component({
  selector: 'app-feature-rules-list',
  templateUrl: './feature-rules-list.component.html',
  styleUrls: ['./feature-rules-list.component.css']
})
export class FeatureRulesListComponent implements OnInit {
  private destroy: Subject<void> = new Subject<void>();

  columnMode = ColumnMode;
  featureRulesList: FeatureRules[] = null;

  constructor(private featureRulesService: FeatureRulesService) {
  }

  ngOnInit(): void {
    this.initFeatureRulesList();
  }

  initFeatureRulesList(): void {
    this.featureRulesService.getList()
      .pipe(takeUntil(this.destroy))
      .subscribe(result => {
        this.featureRulesList = result;
      });  
  }

  onDelete(id: number): void {
    this.featureRulesService.delete(id)
      .pipe(takeUntil(this.destroy))
      .subscribe(() => {
        this.featureRulesList = this.featureRulesList.filter((rule) => rule.id !== id);
      });
  }

  ngOnDestroy(): void {
    this.destroy.next();
    this.destroy.complete();
  }
}
