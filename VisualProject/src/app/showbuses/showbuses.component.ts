import { Component, OnInit } from '@angular/core';
import {Bus} from '../models/bus';
import {BusService} from '../services/busService';
@Component({
  selector: 'app-showbuses',
  templateUrl: './showbuses.component.html',
  styleUrls: ['./showbuses.component.css']
})
export class ShowbusesComponent implements OnInit {

  buses;
  bus:Bus;
  fromlocation;
  tolocation;
  type$;
  date;
 // private cookieValue:number;
  constructor(private busService:BusService) { 
    
    this.bus=new Bus();
  }
  model:any={};
    emp:any;
    emp1:any;
  
  ngOnInit(): void {
    this.type$=this.droplist();
   // this.cookieService.set('TripId',);
    //this.fetchBuses(this.fromlocation,this.tolocation,this.date);
  }
  populate(TripID){
    this.tolocation=this.busService.tolocationfrom(TripID);
    //this.fetchBuses(this.fromlocation,this.tolocation,this.date);
  }
  droplist(){
    return this.busService.getBuses();
  }
  fetchBuses(){
    this.busService.getBuses().subscribe((data)=>{
      this.emp=data;
    //  this.busService.trip=
      console.log(this.emp);
    })
  }
   searchdata(){
     this.busService.searchTable(this.model).subscribe((res)=>{
      this.emp=res;
     console.log(res);
     
     })
  }
  store(tripid:number,fromLocation:string,toLocation:string,
    fromTime:string,toTime:string,date:string)
  {
      this.busService.trip=tripid;
      this.busService.fromLocation=fromLocation;
      this.busService.toLocation=toLocation;
      this.busService.fromTime=fromTime;
      this.busService.toTime=toTime;
      this.busService.fromDate=date;
      console.log(tripid,this.busService.trip,this.busService.fromLocation,this.busService.toLocation,
        this.busService.fromTime,this.busService.toTime,this.busService.fromDate);
  }

}
