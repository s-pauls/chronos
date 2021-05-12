export class MemberAssignment {


    constructor(obj?: Partial<MemberAssignment>) {
        if (obj)
            Object.assign(this, obj);
    }
}
