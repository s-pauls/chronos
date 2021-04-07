import { StoryRules } from "./story-rules";
import { TaskRules } from "./task-rules";

export class FeatureRules {
    templateName = '';
    zeroStoryRules: StoryRules = null;
    zeroTaskRules: TaskRules = null;
    featureTaskRules: TaskRules = null;
    storyRules: StoryRules = null;
    taskRules: TaskRules = null;

    constructor(obj?: Partial<FeatureRules>) {
        if (obj)
            Object.assign(this, obj);
    }
}
