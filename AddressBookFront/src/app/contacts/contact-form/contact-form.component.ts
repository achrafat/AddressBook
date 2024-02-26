import { Component } from '@angular/core';
import { ContactService } from '../../shared/contact.service';
import { NgForm } from "@angular/forms";
import { Contact } from '../../shared/contact.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-contact-form',
  /*standalone: true,
  imports: [],*/
  templateUrl: './contact-form.component.html',
  styleUrl: './contact-form.component.css'
})
export class ContactFormComponent  {
  constructor(public service:ContactService,private toastr: ToastrService){

  }
  onSubmit(form: NgForm) {
    this.service.formSubmitted = true
    if (form.valid) {
      if (this.service.formData.contactId == 0)
        this.insertRecord(form)
      else
        this.updateRecord(form)
    }
}
insertRecord(form: NgForm) {
  this.service.AddContact()
    .subscribe({
      next: res => {
        this.service.list = res as Contact[]
        this.service.resetForm(form)
        this.toastr.success('Added successfully', 'Add Contact')
      },
      error: err => { console.log(err) }
    })
}
updateRecord(form: NgForm) {
  this.service.UpdateContact()
    .subscribe({
      next: res => {
        this.service.list = res as Contact[]
        this.service.resetForm(form)
        this.toastr.info('Updated successfully', 'Update Contact')
      },
      error: err => { console.log(err) }
    })
 }
 
}

