import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccommodationComponent } from './accommodation/accommodation.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DayVisitsComponent } from './day-visits/day-visits.component';
import { EventsComponent } from './events/events.component';
import { HelpComponent } from './help/help.component';
import { InspectionComponent } from './inspection/inspection.component';
import { InventoryManagementComponent } from './inventory-management/inventory-management.component';
import { ReportsComponent } from './reports/reports.component';
import { SettingsComponent } from './settings/settings.component';
import { SuppliersComponent } from './suppliers/suppliers.component';
import { EmployeesComponent } from './employees/employees.component';
import { VATComponent } from './vat/vat.component';
import { ViewEmployeeComponent } from './view-employee/view-employee.component';
import { EmployeeTypeComponent } from './employee-type/employee-type.component';
import { ItemComponent } from './item/item.component';
import { ItemTypeComponent } from './item-type/item-type.component';
import { ItemCategoryComponent } from './item-category/item-category.component';
const routes: Routes = [
  {path: 'dashboard', component: DashboardComponent},
  {path : 'dayvisits', component: DayVisitsComponent},
  {path : 'accommodation', component: AccommodationComponent},
  {path: 'events', component: EventsComponent},
  {path: 'inspections' , component: InspectionComponent},
  {path: 'inventory' , component: InventoryManagementComponent},
  {path: 'suppliers' , component: SuppliersComponent},
  {path: 'settings', component: SettingsComponent},
  {path: 'reports', component: ReportsComponent},
  {path: 'help', component: HelpComponent},
  {path: 'employees', component: EmployeesComponent},
  {path: 'vat',component: VATComponent},
  {path: 'viewemployee',component: ViewEmployeeComponent} ,
  {path: 'employeetype',component: EmployeeTypeComponent},
  {path: 'item',component: ItemComponent},  
  {path: 'itemtype',component: ItemTypeComponent},
  {path:"itemcategory", component:ItemCategoryComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
