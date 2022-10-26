import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { RestaruantService } from 'src/app/services/restaurantServices/restaruant.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  searchForm = this.formBuilder.group({
    location:null,
    date:null,
    time:null,
    personCount:null,
  });

  timeNow: string = new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
  today: string = new Date().toLocaleDateString("es-CL");
  minDate: Date = new Date()
  constructor(private formBuilder: FormBuilder, private restaurantService : RestaruantService,
    private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    // Process checkout data here
    this.router.navigate(
      ['/list'],
      { queryParams: { location: this.searchForm.value.location, date: this.searchForm.value.date,time :this.searchForm.value.time,personCount:this.searchForm.value.personCount } }
    );

    console.warn('Your order has been submitted', this.searchForm.value);
    this.restaurantService.Search().subscribe(data=>{

      console.log(data);

    });

  }

}
