import { Member } from "../member/member";
import { BlankTask } from "./blank-task";

export class BlankStory {
    storyId = 0;
    name = '';
    tasks: BlankTask[] = null;
    orderNumber = 0;
    assigned: Member = null;
    tags: string[] = null;
    suggestedTags: string[] = null;
    isCollapsed = true;

    constructor(obj?: Partial<BlankStory>) {
        if (obj)
            Object.assign(this, obj);

        if (obj.tasks) {
            let tasks:BlankTask[] = []; 

            obj.tasks.forEach(task => {
                tasks.push(new BlankTask(task));
            });

            this.tasks = tasks;
        }
    }
}
