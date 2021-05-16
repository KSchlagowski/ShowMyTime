import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-time',
  templateUrl: './time.component.html',
  styleUrls: ['./time.component.scss']
})
export class TimeComponent implements OnInit {

  time: any;
  errorMsg: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getTime();
  }

  getTime(){
    this.http.get("http://localhost:5000/api/time")
      .subscribe(response => {
        this.time = response;
    }, error => {
      this.errorMsg = error;
    })
  }
}
