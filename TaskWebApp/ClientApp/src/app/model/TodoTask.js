"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var TodoTask = /** @class */ (function () {
    function TodoTask() {
    }
    TodoTask.prototype.clear = function () {
        this.taskid = null;
        this.taskName = this.creatorName = this.description = null;
        this.creationDate = null;
        this.isFinished = false;
    };
    return TodoTask;
}());
exports.TodoTask = TodoTask;
//# sourceMappingURL=TodoTask.js.map