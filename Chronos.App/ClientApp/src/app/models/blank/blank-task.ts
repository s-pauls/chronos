import { Member } from "../member/member";

export class BlankTask {
    name = '';
    originalEstimate = 0;
    tags: string[] = null;
    suggestedTags: string[] = null;
    assigned: Member = null;
    activity = '';

    constructor(obj?: Partial<BlankTask>) {
        if (obj)
            Object.assign(this, obj);
    }
}
