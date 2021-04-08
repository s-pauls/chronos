import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { FeatureRules } from 'src/app/models';
import { FeatureRulesService } from '../../service/feature-rules.service';

@Component({
  selector: 'app-feature-rules',
  templateUrl: './feature-rules.component.html',
  styleUrls: ['./feature-rules.component.css']
})
export class FeatureRulesComponent implements OnInit, OnDestroy {
  private destroy: Subject<void> = new Subject<void>();

  featureRules: FeatureRules = null;

  constructor(private featureRulesService: FeatureRulesService) {
  }

  ngOnInit(): void {
    this.initFeatureRules();
  }

  initFeatureRules(): void {
    this.featureRulesService.getDefault()
    .pipe(takeUntil(this.destroy))
    .subscribe(result => {
      this.featureRules = result;
    });
  }

  ngOnDestroy(): void {
    this.destroy.next();
    this.destroy.complete();
  }
}
