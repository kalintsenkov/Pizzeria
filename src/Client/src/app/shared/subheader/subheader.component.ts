import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-subheader',
  templateUrl: './subheader.component.html',
  styleUrls: ['./subheader.component.css']
})
export class SubheaderComponent {

  @Input() heading: string;
  @Input() breadcrumbs: string[];

}
