import { Component,OnInit ,Input} from '@angular/core';
import { SuppService } from 'src/app/services/SupplierService';
import { Supplier } from 'src/app/models/supplier.model';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormControl, Validators } from '@angular/forms';
import { numberValidator } from './number.validator';
import { emailValidator } from './email.validator';
import { FilterPipe } from './filter.pipe';

@Component({
  selector: 'app-view-suppliers',
  templateUrl: './view-suppliers.component.html',
  styleUrls: ['./view-suppliers.component.scss'],
  providers:[FilterPipe]
})
export class ViewSuppliersComponent implements OnInit {
  searchText: string = '';
  emailFormControl = new FormControl('', [Validators.required, emailValidator()]);
  numberFormControl = new FormControl('', [Validators.required, numberValidator()]);
  @Input() viewMode = false;
  //new course object
    @Input() currentSupp: Supplier = {
     supplierName:'',
     supplierEmail:'',
     supplierPhone:''
    };
  suppRecords?:Supplier[];
  ngOnInit(): void {
      this.loadAll();
  }
  supplier : Supplier ={
    supplierName:'',
    supplierEmail:'',
    supplierPhone:''
  }
  constructor(private supService: SuppService,
    private route: ActivatedRoute,
    private router:Router,
    private modalService: NgbModal) { }
    showModal = false;
    showAddModal =false;
    showEditModal = false;
    loadAll(): void {
      this.supService.getAll()
        .subscribe(suppRecords => {
          this.suppRecords = suppRecords;
          console.log(suppRecords)
        });
    }
   
  
    closeConfirmationDialog() {
      this.modalService.dismissAll();
    }
    deleteSupplier(supplierId :any){
      this.showModal=false;
        this.supService.delete(supplierId)
       
        .subscribe({
          next:(response) => {
            this.router.navigate(['/viewsuppliers'])
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
      saveSupplier(): void { //save attributes 
        const data = {
          supplierName:this.supplier.supplierName,
          supplierEmail:this.supplier.supplierEmail,
          supplierPhone:this.supplier.supplierPhone
        };
    
        this.supService.create(data) //push data
          .subscribe({
            next: (res) => {
              console.log(res);
           this.loadAll();
            },
            error: (e) => console.error(e)
          });
      }
      getSupp(supplierId: string): void {
        this.supService.getSupp(supplierId)
          .subscribe({
            next: (data) => {
              this.currentSupp = data;
              console.log(data);
            },
            error: (e) => console.error(e)
          });
      }
      openEditModal(x:any) {
        this.showEditModal = true;
        if (!this.viewMode) {
    
          this.getSupp(x);
          //get course by id
        }
      }
    
      closeEditModal() {
        this.showEditModal = false;
      }
      updateSupplier(): void {
   
        //retrieve updated data from form and save changes
            this.supService.update(this.currentSupp.supplierId, this.currentSupp)
              .subscribe({
                next: (res) => {
                  this.router.navigate(['/viewsuppliers'])
                  console.log(res);
                 
                },
                error: (e) => console.error(e)
              });
          }
}
