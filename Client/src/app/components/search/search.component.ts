import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  date: Date;
  time: Date;
  timeNow: string = new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
  personCount: number;
  location: string;
  today: string = new Date().toLocaleDateString("es-CL");
  minDate: Date = new Date()
  constructor() { }

  ngOnInit(): void {
  }

}
