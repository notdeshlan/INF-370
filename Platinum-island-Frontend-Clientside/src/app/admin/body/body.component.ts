import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-body',
  templateUrl: './body.component.html',
  styleUrls: ['./body.component.scss']
})
export class BodyComponent {
  @Input() collapsed = false;
  @Input() screenWidth = 0;

  getBody(): string {
    let styleClass = 'body';
    if (this.collapsed && this.screenWidth > 700) {
      styleClass += ' body-trimmed';
    } else if (this.collapsed && this.screenWidth <= 700 && this.screenWidth > 0) {
      styleClass += ' body-md-screen';
    }
    return styleClass;
  }
}
