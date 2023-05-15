import { Component } from '@angular/core';
import { SideNavToggle } from './admin/side-nav/side-nav.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Platinum-island-Frontend-Clientside';
  isSideNavCollapsed = false;
  screenWidth = 0;
 
  onToggleSideNav(data : SideNavToggle) : void{
    this.screenWidth = data.screenWidth;
    this.isSideNavCollapsed = data.collapsed;
}
}