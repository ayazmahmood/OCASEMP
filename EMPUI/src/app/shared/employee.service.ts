import { Injectable } from '@angular/core';
import { Employee } from './employee.model';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  formData : Employee;
  list : Employee[];
  readonly rootURL = "https://localhost:44362/Employees"
  //readonly rootURL = "https://localhost:44362"
  constructor(private http: HttpClient) { }

  postEmployee(formData:Employee){
    return this.http.post(this.rootURL,formData)
  }
refreshList(){
 this.http.get(this.rootURL)
 .toPromise().then(res=>this.list = res as Employee[] )
}

}
