import { Component, input, output } from '@angular/core';
import { ButtonModule } from 'primeng/button';
@Component({
  selector: 'app-button',
  standalone: true,
  imports: [ButtonModule],
  templateUrl: './button.component.html',
})
export class ButtonComponent {
  labelText = input<string>('');
  actionEvent = output();

  actionItem() {
    this.actionEvent.emit();
  }
}
