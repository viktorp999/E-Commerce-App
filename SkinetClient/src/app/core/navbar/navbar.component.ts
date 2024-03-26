import { Component } from '@angular/core';
import { BasketService } from '../../basket/basket.service';
import { BasketItem } from '../../shared/models/basketItem';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent {
  constructor(public basketService: BasketService) {}

  getCount(items: BasketItem[]) {
    return items.reduce((sum, item) => sum + item.quantity, 0);
  }
}
