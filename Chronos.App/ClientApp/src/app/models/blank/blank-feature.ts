import { BlankStory } from "./blank-story";
import { BlankTask } from "./blank-task";

export class BlankFeature {
    name = "";
    featureId = 0;
    tasks: BlankTask[] = null;
    zeroStory: BlankStory = null;
    stories: BlankStory[] = null;

    constructor(obj?: Partial<BlankFeature>) {
        if (obj) {
            Object.assign(this, obj);
        }
            
        
        if (obj.tasks) {
            let tasks:BlankTask[] = []; 

            obj.tasks.forEach(task => {
                tasks.push(new BlankTask(task));
            });

            this.tasks = tasks;
        }

        if (obj.zeroStory) {
            this.zeroStory = new BlankStory(obj.zeroStory);
        }

        if (obj.stories) {
            let stories:BlankStory[] = [];

            obj.stories.forEach(story => {
                stories.push(new BlankStory(story));
            });

            this.stories = stories;
        }
    }
}
