import { Component, OnInit } from '@angular/core';
import { Language } from './components/models/models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'RBS.Front.Angular';
  userName: string | any;
  name: string | any;
  surName: string | any;
  imageAddress: string | any;
  languages: Language[] | any;

  constructor() { }
  ngOnInit() {
    this.loadUserInfo();
  }

  onMenuClick($event: any) {
  }

  loadUserInfo() {
    const getUserName = localStorage.getItem('userName');
    this.userName = getUserName ? getUserName : '';
    const getName = localStorage.getItem('name');
    this.name = getName ? getName : '';
    const getSurName = localStorage.getItem('surName');
    this.surName = getSurName ? getSurName : '';
    this.imageAddress = "https://i.ibb.co/jJYm14r/1648196784996.jpg";
  }
}
