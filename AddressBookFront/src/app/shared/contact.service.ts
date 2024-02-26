import { Injectable } from '@angular/core';

import { HttpClient } from "@angular/common/http";
import { environment } from '../../environments/environment.development';
import { Contact } from './contact.model';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  url:string=environment.apiBaseUrl
  list:Contact[]=[]
  formData:Contact=new Contact()
  formSubmitted: boolean = false;
  constructor(private http:HttpClient) { }
  contactsList(){
    this.http.get(this.url).subscribe({
      next:resp =>{
        this.list= resp as Contact[]
      },
      error:err=>{
        console.log(err)
      }
    })
  }
  AddContact() {
    return this.http.post(this.url, this.formData)
  }
  UpdateContact() {
    return this.http.put(this.url + '/' + this.formData.contactId, this.formData)
  }

  DeleteContact(id: number) {
    return this.http.delete(this.url + '/' + id)
  }
  resetForm(form: NgForm) {
    form.form.reset()
    this.formData = new Contact()
    this.formSubmitted = false
  }
}
