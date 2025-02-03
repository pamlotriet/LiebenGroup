import { Component, inject, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../shared/services/product.service';
import { Product } from '../../shared/models/products.models';
import { InputComponent } from '../../shared/components/input/input.component';
import { ButtonComponent } from '../../shared/components/button/button.component';

@Component({
  selector: 'app-manage-product',
  standalone: true,
  imports: [ReactiveFormsModule, InputComponent, ButtonComponent],
  templateUrl: './manage-product.component.html',
})
export class ManageProductComponent implements OnInit {
  private route = inject(ActivatedRoute);
  private formBuilder = inject(FormBuilder);
  private productService = inject(ProductService);
  private router = inject(Router);
  productForm!: FormGroup;
  productId: string = '';
  product!: Product;

  ngOnInit(): void {
    this.createForm();
    this.route.queryParams.subscribe((params) => {
      this.productId = params['productId'];
      if (this.productId) {
        this.getProduct(this.productId);
      }
    });
  }

  getProduct(id: string) {
    this.productService.getProductById(id).subscribe((response) => {
      this.product = response;
      if (this.product) {
        this.createForm(this.product.name, this.product.price);
      }
    });
  }

  createForm(productName?: string, productPrice?: number) {
    this.productForm = this.formBuilder.group({
      Name: new FormControl(productName ?? 'Product Name', [
        Validators.required,
        Validators.minLength(2),
      ]),
      Price: new FormControl(productPrice ?? 0, [
        Validators.required,
        Validators.min(0.01),
      ]),
    });
  }

  addProduct() {
    this.productService
      .createProduct(this.productForm.value)
      .subscribe(() => this.navigateHome());
  }

  updateProduct() {
    if (!this.productForm.valid) return;

    const updatedProduct = {
      id: this.productId,
      name: this.productForm.controls['Name'].value,
      price: this.productForm.controls['Price'].value,
    };

    this.productService.updateProduct(updatedProduct).subscribe({
      next: () => {
        this.navigateHome();
      },
      error: (err) => console.error('Error updating product:', err),
    });
  }

  navigateHome() {
    this.router.navigateByUrl('');
  }
}
