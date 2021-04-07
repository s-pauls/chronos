import { Component, OnInit } from '@angular/core';
import { FeatureRules } from 'src/app/models';

@Component({
  selector: 'app-feature-rules',
  templateUrl: './feature-rules.component.html',
  styleUrls: ['./feature-rules.component.css']
})
export class FeatureRulesComponent implements OnInit {
  featureRules: FeatureRules = new FeatureRules();

  constructor() { }

  ngOnInit(): void {
    this.initFeatureRules();
  }

  initFeatureRules(): void {
    this.featureRules = <FeatureRules> {
      templateName: "Point Solutions' Template",
      featureTaskRules: {
        title: '[TaskName]',
        description: '',
        titleVariables: [ 
          {
            code: '[CSD/CSP#]',
            description: 'Feature code'
          }, 
          {
            code: '[Product]',
            description: 'applies one of the following value: CDB, ABP'
          },
          {
            code: '[TaskName]',
            description: 'Story name'
          },
          {
            code: '[TaskOrderNumber]',
            description: 'begings from 0'
          }
        ],
        tags: [ '[TaskTag]', '[SomeTag]' ]
      },
      zeroStoryRules: {
        title: '[CSD/CSP#] - [Product]: [StoryName]',
        description: '',
        acceptanceCriteria: '',
        titleVariables: [ 
          {
            code: '[CSD/CSP#]',
            description: 'Feature code'
          }, 
          {
            code: '[Product]',
            description: 'applies one of the following value: CDB, ABP'
          },
          {
            code: '[Area]',
            description: 'OE, CN, Admin Portal, etc. If it is a regression testing US, so provide this info here'
          },
          {
            code: '[StoryName]',
            description: 'Story name'
          },
          {
            code: '[StoryOrderNumber]',
            description: 'begings from 0'
          }
        ],
        tags: [
          '[YearTag]',
          '[ProductTag]'
        ],
        defaultTags: [
          '[NextTag]',
          '[SomeTag]'
        ]
      },
      zeroTaskRules: {
        title: '[TaskName]',
        description: '',
        titleVariables: [ 
          {
            code: '[CSD/CSP#]',
            description: 'Feature code'
          }, 
          {
            code: '[Product]',
            description: 'applies one of the following value: CDB, ABP'
          },
          {
            code: '[StoryId]',
            description: 'Story id'
          },
          {
            code: '[StoryOrderNumber]',
            description: 'begings from 0'
          },
          {
            code: '[TaskName]',
            description: 'Story name'
          },
          {
            code: '[TaskOrderNumber]',
            description: 'begings from 0'
          }
        ],
        tags: [],        
        defaultTags: [
          '[YearTag]',
          '[ProductTag]'
        ]
      },
      storyRules: {
        title: '[CSD/CSP#] - [Product]: [StoryName]',
        description: 
                  "<div>" +
                    "<div>As</div>" +
                    "<div>I Want</div>" +
                    "<div>So that</div>" +
                    "<br/>" +
                    "<div>" +
                        "<b>Additional Information</b>" +
                    "</div>" +
                    "<div>None</div>" +
                    "<br/>" +
                    "<div>" +
                        "<b>Glossary</b>" +
                    "</div>" +
                    "<div>None</div>" +
                  "</div>",
        acceptanceCriteria: 
                  "<div>" +
                    "<div>" +
                        "<b>Assumptions & Limitations & Dependencies </b>" +
                    "</div>" +
                    "<div>None</div>" +
                    "<br/>" +
                    "<div>" +
                        "<b>Acceptance Criteria</b>" +
                    "</div>" +
                    "<br/>" +
                    "<div>" +
                        "<b>Implementation Details</b>" +
                    "</div>" +
                    "<div>None</div>" +
                  "</div>",
        titleVariables: [ 
          {
            code: '[CSD/CSP#]',
            description: 'Feature code'
          }, 
          {
            code: '[Product]',
            description: 'applies one of the following value: CDB, ABP'
          },
          {
            code: '[Area]',
            description: 'OE, CN, Admin Portal, etc. If it is a regression testing US, so provide this info here'
          },
          {
            code: '[StoryName]',
            description: 'Story name'
          },
          {
            code: '[StoryOrderNumber]',
            description: 'begings from 1'
          }
        ],
        tags: [
          '[YearTag]',
          '[ProductTag]'
        ]        
      },
      taskRules: {
        title: '[TaskName]',
        description: '',
        titleVariables: [ 
          {
            code: '[CSD/CSP#]',
            description: 'Feature code'
          }, 
          {
            code: '[Product]',
            description: 'applies one of the following value: CDB, ABP'
          },
          {
            code: '[StoryId]',
            description: 'Story id'
          },
          {
            code: '[StoryOrderNumber]',
            description: 'begings from 0'
          },
          {
            code: '[TaskName]',
            description: 'Story name'
          },
          {
            code: '[TaskOrderNumber]',
            description: 'begings from 0'
          }
        ],
        tags: []
      }
    };    
  }

}
