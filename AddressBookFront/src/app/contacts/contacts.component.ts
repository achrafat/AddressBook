import { Component,OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ContactService } from '../shared/contact.service';
import { Contact } from '../shared/contact.model';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrl: './contacts.component.css'
})
export class ContactsComponent implements OnInit {
  constructor(public service:ContactService, private toastr: ToastrService){

  }
  ngOnInit(): void {
    this.service.contactsList();
  }
  populateForm(selectedRecord: Contact) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this Contact?'))
      this.service.DeleteContact(id)
        .subscribe({
          next: res => {
            this.service.list = res as Contact[]
            this.toastr.error('Deleted successfully', 'AddressBook')
          },
          error: err => { console.log(err) }
        })
  }
}
