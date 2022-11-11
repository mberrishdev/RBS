import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TableImageModel } from 'src/app/models/models';
import { TableService } from 'src/app/services/tableServices/table.service';

@Component({
  selector: 'app-table-images',
  templateUrl: './table-images.component.html',
  styleUrls: ['./table-images.component.scss']
})
export class TableImagesComponent implements OnInit {
  images: TableImageModel[] = [];
  image: TableImageModel;
  tableId: number = 0;
  displayImages: boolean = false;
  isTableHas360Image: boolean = false;
  imageSrc: string = "https://images.unsplash.com/photo-1596263576925-d90d63691097?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8MzYwfGVufDB8fDB8fA%3D%3D&w=1000&q=80";
  responsiveOptions: any[] = [
    {
      breakpoint: '1024px',
      numVisible: 5
    },
    {
      breakpoint: '768px',
      numVisible: 3
    },
    {
      breakpoint: '560px',
      numVisible: 1
    }
  ];

  constructor(private route: ActivatedRoute, private tableService: TableService) { }

  ngOnInit(): void {
    this.loadTableId();
    this.loadTable360Image(this.tableId);
    if (this.isTableHas360Image)
      this.loadTableImages(this.tableId);
  }

  loadTableId() {
    var id = this.route.snapshot.paramMap.get("tableId");
    console.log(id);

    if (id != null) {
      this.tableId = parseInt(id);
    }
  }

  loadTable360Image(tableId: number) {
    this.images = [];
    this.tableService.GetTable360Image(tableId).subscribe(data => {
      if (data.toString() === '360 image does not exist') {
        this.isTableHas360Image = false;
        return;
      }
      this.isTableHas360Image = true;
      this.image = data;

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
