import { Variable } from "./variable";

export class TaskRules {
    title = '';
    description = '';
    titleVariables: Variable[] = [];
    tags: string[] = [];
    defaultTags: string[] = [];

    constructor(obj?: Partial<TaskRules>) {
        if (obj)
            Object.assign(this, obj);
    }
}
