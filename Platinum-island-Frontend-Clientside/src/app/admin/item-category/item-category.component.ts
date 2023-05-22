import { Component,OnInit,Input  } from '@angular/core';
import { ItemCategoryService } from 'src/app/services/itemsService';
import { ItemCategory } from 'src/app/models/items.model';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-item-category',
  templateUrl: './item-category.component.html',
  styleUrls: ['./item-category.component.scss']
})
export class ItemCategoryComponent implements OnInit {
  searchText: string = '';
  @Input() viewMode = false;
  //new course object
    @Input() currentCat: ItemCategory = {
    categoryName:'',
    categoryDescription:''
    };
  ngOnInit(): void {
      this.loadAll();
  }
  deleteError=false;
  delModal=false;
  showModal = false;
    showAddModal =false;
    showEditModal = false;
  constructor(private catService:ItemCategoryService,
    private route: ActivatedRoute,
    private router:Router,
    private modalService: NgbModal) { }
  itemCats?:ItemCategory[];
  ItemCat?: ItemCategory={
    categoryName:'',
    categoryDescription:''
  }
  loadAll(): void {
    this.catService.getAll()
      .subscribe(cats => {
        this.itemCats = cats;
        console.log(cats)
      });
  }
  closeConfirmationDialog() {
    this.modalService.dismissAll();
  }
  deleteEmployeeType(x:any): void {
    console.log(x);
    
    this.catService.checkAssociatedRecords(x)
   
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
      this.catService.delete(employeeTypeId)
     
      .subscribe({
        next:(response) => {
          this.router.navigate(['/itemcategory'])
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
      this.getCat(x);
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
        categoryName:this.ItemCat?.categoryName,
       categoryDescription:this.ItemCat?.categoryDescription
      };
  
      this.catService.create(data) //push data
        .subscribe({
          next: (res) => {
            console.log(res);
         this.loadAll();
          },
          error: (e) => console.error(e)
        });
    }
    getCat(Id: string): void {
      this.catService.getCat(Id)
        .subscribe({
          next: (data) => {
            this.currentCat = data;
            console.log(data);
          },
          error: (e) => console.error(e)
        });
    }
    openEditModal(x:any) {
      this.showEditModal = true;
      if (!this.viewMode) {
  
        this.getCat(x);
        console.log(x);
        //get course by id
      }
    }
  
    closeEditModal() {
      this.showEditModal = false;
    }
    updateType(): void {
 
      //retrieve updated data from form and save changes
          this.catService.update(this.currentCat.itemCategoryId, this.currentCat)
            .subscribe({
              next: (res) => {
                this.router.navigate(['/itemcategory'])
                console.log(res);
               
              },
              error: (e) => console.error(e)
            });
        }

}
