import { Component, inject, OnInit, signal } from '@angular/core';
import { ProductService } from '../../shared/services/product.service';
import { Product } from '../../shared/models/products.models';
import { TableComponent } from '../../shared/components/table/table.component';
import { Router } from '@angular/router';
import { ButtonComponent } from '../../shared/components/button/button.component';

@Component({
  selector: 'app-products-landing',
  imports: [TableComponent, ButtonComponent],
  templateUrl: './products-landing.component.html',
})
export class ProductsLandingComponent implements OnInit {
  productService = inject(ProductService);
  router = inject(Router);
  products = signal<Product[]>([]);

  columns = [
    { field: 'id', header: 'Id' },
    { field: 'name', header: 'Name' },
    { field: 'price', header: 'Price' },
  ];

  ngOnInit(): void {
    this.productService.getProducts().subscribe({
      next: (data) => this.products.set(data),
      error: (err) => console.error('Error fetching products:', err),
    });
  }

  loadProducts() {
    this.productService.getProducts().subscribe({
      next: (data) => this.products.set(data),
      error: (err) => console.error('Error fetching products:', err),
    });
  }

  onEdit(id: string) {
    this.router.navigate(['manage-product'], {
      queryParams: { productId: id },
    });
  }

  onDelete(id: string) {
    this.productService.deleteProduct(id).subscribe({
      next: () => {
        console.log(`Product with ID ${id} deleted.`);
        this.products.update((products) =>
          products.filter((product) => product.id !== id)
        );
      },
      error: (err) => console.error('Error deleting product:', err),
    });
  }

  navigateToAddProduct() {
    this.router.navigateByUrl('manage-product');
  }
}
