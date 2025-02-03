import { Component, input } from '@angular/core';
import { InputTextModule } from 'primeng/inputtext';
import { FloatLabelModule } from 'primeng/floatlabel';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-input',
  standalone: true,
  imports: [InputTextModule, FloatLabelModule, ReactiveFormsModule],
  templateUrl: './input.component.html',
})
export class InputComponent {
  control = input<FormControl>(new FormControl(''));
  labelText = input<string>('');
  type = input<string>('text');
}
