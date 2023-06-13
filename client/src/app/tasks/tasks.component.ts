import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { TasksService } from '../tasks.service';
import { TaskElement } from '../interfaces/TaskElement';
@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  displayedColumns: string[] = ['subject', 'UserId','IsCompleted'];
  dataSource: any;
constructor(private service: TasksService) {}

  ngOnInit(){    
    this.service.getAllTasks().subscribe((data)=>{
      console.log(data)
      this.dataSource = new MatTableDataSource<TaskElement>(data as TaskElement[]);
    })
  }
}
