import { ChangeDetectorRef, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ColumnMode, } from '@swimlane/ngx-datatable';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { BlankFeature, BlankStory, Member } from 'src/app/models';
import { MemberService } from 'src/app/service';
import { BlankFeatureService } from 'src/app/service/blank-feature.service';

@Component({
  selector: 'app-feature',
  templateUrl: './feature.component.html',
  styleUrls: ['./feature.component.css']
})
export class FeatureComponent implements OnInit {
  private destroy: Subject<void> = new Subject<void>();
  private oldScrollHeight = 0;

  @ViewChild('tableContainer') container:ElementRef<HTMLDivElement>;

  isVisibleScroll = false;

  featureId = 0; 
  columnMode = ColumnMode;

  blankFeature: BlankFeature = null;
  members: Member[] = [];

  constructor(
    public bsModalRef: BsModalRef,
    private readonly blankFeatureService: BlankFeatureService,
    private readonly memberService: MemberService,
    private changeDetector: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.initBlankFeature();
    this.initMembers();
  }

  onStoryisCollapsed(story: BlankStory): void {
    story.isCollapsed = !story.isCollapsed;
    this.checkExpandedScroll();
  }

  onMembersExpanded(event: any): void {
    let element = this.container.nativeElement;

    if (this.oldScrollHeight === 0) {
      this.oldScrollHeight = element.scrollHeight;
    }

    event.dropup = false;

    this.changeDetector.detectChanges();

    if (element.scrollHeight - this.oldScrollHeight  > 0) {
      event.dropup = true;
    } else {
      event.dropup = false;
    }
  }

  private checkExpandedScroll(): void {
    this.changeDetector.detectChanges();
    let element = this.container.nativeElement;

    if (element.scrollHeight - element.offsetHeight > 0) {
      this.isVisibleScroll = true;
    } else {
      this.isVisibleScroll = false;
    }

    this.oldScrollHeight = element.scrollHeight;
  }

  private initBlankFeature() {
    this.blankFeatureService
      .get(this.featureId)
      .pipe(takeUntil(this.destroy))
      .subscribe((result) => {
        this.blankFeature = new BlankFeature(result);
      });
  }

  private initMembers() {
    this.memberService
      .getList()               
      .pipe(takeUntil(this.destroy))
      .subscribe(result => {
        this.members = result;
      });
  }

  ngOnDestroy(): void {
    this.destroy.next();
    this.destroy.complete();
  }
}
