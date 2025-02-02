import { Component, input } from '@angular/core';
import { TabsModule } from 'primeng/tabs';
import { Tab } from '../../models/tabs.models';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-tabs',
  standalone: true,
  imports: [TabsModule, CommonModule],
  templateUrl: './tabs.component.html',
})
export class TabsComponent {
  tabs = input<Tab[]>([]);
}
