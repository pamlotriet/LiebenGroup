import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ManageProductComponent } from './pages/manage-product/manage-product.component';
import { ManageOrderComponent } from './pages/manage-order/manage-order.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'manage-product',
    component: ManageProductComponent,
  },
  { path: 'manage-order', component: ManageOrderComponent },
];
