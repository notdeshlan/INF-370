import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl } from '@angular/forms';
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
import { VATComponent } from './vat/vat.component';
import { WaveComponent } from './wave/wave.component';
import { ViewEmployeeComponent } from './view-employee/view-employee.component';
import { EmployeeTypeComponent } from './employee-type/employee-type.component';
import { ItemComponent } from './item/item.component';
import { ItemTypeComponent } from './item-type/item-type.component';
import { ItemCategoryComponent } from './item-category/item-category.component';
import { ViewSuppliersComponent } from './view-suppliers/view-suppliers.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { FilterPipe } from './view-suppliers/filter.pipe';

import { FilterPipe2 } from './employee-type/filter.pipe';
import { FilterPipe3 } from './employees/filter.pipe';



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
    SuppliersComponent,
    VATComponent,
    WaveComponent,
    ViewEmployeeComponent,
    EmployeeTypeComponent,
    ItemComponent,
    ItemTypeComponent,
    ItemCategoryComponent,
    ViewSuppliersComponent,
    FilterPipe,
    FilterPipe2,
    FilterPipe3,


  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [SideNavComponent,BodyComponent],
})
export class AdminModule { }
