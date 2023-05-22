import { Component,OnInit,Input  } from '@angular/core';
import { EmployeeTypeService,EmployeeService } from 'src/app/services/employeeService';
import { EmployeeType } from 'src/app/models/employeeType.model';
import { Employee } from 'src/app/models/Employee.model';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
 
})
export class EmployeesComponent implements OnInit {

  searchText: string = '';
  @Input() viewMode = false;
  //new course object
    @Input() currentType: EmployeeType = {
    typeName:'',
    typeDescription:''
    };
    @Input() currentEmployee: Employee ={
      employeeName:'',
      cellNum:'',
      idNum:'',
      employeeTypeId:0,
      employeeUserId:1
    };
  
  ngOnInit(): void {
      this.loadAll();
      this.loadTypes();
  }
  showModal = false;
    showAddModal =false;
    showEditModal = false;
  constructor(private empTService:EmployeeTypeService,
    private empService:EmployeeService,
    private route: ActivatedRoute,
    private router:Router,
    private modalService: NgbModal) { }
  empTypes?:EmployeeType[];
  employeeType ?: EmployeeType={
    typeName:'',
    typeDescription:''
  }
  Employee:Employee ={
    employeeName:'',
    employeeTypeId:0,
    employeeUserId:1,
    idNum:'',
    cellNum:''
  }
  Employees?:Employee[];
  loadTypes(): void{
    this.empTService.getAll().subscribe((data:EmployeeType[])=>{  
      this.empTypes = data;
      console.log(data)
    });
  }
  loadAll(): void {
    this.empService.getAll()
      .subscribe(emps => {
        this.Employees = emps;
        console.log(emps)
      });
  }
  closeConfirmationDialog() {
    this.modalService.dismissAll();
  }
  deleteEmp(employeeId :any){
    this.showModal=false;
      this.empService.delete(employeeId)
     
      .subscribe({
        next:(response) => {
          this.router.navigate(['/employees'])
        }
      })
    
    }
    openModal() {
      this.showModal = true;
    }
  
    closeModal() {
      this.showModal = false;
    }

    openAddModal() {
      this.showAddModal = true;
    }
  
    closeAddModal() {
      this.showAddModal = false;
    }
    saveEmployee(): void { //save attributes 
      const data = {
       employeeName:this.Employee.employeeName,
       employeeTypeId:this.Employee.employeeTypeId,
        cellNum:this.Employee.cellNum,
        idNum:this.Employee.idNum,
        employeeUserId:this.Employee.employeeUserId
      };
  
      this.empService.create(data) //push data
        .subscribe({
          next: (res) => {
            console.log(res);
         this.loadAll();
         this.loadTypes();
          },
          error: (e) => console.error(e)
        });
    }
    getEmpType(Id: any): String {
      this.empTService.getEmp(Id)
        .subscribe({
          next: (data) => {
            this.currentType = data;
            console.log(data);
          },
          error: (e) => console.error(e)
        });
        return this.currentType.typeName!
    }
    getEmp(id:any):void {
      this.empService.getEmp(id).subscribe({
        next: (data) => {
          this.currentEmployee=data;
          console.log(data);
        },
        error: (e) => console.error(e)
      });
      
    }
    
    openEditModal(x:any) {
      this.showEditModal = true;
      if (!this.viewMode) {
  
        this.getEmp(x);
        //get course by id
      }
    }
    getEmployeeTypeName(employeeTypeId: number): String {
      const employeeType = this.empTypes?.find(type => type.employeeTypeId === employeeTypeId);
      return employeeType ? employeeType.typeName! :' ';
    }
  
    closeEditModal() {
      this.showEditModal = false;
    }
    updateEmployee(): void {
 
      //retrieve updated data from form and save changes
          this.empService.update(this.currentEmployee.employeeId, this.currentEmployee)
            .subscribe({
              next: (res) => {
                this.router.navigate(['/employees'])
                console.log(res);
               
              },
              error: (e) => console.error(e)
            });
        }

}
