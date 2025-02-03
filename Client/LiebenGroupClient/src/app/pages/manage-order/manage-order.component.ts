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
  orderForm!: FormGroup;
  products = signal<Product[]>([]);

  ngOnInit(): void {
    this.createForm();
    this.loadProducts();
  }

  createForm() {
    this.orderForm = this.formBuilder.group({
      dateCreated: new FormControl(
        new Date().toISOString(),
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
    debugger;
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

    console.log(this.orderForm.value);
  }

  addOrder() {
    console.log(this.orderForm.value);
    this.orderService.createOrder(this.orderForm.value).subscribe();
  }
}
