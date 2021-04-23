export class CheckedItem<T> {
    id:T = null;
    value = '';
    checked = false;

    constructor(obj?: Partial<CheckedItem<T>>) {
        if (obj)
            Object.assign(this, obj);
    }
}