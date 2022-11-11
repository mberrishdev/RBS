import {
  Component,
  OnInit,
  QueryList,
  ViewChildren,
  Renderer2,
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TableImageModel, TableModel } from 'src/app/models/models';
import { TableService } from 'src/app/services/tableServices/table.service';

@Component({
  selector: 'app-restaurant-tables',
  templateUrl: './restaurant-tables.component.html',
  styleUrls: ['./restaurant-tables.component.scss']
})
export class RestaurantTablesComponent implements OnInit {
  tables: TableModel[] = [];
  images: TableImageModel[] = [];
  restaurantId: number = 0;
  displayImages: boolean = false;

  filas = [
    { y: 250, x: [154.8, 175.2, 195.5, 0, 0, 0] },
    { y: 281.9, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 313.9, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 345.9, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 377.8, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 427.8, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 459.8, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 492.1, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 543.6, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 575.3, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 627.1, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 679.5, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 711.4, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 743.3, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 775.2, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 807.1, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 839, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 870.9, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 902.8, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 934.7, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 966.3, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 998.5, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 1030.4, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 1062.3, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 1094.2, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
    { y: 1126.1, x: [154.8, 175.2, 195.5, 245.1, 265.5, 285.8] },
  ];
  letras = ['A', 'B', 'C', 'D', 'E', 'F'];
  status = this.filas.map((x) => [
    'free',
    'free',
    'free',
    'free',
    'free',
    'free',
  ]);
  selected: string[];
  selectedTableId: number = 0;
  constructor(private route: ActivatedRoute, private tableService: TableService) { }


  ngOnInit() {
    this.loadRestaurantId();
    this.loadTables(this.restaurantId);

    const booked = ['1A', '2D', '5D', '7A', '15F', '26B'];
    booked.forEach((x) => {
      this.status[+x.slice(0, -1) - 1][
        this.letras.findIndex((l) => l == x.slice(-1))
      ] = 'booked';
    });
  }

  click2(id: any) {
    this.selectedTableId = id;
    this.router.navigate(
      ['restaurant/' + this.restaurantId + '/tables/' + this.selectedTableId + '/image'],
    );

  seats() {
    const seats: any = [];
    this.status.forEach((x, i) => {
      x.forEach((y, j) => {
        if (y == 'selected') seats.push(i + 1 + this.letras[j]);
      });
    });
    return seats;
  }

  loadRestaurantId() {
    var id = this.route.snapshot.paramMap.get("id");
    if (id != null) {
      this.restaurantId = parseInt(id);
    }
  }

  loadTables(restaurantId: number) {
    this.tableService.GetTableByRestaurantId(restaurantId).subscribe(data => {
      this.tables = data;
    });
  }

  loadTableImages(tableId: number) {
    this.images = [];
    this.tableService.GetTableImages(tableId).subscribe(data => {
      this.images = data;
      if (this.images.length > 0)
        this.displayImages = true;
    });
  }
}
