import { Component, OnInit, Input } from '@angular/core';
import { MenuApiServiceService } from 'src/app/services/menuServices/menu-api-service.service';
import { Menu, MenuType, SubMenu, SubMenuItem } from '../../models/models';

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
  menu: Menu;
  selectedSubMenuItems: SubMenuItem[] = [];
  displayBasket: boolean = false;
  selectedItems: number[] = [];
  responsiveOptions;

  constructor(private menuApiService: MenuApiServiceService) {
    this.responsiveOptions = [
      {
        breakpoint: '1024px',
        numVisible: 3,
        numScroll: 3
      },
      {
        breakpoint: '768px',
        numVisible: 2,
        numScroll: 2
      },
      {
        breakpoint: '560px',
        numVisible: 1,
        numScroll: 1
      }
    ];

  }

  ngOnInit(): void {
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

  showBasket() {
    this.filterSelectedItems();
    this.displayBasket = true;
  }


  removeFromBasket(itemId: number) {
    this.selectedItems

    const index = this.selectedItems.indexOf(itemId);
    if (index > -1) {
      this.selectedItems.splice(index, 1);
    }

    this.filterSelectedItems();
  }

  minusQuantity(itemId: number) {
    this.selectedSubMenuItems;
    for (let i = 0; i < this.selectedSubMenuItems.length; i++) {
      if (this.selectedSubMenuItems[i].id == itemId) {
        this.selectedSubMenuItems[i].quantity -= 1;
        if (this.selectedSubMenuItems[i].quantity == 0) {
          this.removeFromBasket(this.selectedSubMenuItems[i].id);
        };
      }
    }
  }

  plusQuantity(itemId: number) {
    this.selectedSubMenuItems;
    for (let i = 0; i < this.selectedSubMenuItems.length; i++) {
      if (this.selectedSubMenuItems[i].id == itemId)
        this.selectedSubMenuItems[i].quantity += 1;
    }
  }

  private filterSelectedItems() {
    this.selectedSubMenuItems = [];
    this.menu.subMenus.forEach(m => {
      m.items.forEach(k => {
        if (this.selectedItems.some(t => t == k.id)) {
          console.log(k.quantity);

          if (k.quantity == undefined)
            k.quantity = 1;
          this.selectedSubMenuItems.push(k);
        }
      })
    })
  }

  getFullPrice() {
    let price = 0;
    this.selectedSubMenuItems.forEach(x => {
      price += x.price;
    })
    return price;
  }

  GetDate(dateTime: Date) {
    const _date = new Date(dateTime);
    return `${_date.getDate()} ${_date.toLocaleString('default', { month: 'long' }).toString()}, ${_date.getFullYear()}`
  }
}
