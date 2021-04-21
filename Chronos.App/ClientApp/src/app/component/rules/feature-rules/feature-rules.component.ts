import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { FeatureRules } from 'src/app/models';
import { FeatureRulesService } from 'src/app/service';


@Component({
  selector: 'app-feature-rules',
  templateUrl: './feature-rules.component.html',
  styleUrls: ['./feature-rules.component.css']
})
export class FeatureRulesComponent implements OnInit, OnDestroy {
  private destroy: Subject<void> = new Subject<void>();
  private id = 0;

  featureRules: FeatureRules = null;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private featureRulesService: FeatureRulesService
    ) {
    this.id = Number.parseInt(this.route.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
    if (this.id){
      this.initFeatureRules();
    } else {
      this.initDefaultFeatureRules();
    }
  }

  initFeatureRules(): void {
    this.featureRulesService.getById(this.id)
      .pipe(takeUntil(this.destroy))
      .subscribe(result => {
        this.featureRules = result;
      });
  }

  initDefaultFeatureRules(): void {
    this.featureRulesService.getDefault()
      .pipe(takeUntil(this.destroy))
      .subscribe(result => {
        this.featureRules = result;
      });
  }

  onSave(): void {
    if (this.id) {
      this.featureRulesService.update(this.id, this.featureRules)
        .pipe(takeUntil(this.destroy))
        .subscribe(() => {
          this.router.navigate(['/feature-rules-list']);
        });
    } else {
      this.featureRulesService.add(this.featureRules)
        .pipe(takeUntil(this.destroy))
        .subscribe(() => {
          this.router.navigate(['/feature-rules-list']);
        });
    }    
  }

  ngOnDestroy(): void {
    this.destroy.next();
    this.destroy.complete();
  }
}
