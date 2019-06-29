
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { TaskService } from '../services/TaskService'
import { TodoTask } from '../model/TodoTask';
import { Router, ActivatedRoute } from '@angular/router';

@Component({

  selector: 'app-home',
  templateUrl: './productEditor.component.html',
})
export class ProductEditorComponent  {
  editing: boolean = false;
  submitted: boolean = false;
  model: TodoTask = new TodoTask();
  dataSend: boolean = false;
  constructor(private taskService: TaskService, private router: Router, private activeRoute: ActivatedRoute) {
    this.editing = activeRoute.snapshot.params["mode"] == "edit";
    if (this.editing) {
      taskService.getTodoTaskById(activeRoute.snapshot.params["id"]).subscribe(task => {
        this.model.taskName = task.taskName;
        this.model.creatorName = task.creatorName;
        this.model.description = task.description;
        this.model.isFinished = task.isFinished;
        this.model.taskid = task.taskid;
        this.model.creationDate = task.creationDate;
      });

    }

  }
  save(form: NgForm) {
    this.submitted = true;
    if (form.valid) {
      if (this.editing) {
        this.taskService.updateTask(this.model).subscribe(() => { this.dataSend = true; this.submitted = false; this.model.clear(); });
      }
      else {
        this.taskService.createTask(this.model).subscribe(() => { this.dataSend = true; this.submitted = false; this.model.clear(); });
      }
    }
  }
  

}
