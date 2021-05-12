import { MemberRole, MemberStatus } from "src/app/enums";

export class MemberQuery {
    searchText = '';
    memberStatusId: MemberStatus[] = null;
    memberRoleId: MemberRole[] = null;
    teamUid: string[] = null;
    projectUid: string[] = null;

    constructor(obj?: Partial<MemberQuery>) {
        if (obj)
            Object.assign(this, obj);
    }
}
