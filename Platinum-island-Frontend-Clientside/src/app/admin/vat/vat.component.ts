import { Component,OnInit ,Input} from '@angular/core';
import { VatService } from 'src/app/services/VATService'; 
import { VAT } from 'src/app/models/vat.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-vat',
  templateUrl: './vat.component.html',
  styleUrls: ['./vat.component.scss']
})
export class VATComponent implements OnInit{

  @Input() viewMode = false;
  //new course object
    @Input() currentVat: VAT = {
     vatAmount:0,
     vatDate: new Date(Date.now())
    };
  vatRecords?: VAT[];
  vat :VAT ={
    vatAmount:0,
    vatDate:new Date(Date.now())
  }
  
  constructor(private vatService: VatService,
    private route: ActivatedRoute,
    private router:Router) { }
   showModal = false;
   showEditModal = false;
   myInput?: number;

validateInput(event: any) {
  const pattern = /^[0-9]+(\.[0-9]{0,2})?$/;
  const input = event.target.value;

  if (!pattern.test(input)) {
    event.target.value = input.slice(0, -1);
  }
}
validateEdit(event: any) {
  const pattern = /^[0-9]+(\.[0-9]{0,2})?$/;
  const input = event.target.value;

  if (!pattern.test(input)) {
    event.target.value = input.slice(0, -1);
  }
}

  ngOnInit(): void {
      this.loadVatRecords();
     
  }
  getVat(vatId: string): void {
    this.vatService.getVAT(vatId)
      .subscribe({
        next: (data) => {
          this.currentVat = data;
          console.log(data);
        },
        error: (e) => console.error(e)
      });
  }
  updateVAT(): void {
   
//retrieve updated data from form and save changes
    this.vatService.update(this.currentVat.vatId, this.currentVat)
      .subscribe({
        next: (res) => {
          this.router.navigate(['/vat'])
          console.log(res);
         
        },
        error: (e) => console.error(e)
      });
  }
  saveVAT(): void { //save attributes 
    const data = {
      vatAmount: this.vat.vatAmount,
     vatDate: this.vat.vatDate
    };

    this.vatService.create(data) //push data
      .subscribe({
        next: (res) => {
          console.log(res);
       this.loadVatRecords();
        },
        error: (e) => console.error(e)
      });
  }
  loadVatRecords(): void {
    this.vatService.getVatRecords()
      .subscribe(vatRecords => {
        this.vatRecords = vatRecords;
        console.log(vatRecords)
      });
  }
  openModal() {
    this.showModal = true;
  }

  closeModal() {
    this.showModal = false;
  }

  submitForm() {
 
    this.closeModal();

  }

  cancelForm(){
   
    this.showModal= false;
  }

  openEditModal(x:any) {
    this.showEditModal = true;
    if (!this.viewMode) {

      this.getVat(x);
      //get course by id
    }
  }

  closeEditModal() {
    this.showEditModal = false;
  }
  
  cancelEditForm() {
 
    this.showEditModal = false;
   
  }
}
