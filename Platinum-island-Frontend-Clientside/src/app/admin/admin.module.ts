import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { RouterModule } from '@angular/router';
import { AccommodationComponent } from './accommodation/accommodation.component';
import { BodyComponent } from './body/body.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DayVisitsComponent } from './day-visits/day-visits.component';
import { EmployeesComponent } from './employees/employees.component';
import { EventsComponent } from './events/events.component';
import { HelpComponent } from './help/help.component';
import { InspectionComponent } from './inspection/inspection.component';
import { InventoryManagementComponent } from './inventory-management/inventory-management.component';
import { ReportsComponent } from './reports/reports.component';
import { SettingsComponent } from './settings/settings.component';
import { SideNavComponent } from './side-nav/side-nav.component';
import { SuppliersComponent } from './suppliers/suppliers.component';


@NgModule({
  declarations: [
    AccommodationComponent,
    BodyComponent,
    DashboardComponent,
    DayVisitsComponent,
    EmployeesComponent,
    EventsComponent,
    HelpComponent,
    InspectionComponent,
    InventoryManagementComponent,
    ReportsComponent,
    SettingsComponent,
    SideNavComponent,
    SuppliersComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
  ],
  exports: [SideNavComponent,BodyComponent],
})
export class AdminModule { }
