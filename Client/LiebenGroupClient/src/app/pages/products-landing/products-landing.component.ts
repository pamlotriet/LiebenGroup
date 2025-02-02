import { Component, inject, OnInit, signal } from '@angular/core';
import { ProductService } from '../../shared/services/product.service';
import { Product } from '../../shared/models/products.models';
import { TableComponent } from '../../shared/components/table/table.component';

@Component({
  selector: 'app-products-landing',
  imports: [TableComponent],
  templateUrl: './products-landing.component.html',
})
export class ProductsLandingComponent implements OnInit {
  productService = inject(ProductService);

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
}
