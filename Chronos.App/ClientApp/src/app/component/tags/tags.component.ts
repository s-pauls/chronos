import { ChangeDetectorRef, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-tags',
  templateUrl: './tags.component.html',
  styleUrls: ['./tags.component.css']
})
export class TagsComponent implements OnInit {
  @Input() tags: string[] = [];
  @Input() defaultTags: string[] = [];
  @Input() dropup = false;

  @ViewChild('input', {static: false}) inputElement: ElementRef;

  addedDefaultTags: string[] = [];
  showInput = false;
  inputValue = '';

  constructor(private detector: ChangeDetectorRef) { }

  ngOnInit(): void {
  }

  onAddTag(): void {
    this.showInput = !this.showInput;
    this.detector.detectChanges();
    this.inputElement.nativeElement.focus();
  }

  onEnter(): void {
    this.addTag(this.inputValue);
  }

  onRemoveTag(button: HTMLButtonElement): void {
    let tag = button.innerText;

    this.tags.splice(this.tags.indexOf(tag), 1);

    let addedDefaultTagIndex = this.addedDefaultTags.indexOf(tag);

    if (addedDefaultTagIndex >= 0){
      this.addedDefaultTags.splice(addedDefaultTagIndex, 1);
      this.defaultTags.push(tag);
    }
  }

  onSelection(span: HTMLSpanElement): void {
    let tag = span.innerText;    

    this.addTag(tag);

    this.defaultTags.splice(this.defaultTags.indexOf(tag), 1);
    this.addedDefaultTags.push(tag);
  }

  private addTag(tag: string): void{    
    if (tag) {
      this.tags.push(tag);
    }
    
    this.showInput = false;
    this.inputValue = '';    
  }
}
