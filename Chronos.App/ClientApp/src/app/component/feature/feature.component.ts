import { ChangeDetectorRef, Component, DoCheck, ElementRef, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { BlankFeature, BlankStory, BlankTask, Member } from 'src/app/models';
import { MemberService } from 'src/app/service';
import { BlankFeatureService } from 'src/app/service/blank-feature.service';

@Component({
  selector: 'app-feature',
  templateUrl: './feature.component.html',
  styleUrls: ['./feature.component.css']
})
export class FeatureComponent implements OnInit, OnChanges, DoCheck {
  private destroy: Subject<void> = new Subject<void>();
  private oldScrollHeight = 0;
  private oldScrollWidth = 0;

  @ViewChild('tableContainer') container:ElementRef<HTMLDivElement>;

  isVisibleScroll = false;

  featureId = 0;

  blankFeature: BlankFeature = null;
  members: Member[] = [];

  constructor(
    public bsModalRef: BsModalRef,
    private readonly blankFeatureService: BlankFeatureService,
    private readonly memberService: MemberService,
    private changeDetector: ChangeDetectorRef
  ) { }

  ngDoCheck(): void {
    if (this.container) {
      this.oldScrollHeight = this.container.nativeElement.scrollHeight;
      this.oldScrollWidth = this.container.nativeElement.scrollWidth;
    }
  }

  ngOnInit(): void {
    this.bsModalRef.setClass('modal-large');
    this.initBlankFeature();
    this.initMembers();
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log(changes);
  }

  onStoryisCollapsed(story: BlankStory): void {
    story.isCollapsed = !story.isCollapsed;
    this.checkExpandedScroll();
  }

  onMembersExpanded(event: any): void {
    let element = this.container.nativeElement;

    event.dropup = false;

    this.changeDetector.detectChanges();

    if (element.scrollHeight - this.oldScrollHeight  > 0) {
      event.dropup = true;
    } else {
      event.dropup = false;
    }
  }

  onTagsExpanded(event: any): void {
    let element = this.container.nativeElement;

    event.dropup = false;
    event.dropright = false;

    this.changeDetector.detectChanges();

    if (element.scrollHeight - this.oldScrollHeight - event.changedHeight  > 0) {
      event.dropup = true;
    } else {
      event.dropup = false;
    }

    if (element.scrollWidth - this.oldScrollWidth  > 0) {
      event.dropright = true;
    } else {
      event.dropright = false;
    }
  }

  private checkExpandedScroll(): void {
    this.changeDetector.detectChanges();

    if (this.container.nativeElement.scrollHeight - this.container.nativeElement.offsetHeight > 0) {
      this.isVisibleScroll = true;
    } else {
      this.isVisibleScroll = false;
    }
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
