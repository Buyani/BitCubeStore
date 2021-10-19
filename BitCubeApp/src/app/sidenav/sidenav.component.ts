import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  dahCliked()
  {
    console.log("He clicked me Guys")
  }
  productCliked(){
    console.log("Products clicked")
  }

  producttypeCliked()
  {
    console.log("Products Types clicked")
  }
}
