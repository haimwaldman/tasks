import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class TasksService {
  baseUrl = "https://localhost:44313/api/tasks";
  constructor(private http:HttpClient) { }
  getAllTasks() {
    return this.http.get(this.baseUrl);
  }
  createTask(task: any){
    return this.http.post(this.baseUrl, task);
  }
  checkTask(id:any){
    return this.http.put(this.baseUrl, id);
  }
}
