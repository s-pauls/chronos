import { User } from "src/app/service";

export class BlankTask {
    parentStoryId: 0 ;
    name = '';
    originalEstimate = 0;
    assigned: User = null;
    activity = '';

    constructor(obj?: Partial<BlankTask>) {
        if (obj)
            Object.assign(this, obj);
    }
}
