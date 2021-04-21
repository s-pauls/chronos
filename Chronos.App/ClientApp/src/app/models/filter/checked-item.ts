export class CheckedItem {
    id = 0;
    value = '';
    checked = false;

    constructor(obj?: Partial<CheckedItem>) {
        if (obj)
            Object.assign(this, obj);
    }
}