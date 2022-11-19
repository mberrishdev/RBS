import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { MenuApiServiceService } from 'src/app/services/menuServices/menu-api-service.service';
import { Menu, MenuType, SubMenu, SubMenuItem } from '../../models/models';

@Component({
  selector: 'app-restaurant-menu-section',
  templateUrl: './restaurant-menu-section.component.html',
  styleUrls: ['./restaurant-menu-section.component.scss']
})
export class RestaurantMenuSectionComponent implements OnInit {
  @Output() menuChoosed = new EventEmitter<SubMenuItem[]>();
  @Input() restaurantId: number = 0;
  @Input() showAddInBasket: Boolean = false;

  isLoaded: Boolean = false;
  isMenuTypesLoaded: Boolean = false;
  loadedSubMenuId: number = -1;
  menuTypes: MenuType[] | any = [];
  menu: Menu;
  basketItems: SubMenuItem[] = [];
  displayBasket: boolean = false;
  responsiveOptions;
  fullPrice: number = 0;


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
    this.displayBasket = true;
    this.calculateFullPrice();
  }

  AddInBasket(itemId: number) {
    this.menu.subMenus.forEach(m => {
      m.items.forEach(k => {
        if (k.id == itemId) {
          if (k.quantity == undefined) {
            k.quantity = 1;
            this.basketItems.push(k);
          }
          else {
            this.plusQuantity(itemId);
          }
        }
      })
    })

    this.calculateFullPrice();
    this.menuChoosed.emit(this.basketItems);
  }

  removeFromBasket(itemId: number) {
    let itemIndex = -1;
    for (let i = 0; i < this.basketItems.length; i++) {
      if (this.basketItems[i].id == itemId)
        itemIndex = i;
    }
    if (itemIndex > -1) {
      this.basketItems.splice(itemIndex, 1);
    }

    this.calculateFullPrice();
    this.menuChoosed.emit(this.basketItems);
  }

  minusQuantity(itemId: number) {
    for (let i = 0; i < this.basketItems.length; i++) {
      if (this.basketItems[i].id == itemId) {
        this.basketItems[i].quantity -= 1;
        if (this.basketItems[i].quantity == 0) {
          this.removeFromBasket(this.basketItems[i].id);
        };
      }
    }
    this.calculateFullPrice();
    this.menuChoosed.emit(this.basketItems);
  }

  plusQuantity(itemId: number) {
    for (let i = 0; i < this.basketItems.length; i++) {
      if (this.basketItems[i].id == itemId)
        this.basketItems[i].quantity += 1;
    }

    this.calculateFullPrice();
    this.menuChoosed.emit(this.basketItems);
  }

  calculateFullPrice() {
    let price = 0;
    this.basketItems.forEach(x => {
      price += x.price * x.quantity;
    })

    this.fullPrice = price;
  }

  GetDate(dateTime: Date) {
    const _date = new Date(dateTime);
    return `${_date.getDate()} ${_date.toLocaleString('default', { month: 'long' }).toString()}, ${_date.getFullYear()}`
  }
}
