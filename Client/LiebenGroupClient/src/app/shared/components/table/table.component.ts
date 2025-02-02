import { Component, input, output } from '@angular/core';
import { TableModule } from 'primeng/table';
@Component({
  selector: 'app-table',
  standalone: true,
  imports: [TableModule],
  templateUrl: './table.component.html',
})
export class TableComponent {
  columns = input<any[]>([]);
  items = input<any[]>([]);
  actionEventEdit = output<void>();
  actionEventDelete = output<void>();

  editItemAction() {
    this.actionEventEdit.emit();
  }

  deleteItemAction() {
    this.actionEventDelete.emit();
  }
}
