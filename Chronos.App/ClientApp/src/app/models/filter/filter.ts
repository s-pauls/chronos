import { CheckedItem } from "./checked-item";

export class Filter<T> {
    name = '';
    checkedItems: CheckedItem<T>[] = []
    anyChecked = false;

    constructor(obj?: Partial<Filter<T>>) {
        if (obj)
            Object.assign(this, obj);
    }
}