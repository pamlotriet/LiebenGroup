import { Component } from '@angular/core';
import { Tab } from '../../shared/models/tabs.models';
import { TabsComponent } from '../../shared/components/tabs/tabs.component';
import { ProductsLandingComponent } from '../products-landing/products-landing.component';
import { OrdersLandingComponent } from '../orders-landing/orders-landing.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [TabsComponent],
  templateUrl: './home.component.html',
})
export class HomeComponent {
  tabs: Tab[] = [
    { value: 0, title: 'Products', component: ProductsLandingComponent },
    { value: 1, title: 'Orders', component: OrdersLandingComponent },
  ];
}
