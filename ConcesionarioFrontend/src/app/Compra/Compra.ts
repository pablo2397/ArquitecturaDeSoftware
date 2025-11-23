import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-compra',
  standalone: true,
  imports: [],
  template: `<p>Compra works!</p>`,
  styleUrl: './Compra.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Compra { }
