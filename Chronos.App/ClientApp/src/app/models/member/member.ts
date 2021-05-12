import { MemberStatus } from "src/app/enums";

export class Member {
    memberUid = '';
    memberStatus: MemberStatus;
    firstName = '';
    lastName = '';
    coherentEmail = '';
    skypeId = '';
    isCSI = false;
    wexEmail = '';
    wexAccountName = '';
    wexAccountImageUrl = '';
    teamUid = '';
    teamName = '';

    constructor(obj?: Partial<Member>) {
        if (obj)
            Object.assign(this, obj);
    }
}
