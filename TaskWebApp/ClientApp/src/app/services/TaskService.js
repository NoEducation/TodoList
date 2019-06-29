"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var TaskService = /** @class */ (function () {
    function TaskService(http) {
        this.http = http;
        this.url = 'http://localhost:44390/Api';
    }
    TaskService.prototype.getAllTodoTasks = function () {
        return this.http.get(this.url + '/AllTodoTasks');
    };
    return TaskService;
}());
exports.TaskService = TaskService;
//# sourceMappingURL=TaskService.js.map