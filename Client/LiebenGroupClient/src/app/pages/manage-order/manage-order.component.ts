import { CommonModule } from '@angular/common';
import { Component, inject, OnInit, signal } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { InputComponent } from '../../shared/components/input/input.component';
import { DropdownComponent } from '../../shared/components/dropdown/dropdown.component';
import { Product } from '../../shared/models/products.models';
import { ProductService } from '../../shared/services/product.service';
import { OrderService } from '../../shared/services/order.service';
import { ButtonComponent } from '../../shared/components/button/button.component';
import { ActivatedRoute, Router } from '@angular/router';
import { Order } from '../../shared/models/orders.models';

@Component({
  selector: 'app-manage-order',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule,
    InputComponent,
    DropdownComponent,
    ButtonComponent,
  ],
  templateUrl: './manage-order.component.html',
})
export class ManageOrderComponent implements OnInit {
  private formBuilder = inject(FormBuilder);
  private productService = inject(ProductService);
  private orderService = inject(OrderService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  orderId: string = '';
  orderForm!: FormGroup;
  order!: Order;
  products = signal<Product[]>([]);

  ngOnInit(): void {
    this.createForm();
    this.loadProducts();

    this.route.queryParams.subscribe((params) => {
      this.orderId = params['orderId'];
      if (this.orderId) {
        this.getOrder(this.orderId);
      }
    });
  }

  getOrder(id: string) {
    this.orderService.getOrderById(id).subscribe((order) => {
      this.order = order;
      this.orderForm.patchValue({
        id: order.id,
        OrderDate: order.orderDate?.split('T')[0],
      });

      const itemsArray = this.getItems();
      itemsArray.clear();

      order.items.forEach((item) => {
        itemsArray.push(
          this.formBuilder.group({
            productId: new FormControl(item.productId, Validators.required),
            productName: new FormControl(item.productName, Validators.required),
            unitPrice: new FormControl(item.unitPrice, [
              Validators.required,
              Validators.min(0.01),
            ]),
            quantity: new FormControl(item.quantity, [
              Validators.required,
              Validators.min(1),
            ]),
          })
        );
      });
    });
  }

  createForm() {
    this.orderForm = this.formBuilder.group({
      id: new FormControl(''),
      OrderDate: new FormControl(
        new Date().toISOString().split('T')[0],
        Validators.required
      ),
      items: this.formBuilder.array([]),
    });

    this.addItem();
  }

  addItem() {
    this.getItems().push(
      this.formBuilder.group({
        productId: new FormControl('', Validators.required),
        productName: new FormControl('', Validators.required),
        unitPrice: new FormControl(0, [
          Validators.required,
          Validators.min(0.01),
        ]),
        quantity: new FormControl(1, [Validators.required, Validators.min(1)]),
      })
    );
  }

  removeItem(index: number) {
    this.getItems().removeAt(index);
  }

  getItems(): FormArray {
    return this.orderForm.get('items') as FormArray;
  }

  loadProducts() {
    this.productService.getProducts().subscribe({
      next: (data) => this.products.set(data),
      error: (err) => console.error('Error fetching products:', err),
    });
  }

  onProductSelect(event: any, index: number) {
    const selectedProductId = event;
    const selectedProduct = this.products().find(
      (p) => p.id === selectedProductId
    );

    if (!selectedProduct) return;

    const itemsArray = this.getItems();

    itemsArray.at(index)?.patchValue({
      unitPrice: selectedProduct.price,
      productName: selectedProduct.name,
    });
  }

  addOrder() {
    const orderData = {
      ...this.orderForm.value,
      OrderDate: new Date(this.orderForm.value.OrderDate).toISOString(),
    };

    this.orderService
      .createOrder(orderData)
      .subscribe(() => this.router.navigateByUrl(''));
  }

  updateOrder() {
    const orderData = {
      ...this.orderForm.value,
      OrderDate: new Date(this.orderForm.value.OrderDate).toISOString(),
    };

    this.orderService
      .updateOrder(orderData)
      .subscribe(() => this.router.navigateByUrl(''));
  }
}
