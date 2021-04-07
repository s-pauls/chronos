import { Component, Input, OnInit } from '@angular/core';
import { TaskRules } from 'src/app/models';

@Component({
  selector: 'app-task-rules',
  templateUrl: './task-rules.component.html',
  styleUrls: ['./task-rules.component.css']
})
export class TaskRulesComponent implements OnInit {
  @Input() taskRules: TaskRules = new TaskRules();
  @Input() title = '';

  constructor() { }

  ngOnInit(): void {
  }

}
