import { Component, OnInit, NgModule } from '@angular/core';
import { EmployeeService } from 'src/app/shared/employee.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})

export class EmployeeComponent implements OnInit {

  constructor(public service:EmployeeService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?: NgForm){
    if (form != null)
      form.resetForm();
    this.service.formData = {
      iD:0,
      firstName:'',
      lastName:'',
      emailID:'',
      activities:'',
      comments:''
    }
  }

  onSubmit(form:NgForm){
    this.insertRecord(form);
  }

 insertRecord(form:NgForm){
  this.service.postEmployee(form.value).subscribe(res =>{
  this.resetForm(form)
})
 }
}

