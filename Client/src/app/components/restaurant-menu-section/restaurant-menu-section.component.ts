import { Component, OnInit, Input } from '@angular/core';
import { MenuApiServiceService } from 'src/app/services/menuServices/menu-api-service.service';
import { Menu, MenuType, SubMenu } from '../../models/models';

@Component({
  selector: 'app-restaurant-menu-section',
  templateUrl: './restaurant-menu-section.component.html',
  styleUrls: ['./restaurant-menu-section.component.scss']
})
export class RestaurantMenuSectionComponent implements OnInit {
  @Input() restaurantId: number = 0;

  isLoaded: Boolean = false;
  isMenuTypesLoaded: Boolean = false;
  loadedSubMenuId: number = -1;
  menuTypes: MenuType[] | any = [];
  menu: Menu | any;

  constructor(private menuApiService: MenuApiServiceService) { }

  ngOnInit(): void {
    var a = { subMenuId: 0, type: 'Full Menu' };
    this.menuTypes.push(a);
    this.loadMenuTypes();

  }

  loadMenuTypes() {
    if (!this.isMenuTypesLoaded) {
      this.menuApiService.GetMenuTypes(this.restaurantId).subscribe(t => {
        this.menuTypes = this.menuTypes.concat(t);
        this.isMenuTypesLoaded = true;
        this.loadMenu(0);
      })
    }
  }

  loadMenu(subMenuId: number) {
    if ((!this.isLoaded || this.loadedSubMenuId !== subMenuId) && this.isMenuTypesLoaded) {
      this.menuApiService.GetMenuFullData(this.restaurantId, subMenuId).subscribe(m => {
        this.loadedSubMenuId = subMenuId;
        this.menu = m;
        this.isLoaded = true;
      })
    }
  }


  GetDate(dateTime: Date) {
    const _date = new Date(dateTime);
    return `${_date.getDate()} ${_date.toLocaleString('default', { month: 'long' }).toString()}, ${_date.getFullYear()}`
  }
}
