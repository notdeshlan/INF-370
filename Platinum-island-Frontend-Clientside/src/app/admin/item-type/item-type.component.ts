import { Component,OnInit,Input  } from '@angular/core';
import { ItemCategory,ItemType } from 'src/app/models/items.model';
import { ItemCategoryService,ItemTypeService } from 'src/app/services/itemsService';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-item-type',
  templateUrl: './item-type.component.html',
  styleUrls: ['./item-type.component.scss']
})
export class ItemTypeComponent implements OnInit {
  searchText: string = '';
  @Input() viewMode = false;
  //new course object
    @Input() currentCategory: ItemCategory = {
    categoryName:'',
    categoryDescription:''
    };
    @Input() currentType: ItemType ={
      typeName:'',
      typeDescription:'' ,
      itemCategoryId:0
    };
  
  ngOnInit(): void {
      this.loadAll();
      this.loadCats();
  }
  deleteError=false;
  delModal=false;
  showModal = false;
    showAddModal =false;
    showEditModal = false;
  constructor(private catService:ItemCategoryService,
    private iType:ItemTypeService,
    private route: ActivatedRoute,
    private router:Router,
    private modalService: NgbModal) { }
  itemCats?:ItemCategory[];
  itemCat ?: ItemCategory={
    categoryName:'',
    categoryDescription:''  
  }
  itemType: ItemType ={
    typeName:'',
    typeDescription:''
  }
  itemTypes?:ItemType[];
  loadCats(): void{
    this.catService.getAll().subscribe((data:ItemCategory[])=>{  
      this.itemCats = data;
      console.log(data)
    });
  }
  loadAll(): void {
    this.iType.getAll()
      .subscribe(emps => {
        this.itemTypes = emps;
        console.log(emps)
      });
  }
  closeConfirmationDialog() {
    this.modalService.dismissAll();
  }
  deleteEmployeeType(x:any): void {
    console.log(x);
    
    this.iType.checkAssociatedRecords(x)
   
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
  openDelModal(){
    this.delModal=true;
  }
  closeDelModal(){
    this.delModal=false;
  }
  deleteType(Id :any){
    this.showModal=false;
      this.iType.delete(Id)
     
      .subscribe({
        next:(response) => {
          this.router.navigate(['/employees'])
        }
      })
    
    }
    openModal(x:any) {
      this.showModal = true;
      this.getType(x);
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
       typeName:this.itemType.typeName,
       ItemCategoryId:this.itemType.itemCategoryId,
       typeDescription:this.itemType.typeDescription
      };
  
      this.iType.create(data) //push data
        .subscribe({
          next: (res) => {
            console.log(res);
         this.loadAll();
         this.loadCats();
          },
          error: (e) => console.error(e)
        });
    }
    getItemCat(Id: any): String {
      this.catService.getCat(Id)
        .subscribe({
          next: (data) => {
            this.currentType = data;
            console.log(data);
          },
          error: (e) => console.error(e)
        });
        return this.currentCategory.categoryName!
    }
    getType(id:any):void {
      this.iType.getType(id).subscribe({
        next: (data) => {
          this.currentType=data;
          console.log(data);
        },
        error: (e) => console.error(e)
      });
      
    }
    
    openEditModal(x:any) {
      this.showEditModal = true;
      if (!this.viewMode) {
  
        this.getType(x);
        //get course by id
      }
    }
    getItemCatName(Id: number): String {
      const itemCategory = this.itemCats?.find(type => type.itemCategoryId === Id);
      return itemCategory ? itemCategory.categoryName! :' ';
    }
  
    closeEditModal() {
      this.showEditModal = false;
    }
    updateType(): void {
 
      //retrieve updated data from form and save changes
          this.iType.update(this.currentType.itemTypeId, this.currentType)
            .subscribe({
              next: (res) => {
                this.router.navigate(['/employees'])
                console.log(res);
               
              },
              error: (e) => console.error(e)
            });
        }

}
