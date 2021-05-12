import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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

  @Input() set dropup(value: boolean) {
    this.state.dropup = value;
  };
  
  @Output() selectionMember: EventEmitter<Member> = new EventEmitter();

  @Output() expandedListChanged: EventEmitter<Object> = new EventEmitter();

  state = {
    dropup: false
  };

  dropdownVisible = false;

  selectedMember: Member = null;
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

  onFocus(): void {
    this.dropdownVisible = true;
    this.expandedListChanged.emit(this.state);
  }

  onBlure(): void {
    this.dropdownVisible = false;
  }

  onSelectItem(index: number): void {
    this.selectedMember = this.filteredMembers[index];
    this.searchText = `${this.selectedMember.firstName} ${this.selectedMember.lastName}`;
    this.dropdownVisible = false;
    this.filteredMembers = [...this.membersList];
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
      this.expandedListChanged.emit(this.state);
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
