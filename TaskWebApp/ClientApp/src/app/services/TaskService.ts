import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TodoTask } from '../model/TodoTask';



export class TaskService {
  baseUrl: string ;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { this.baseUrl = baseUrl }

  getAllTodoTasks(): Observable<TodoTask[]> {
    return this.http.get<TodoTask[]>(this.baseUrl + 'api/AllTasks');
  }

  getTodoTaskById(taskid: string): Observable<TodoTask> {
    return this.http.get<TodoTask>(this.baseUrl + "api/GetTaskById/" + taskid);
  }

  createTask(task: TodoTask): Observable<TodoTask> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<TodoTask>(this.baseUrl + 'api/InsertTask/',
      task, httpOptions);
  }

  updateTask(task: TodoTask): Observable<TodoTask> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<TodoTask>(this.baseUrl + 'api/UpdateTask', task, httpOptions);
  }
  deleteTask(taskid: string): Observable<string> {
   
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<string>(this.baseUrl + 'api/DeleteTask/'+taskid,
        httpOptions);
  
  }
  changeFieldIsFinshed(taskid: string): Observable<string> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<string>(this.baseUrl + 'api/ChangeStateTask/' + taskid,
      httpOptions);
  }
}
