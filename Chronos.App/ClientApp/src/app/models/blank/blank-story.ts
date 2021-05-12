import { User } from "src/app/service";
import { BlankTask } from "./blank-task";

export class BlankStory {
    storyId = 0;
    name = '';
    tasks: BlankTask[] = null;
    orderNumber = 0;
    assigned: User = null;
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
