import { Component } from '@angular/core';
declare var $: any;

@Component({
  moduleId: module.id,
  selector: 'my-app',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.css']
})
export class AppComponent {
  title = 'Manager';

  ngAfterViewInit(): void {
    $(".button-collapse").sideNav();
    $('.collapsible').collapsible();
  }
}