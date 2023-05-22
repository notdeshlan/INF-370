import { Component,OnInit,Input  } from '@angular/core';
import { ItemService,ItemTypeService } from 'src/app/services/itemsService';
import { Item,ItemType } from 'src/app/models/items.model';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent implements OnInit {
  searchText: string = '';
  @Input() viewMode = false;
  //new course object
    @Input() currentType: ItemType = {
    typeName:'',
    typeDescription:''
    };
    @Input() currentItem: Item ={
      itemName:'',
      itemDescription:'',
      itemTypeId:0,
      qtyOnHand:0
    };
  
  ngOnInit(): void {
      this.loadAll();
      this.loadTypes();
  }
  showModal = false;
    showAddModal =false;
    showEditModal = false;
  constructor(private ItemTypeServ:ItemTypeService,
    private ItemServ:ItemService,
    private route: ActivatedRoute,
    private router:Router,
    private modalService: NgbModal) { }
  iTypes?:ItemType[];
  iType ?: ItemType={
    typeName:'',
    typeDescription:''
  }
  Item:Item ={
  itemName:'',
  itemDescription:'',
  itemTypeId:0,
  qtyOnHand:0
  }
  Items?:Item[];
  loadTypes(): void{
    this.ItemTypeServ.getAll().subscribe((data:ItemType[])=>{  
      this.iTypes = data;
      console.log(data)
    });
  }
  loadAll(): void {
    this.ItemServ.getAll()
      .subscribe(emps => {
        this.Items = emps;
        console.log(emps)
      });
  }
  closeConfirmationDialog() {
    this.modalService.dismissAll();
  }
  deleteEmp(employeeId :any){
    this.showModal=false;
      this.ItemServ.delete(employeeId)
     
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
       itemName:this.Item.itemName,
       itemDescription:this.Item.itemDescription,
        itemTypeId: this.Item.itemTypeId,
       qtyOnHand:this.Item.qtyOnHand
      };
  
      this.ItemServ.create(data) //push data
        .subscribe({
          next: (res) => {
            console.log(res);
         this.loadAll();
         this.loadTypes();
          },
          error: (e) => console.error(e)
        });
    }
    getItemType(Id: any): String {
      this.ItemTypeServ.getType(Id)
        .subscribe({
          next: (data) => {
            this.currentType = data;
            console.log(data);
          },
          error: (e) => console.error(e)
        });
        return this.currentType.typeName!
    }
    getItem(id:any):void {
      this.ItemServ.getItem(id).subscribe({
        next: (data) => {
          this.currentItem=data;
          console.log(data);
        },
        error: (e) => console.error(e)
      });
      
    }
    
    openEditModal(x:any) {
      this.showEditModal = true;
      if (!this.viewMode) {
  
        this.getItem(x);
        //get course by id
      }
    }
    getItemTypeName(employeeTypeId: number): String {
      const employeeType = this.iTypes?.find(type => type.itemTypeId === employeeTypeId);
      return employeeType ? employeeType.typeName! :' ';
    }
  
    closeEditModal() {
      this.showEditModal = false;
    }
    updateEmployee(): void {
 
      //retrieve updated data from form and save changes
          this.ItemServ.update(this.currentItem.itemId, this.currentItem)
            .subscribe({
              next: (res) => {
                this.router.navigate(['/employees'])
                console.log(res);
               
              },
              error: (e) => console.error(e)
            });
        }


}
