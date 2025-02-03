import { Component, input, output } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { SelectModule } from 'primeng/select';
@Component({
  selector: 'app-dropdown',
  standalone: true,
  imports: [SelectModule, ReactiveFormsModule],
  templateUrl: './dropdown.component.html',
})
export class DropdownComponent {
  options = input<any[]>([]);
  placeholder = input<string>('');
  optionLabel = input<string>('');
  control = input<FormControl>(new FormControl());
  valueChange = output();

  valueChangeItem(event: any) {
    this.valueChange.emit(event.value);
  }
}
