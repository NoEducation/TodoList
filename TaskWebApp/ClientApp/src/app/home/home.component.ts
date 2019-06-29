
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';  
import { TaskService } from '../services/TaskService'
import { TodoTask } from '../model/TodoTask';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  //taskForm: any;
  tasks: TodoTask[];

  constructor( private taskservice: TaskService) { }
  ngOnInit() {
    this.loadAllTodoTasks();
  }
  loadAllTodoTasks() {
    this.taskservice.getAllTodoTasks().subscribe(res => this.tasks = res)
  }
 
  deleteTask(taskid: string) {
    this.taskservice.deleteTask(taskid).subscribe(() => {
      this.loadAllTodoTasks();
    })
  }
  changeFiledIsFinshed(taskid: string) {
    this.taskservice.changeFieldIsFinshed(taskid).subscribe(() =>
      this.loadAllTodoTasks())
  }

}
