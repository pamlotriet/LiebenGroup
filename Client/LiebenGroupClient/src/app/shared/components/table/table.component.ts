import { Component, inject, input, output } from '@angular/core';
import { TableModule } from 'primeng/table';
import { ProductService } from '../../services/product.service';
@Component({
  selector: 'app-table',
  standalone: true,
  imports: [TableModule],
  templateUrl: './table.component.html',
})
export class TableComponent {
  columns = input<any[]>([]);
  items = input<any[]>([]);
  productService = inject(ProductService);
  actionEventEdit = output<string>();
  actionEventDelete = output<string>();

  editItemAction(id: string) {
    this.actionEventEdit.emit(id);
  }

  deleteItemAction(id: string) {
    this.actionEventDelete.emit(id);
  }
}
