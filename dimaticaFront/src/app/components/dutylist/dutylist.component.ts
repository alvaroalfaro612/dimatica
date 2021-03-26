import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/app/services/http.service';
import { Duty } from './DutyModel';

@Component({
  selector: 'app-duty-list',
  templateUrl: './dutylist.component.html',
  styleUrls: ['./dutylist.component.css']
})
export class DutyListComponent implements OnInit {

  constructor(private httpService: HttpService) { }

  public listDuties: Duty[]=[{id:"aaa", name:"bbb", status:"ccc"},{id:"aaa", name:"bbb", status:"ccc"},{id:"aaa", name:"bbb", status:"ccc"}]
  public newDuty:any;

  ngOnInit(): void {
    this.UpdateList();
  }

  public Create(){
    var tmp:Duty={id:null,name:this.newDuty,status:"okey"}
    this.httpService.sendPostRequest(tmp).toPromise().then(res=>this.UpdateList())
  }
  public Delete(id:string){
    this.httpService.DeleteRequest(id).toPromise().then(res=>this.UpdateList())
  }
  public Edit(id:string, duty:Duty){
    this.httpService.PutRequest(id,duty).toPromise().then(res=>{this.UpdateList(); window.alert("Duty updated");})
  }
  public UpdateList(){
    this.httpService.sendGetRequest().subscribe((data: Duty[])=>{
      console.log(data);
      this.listDuties = data;
    }) 
  }
}
