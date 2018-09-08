import { Component } from '@angular/core';

@Component({
  selector: 'ebm-navmain',
  templateUrl: './navmain.component.html',
  styleUrls: ['./navmain.component.scss']
})

export class NavMainComponent {
  title = 'ebm works!';
  collapseNavMenu = true;

  toggleNavMenu() {
      this.collapseNavMenu = !this.collapseNavMenu;
  }

}
