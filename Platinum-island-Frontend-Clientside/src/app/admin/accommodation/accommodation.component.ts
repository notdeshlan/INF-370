import { Component,OnInit,Input  } from '@angular/core';
import { RoomTypeService } from 'src/app/services/roomService';
import { RoomType } from 'src/app/models/roomType.model';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-accommodation',
  templateUrl: './accommodation.component.html',
  styleUrls: ['./accommodation.component.scss']
})
export class AccommodationComponent implements OnInit{
  searchText: string = '';
  @Input() viewMode = false;
  //new course object
    @Input() currentType: RoomType = {
    typeName:'',
    typeDescription:'',
    roomCapacity:0
    };
  ngOnInit(): void {
      this.loadAll();
  }
  deleteError=false;
  delModal=false;
  showModal = false;
    showAddModal =false;
    showEditModal = false;
  constructor(private roomService:RoomTypeService,
    private route: ActivatedRoute,
    private router:Router,
    private modalService: NgbModal) { }
  roomTypes?:RoomType[];
  roomType ?:RoomType={
    typeName:'',
    typeDescription:''
  }
  loadAll(): void {
    this.roomService.getAll()
      .subscribe(rTypes => {
        this.roomTypes = rTypes;
        console.log(rTypes)
      });
  }
  closeConfirmationDialog() {
    this.modalService.dismissAll();
  }
 
  deleteType(typeID :any){
    this.showModal=false;
    console.log(typeID);
      this.roomService.delete(typeID)
     
      .subscribe({
        next:(response) => {
          this.router.navigate(['/accommodation'])
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
        typeName:this.roomType?.typeName,
       typeDescription:this.roomType?.typeDescription,
       roomCapacity:this.roomType?.roomCapacity
      };
  
      this.roomService.create(data) //push data
        .subscribe({
          next: (res) => {
            console.log(res);
         this.loadAll();
          },
          error: (e) => console.error(e)
        });
    }
    getType(Id: string): void {
      this.roomService.getType(Id)
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
  
        this.getType(x);
        console.log(x);
        //get course by id
      }
    }
  
    closeEditModal() {
      this.showEditModal = false;
    }
    updateType(): void {
 
      //retrieve updated data from form and save changes
          this.roomService.update(this.currentType.roomTypeId, this.currentType)
            .subscribe({
              next: (res) => {
                this.router.navigate(['/employeetype'])
                console.log(res);
               
              },
              error: (e) => console.error(e)
            });
        }

}
