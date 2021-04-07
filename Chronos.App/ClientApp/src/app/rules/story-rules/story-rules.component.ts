import { Component, Input, OnInit } from '@angular/core';
import { StoryRules } from 'src/app/models';

@Component({
  selector: 'app-story-rules',
  templateUrl: './story-rules.component.html',
  styleUrls: ['./story-rules.component.css']
})
export class StoryRulesComponent implements OnInit {
  @Input() storyRules: StoryRules = new StoryRules();
  @Input() title = '';

  constructor() { }

  ngOnInit(): void {
  }

}
