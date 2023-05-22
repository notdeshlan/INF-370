import { Component,OnInit,Input  } from '@angular/core';
import { EmployeeTypeService } from 'src/app/services/employeeService';
import { EmployeeType } from 'src/app/models/employeeType.model';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormControl, Validators } from '@angular/forms';
@Component({
  selector: 'app-employee-type',
  templateUrl: './employee-type.component.html',
  styleUrls: ['./employee-type.component.scss']
})
export class EmployeeTypeComponent implements OnInit {

  searchText: string = '';
  @Input() viewMode = false;
  //new course object
    @Input() currentType: EmployeeType = {
    typeName:'',
    typeDescription:''
    };
  ngOnInit(): void {
      this.loadAll();
  }
  deleteError=false;
  delModal=false;
  showModal = false;
    showAddModal =false;
    showEditModal = false;
  constructor(private empService:EmployeeTypeService,
    private route: ActivatedRoute,
    private router:Router,
    private modalService: NgbModal) { }
  empTypes?:EmployeeType[];
  employeeType ?: EmployeeType={
    typeName:'',
    typeDescription:''
  }
  loadAll(): void {
    this.empService.getAll()
      .subscribe(empTypes => {
        this.empTypes = empTypes;
        console.log(empTypes)
      });
  }
  closeConfirmationDialog() {
    this.modalService.dismissAll();
  }
  deleteEmployeeType(x:any): void {
    console.log(x);
    
    this.empService.checkAssociatedRecords(x)
   
      .subscribe(response => {
        if (response.hasAssociatedRecords) {
          // Show a notification or prompt the user that deletion is not allowed
          console.log('Deletion not allowed. Employee type has associated records.');
          this.deleteError=true;
          this.openDelModal();
        } else {
          // Proceed with the deletion
          console.log('Deleting employee type...');
          this.deleteType(x);
          
          this.deleteError=false;
          // Call the API endpoint to delete the employee type
        }
      });
      this.closeModal();
  }
  deleteType(employeeTypeId :any){
    this.showModal=false;
    console.log(employeeTypeId);
      this.empService.delete(employeeTypeId)
     
      .subscribe({
        next:(response) => {
          this.router.navigate(['/employeetype'])
        }
      })
    
    }
    openDelModal(){
      this.delModal=true;
    }
    closeDelModal(){
      this.delModal=false;
    }
    openModal(x:any) {
      this.showModal = true;
      this.getEmp(x);
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
    saveType(): void { //save attributes 
      const data = {
        typeName:this.employeeType?.typeName,
       typeDescription:this.employeeType?.typeDescription
      };
  
      this.empService.create(data) //push data
        .subscribe({
          next: (res) => {
            console.log(res);
         this.loadAll();
          },
          error: (e) => console.error(e)
        });
    }
    getEmp(Id: string): void {
      this.empService.getEmp(Id)
        .subscribe({
          next: (data) => {
            this.currentType = data;
            console.log(data);
          },
          error: (e) => console.error(e)
        });
    }
    openEditModal(x:any) {
      this.showEditModal = true;
      if (!this.viewMode) {
  
        this.getEmp(x);
        console.log(x);
        //get course by id
      }
    }
  
    closeEditModal() {
      this.showEditModal = false;
    }
    updateType(): void {
 
      //retrieve updated data from form and save changes
          this.empService.update(this.currentType.employeeTypeId, this.currentType)
            .subscribe({
              next: (res) => {
                this.router.navigate(['/employeetype'])
                console.log(res);
               
              },
              error: (e) => console.error(e)
            });
        }
}
