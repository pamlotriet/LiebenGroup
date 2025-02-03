import { Component, inject, OnInit, signal } from '@angular/core';
import { ButtonComponent } from '../../shared/components/button/button.component';
import { TableComponent } from '../../shared/components/table/table.component';
import { OrderService } from '../../shared/services/order.service';
import { Order } from '../../shared/models/orders.models';
import { Router } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-orders-landing',
  standalone: true,
  imports: [ButtonComponent, TableComponent, ReactiveFormsModule],
  templateUrl: './orders-landing.component.html',
})
export class OrdersLandingComponent implements OnInit {
  orderService = inject(OrderService);
  router = inject(Router);
  orders = signal<Order[]>([]);

  columns = [
    { field: 'id', header: 'Order ID' },
    { field: 'orderDate', header: 'Order Date' },
    { field: 'totalAmount', header: 'Total Amount' },
    { field: 'itemsDisplay', header: 'Products' },
  ];

  ngOnInit(): void {
    this.loadOrders();
  }

  loadOrders() {
    this.orderService.getOrders().subscribe({
      next: (data) =>
        this.orders.set(
          data.map((order) => ({
            ...order,
            itemsDisplay: order.items
              .map(
                (item) =>
                  `${item.productName} (${item.quantity} x $${item.unitPrice})`
              )
              .join(', '),
          }))
        ),
      error: (err) => console.error('Error fetching orders:', err),
    });
  }

  onEdit(id: string) {
    this.router.navigate(['manage-order'], {
      queryParams: { orderId: id },
    });
  }

  onDelete(id: string) {
    this.orderService.deleteOrder(id).subscribe({
      next: () => {
        this.orders.update((orders) =>
          orders.filter((order) => order.id !== id)
        );
      },
      error: (err) => console.error('Error deleting product:', err),
    });
  }

  navigateToAddOrder() {
    this.router.navigateByUrl('manage-order');
  }
}
