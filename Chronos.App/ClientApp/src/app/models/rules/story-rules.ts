import { Variable } from "./variable";

export class StoryRules {
    title = '';
    description = '';
    acceptanceCriteria = '';
    titleVariables: Variable[] = [];
    tags: string[] = [];
    defaultTags: string[] = [];

    constructor(obj?: Partial<StoryRules>) {
        if (obj)
            Object.assign(this, obj);
    }
}
