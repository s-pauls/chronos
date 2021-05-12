import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { debounceTime, map, switchMap, takeUntil } from 'rxjs/operators';
import { Member, MemberQuery } from 'src/app/models';
import { MemberService } from 'src/app/service';

@Component({
  selector: 'app-assigment',
  templateUrl: './assigment.component.html',
  styleUrls: ['./assigment.component.css']
})
export class AssigmentComponent implements OnInit {
  private destroy: Subject<void> = new Subject<void>();
  private searchSubject: Subject<void> = new Subject(); 

  @Input() set members(members: Member[]) {
    this.membersList = [...members];
    this.addUnassinged(this.membersList);
    this.filteredMembers = [...this.membersList];
  }
  @Input() member: Member = null;
  @Input() set dropup(value: boolean) {
    this.state.dropup = value;
  };
  
  @Output() memberChange: EventEmitter<Member> = new EventEmitter();
  @Output() expand: EventEmitter<Object> = new EventEmitter();

  @ViewChild('inputDropdown') inputDropdown: ElementRef<HTMLDivElement>;

  state = {
    dropup: false
  };

  dropdownVisible = false;

  searchText: string;
  membersObservable: Observable<Member[]>;

  membersList: Member[] = null;
  filteredMembers: Member[] = null;
  
  constructor(
    private readonly memberService: MemberService
  ) { }

  ngOnInit(): void {
    this.initSearchSubject();
  }

  onKeyup(): void {
    this.searchSubject.next();
  }

  onInputClick(): void {
    this.dropdownVisible = true;
    this.inputDropdown.nativeElement.getElementsByTagName('input')[0].focus();

    this.expand.emit(this.state);
  }

  onFocusout(event: FocusEvent): void {
    if (event.target && !this.inputDropdown.nativeElement.contains(<HTMLElement> event.relatedTarget)) {
    this.dropdownVisible = false;
  }
  }

  onSelectItem(index: number): void {
    this.member = this.filteredMembers[index];
    this.searchText = `${this.member.firstName} ${this.member.lastName}`;
    this.dropdownVisible = false;
    this.filteredMembers = [...this.membersList];
    this.memberChange.emit(this.member);
  }

  initSearchSubject(): void {
    this.searchSubject
    .pipe(debounceTime(200))
    .pipe(switchMap(() => {
      return this.memberService
              .getList(new MemberQuery({
                searchText: this.searchText
              }))
              .pipe(map((data: Member[]) => {
                if (data) {
                  this.addUnassinged(data);
                  return data;
                }
          
                return [];
              }));
    }))
    .pipe(takeUntil(this.destroy))
    .subscribe((result) => {
      this.filteredMembers = result;
      this.expand.emit(this.state);
    });
  }

  private addUnassinged(members: Member[]): void {
    members.unshift(new Member({
      memberUid: '',
      firstName: 'Unassinged'
    }));
  }

  ngOnDestroy(): void {
    this.destroy.next();
    this.destroy.complete();
  }
}
