import { Component, Input } from '@angular/core';

import { IErrors } from '../../core/interfaces/IErrors';

@Component({
  selector: 'app-error-list',
  templateUrl: './error-list.component.html',
  styleUrls: ['./error-list.component.css']
})
export class ErrorListComponent {

  formattedErrors: Array<string> = [];

  @Input()
  set errors(errorList: IErrors) {
    this.formattedErrors = errorList.errors
      ? Object.keys(errorList.errors || {}).map(key => `${errorList.errors[key]}`)
      : Object.keys(errorList || {}).map(key => `${errorList[key]}`);
  }

  get errorList() {
    return this.formattedErrors;
  }
}
