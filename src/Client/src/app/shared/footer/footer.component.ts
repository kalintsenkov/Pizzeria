import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  searchForm: FormGroup;

  constructor(
    private router: Router,
    private formBuilder: FormBuilder
  ) { }

  get query() {
    return this.searchForm.get('query').value;
  }

  ngOnInit(): void {
    this.searchForm = this.formBuilder.group({
      query: [''],
    });
  }

  search(): void {
    this.router.navigate([`/menu/search/${this.query}/page/1`]);
  }

  closeSearchForm(): void {
    const searchFrom = document.getElementsByClassName('search-form-wrapper')[0];
    searchFrom.classList.remove('open');
  }
}
