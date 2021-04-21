export class CommentModel {
    commentId = 0;
    userName = '';
    message = '';
    dateTime: Date = null;
    isCustom = false;

    constructor(obj?: Partial<CommentModel>) {
        if (obj)
            Object.assign(this, obj);
    }
}
