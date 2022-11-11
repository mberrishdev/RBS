import {
  Component,
  OnInit,
  QueryList,
  ViewChildren,
  Renderer2,
} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TableImageModel, TableModel } from 'src/app/models/models';
import { TableService } from 'src/app/services/tableServices/table.service';

// import * as PAN from 'panolens';

@Component({
  selector: 'app-restaurant-tables',
  templateUrl: './restaurant-tables.component.html',
  styleUrls: ['./restaurant-tables.component.scss']
})
export class RestaurantTablesComponent implements OnInit {
  tables: TableModel[] = [];
  restaurantId: number = 0;
  selectedTableId: number = 0;
  constructor(private router: Router, private route: ActivatedRoute, private tableService: TableService) { }


  ngOnInit() {
    this.loadRestaurantId();
    this.loadTables(this.restaurantId);
  }

  click2(id: any) {
    this.selectedTableId = 1;
    this.router.navigate(
      ['tables/' + this.selectedTableId + '/image'],
    );

    // this.loadTableImages(id)
  }

  loadRestaurantId() {
    var id = this.route.snapshot.paramMap.get("restaurantId");
    if (id != null) {
      this.restaurantId = parseInt(id);
    }
  }

  loadTables(restaurantId: number) {
    this.tableService.GetTableByRestaurantId(restaurantId).subscribe(data => {
      this.tables = data;
    });
  }
}
