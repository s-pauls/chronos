import { ChangeDetectorRef, Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';

@Component({
  selector: 'app-tags',
  templateUrl: './tags.component.html',
  styleUrls: ['./tags.component.css']
})
export class TagsComponent implements OnInit {
  @Input() tags: string[] = [];
  @Input() set suggestedTags(tags: string[]) {
    if (tags) {
      this.suggestedTagsList = [...tags];
    }
  }
  @Input() dropup = false;
  @Input() fontSize = '0.875';

  @Output() expand: EventEmitter<Object> = new EventEmitter();

  @ViewChild('mainContainer', {static: false}) mainContainer: ElementRef<HTMLElement>;
  @ViewChild('container', {static: false}) container: ElementRef<HTMLElement>;

  state = {
    dropup: false,
    dropright: false,
    changedHeight: 0
  };

  suggestedTagsList: string[] = [];
  filteredTags: string[] = [];
  addedSuggestedTags: string[] = [];
  showInput = false;
  inputValue = '';

  constructor(private detector: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.suggestedTagsList = this.suggestedTagsList ?? [];
    this.tags = this.tags ?? [];
  }

  onKeyup(): void {
    let regex = new RegExp(this.inputValue, 'i');
    this.filteredTags = this.suggestedTagsList.filter(x => x.match(regex));
  }

  onAddTag(): void {
    this.filteredTags = [...this.suggestedTagsList];
    this.showInput = !this.showInput;

    this.recalculateHeigth();
    
    this.container.nativeElement.getElementsByTagName('input')[0].focus();

    if (this.suggestedTagsList.length > 0) {
      this.expand.emit(this.state);
    }
  }

  onEnter(): void {
    this.addTag(this.inputValue, true);
    this.recalculateHeigth();
    this.expand.emit(this.state);
  }

  onRemoveTag(tag: string): void {
    this.tags.splice(this.tags.indexOf(tag), 1);

    let addedSuggestedTagIndex = this.addedSuggestedTags.indexOf(tag);

    if (addedSuggestedTagIndex >= 0){
      this.addedSuggestedTags.splice(addedSuggestedTagIndex, 1);
      this.suggestedTagsList.push(tag);
    }
  }
  
  onFocusout(event: FocusEvent): void {
    if (event.target && !this.container.nativeElement.contains(<HTMLElement> event.relatedTarget)) {
      this.addTag(this.inputValue);
    }
  }

  onSelectItem(index: number): void {
    let tag = this.suggestedTagsList[index];

    this.addTag(tag);

    this.addedSuggestedTags.push(tag);
    this.suggestedTagsList.splice(index, 1);
  }

  private recalculateHeigth(): void {
    let oldHeight = this.mainContainer.nativeElement.clientHeight;

    this.detector.detectChanges();

    this.state.changedHeight = this.mainContainer.nativeElement.clientHeight - oldHeight;
  }

  private addTag(tag: string, showInput: boolean = false): void{    
    if (tag) {
      this.tags.push(tag);
    }
    
    this.showInput = showInput;
    this.inputValue = '';   
  }
}
