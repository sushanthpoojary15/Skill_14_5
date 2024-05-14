import { Component, OnInit } from '@angular/core';
import { UserServiceService } from 'src/service/user-service.service';

@Component({
  selector: 'app-user-statistics',
  templateUrl: './user-statistics.component.html',
  styleUrls: ['./user-statistics.component.css']
})
export class UserStatisticsComponent implements OnInit {

  inactiveUsercount=0;
  activeUsercount=0;
  name = 'Angular';
 
  width: number = 500;
  height: number = 300;
  fitContainer: boolean = false;

    view: [700, 400];
  // options for the chart
  showXAxis = true;
  showYAxis = true;
  gradient = false;
  showLegend = true;
  showXAxisLabel = true;
  xAxisLabel = 'User Status';
  showYAxisLabel = true;
  yAxisLabel = 'User Count';
  timeline = true;
  doughnut = true;
  colorScheme = {
    domain: ['#9370DB', '#87CEFA', '#FA8072', '#FF7F50', '#90EE90', '#9370DB']
  };
 
 graphValues=[];
  constructor(private userService:UserServiceService) { }

  ngOnInit(): void {

this.userService.getAllUsers().subscribe(res=>{
 const data=res;
 this.activeUsercount = data.filter(user => user.isActive === true).length;

// Count of inactive users
   this.inactiveUsercount = data.filter(user => user.isActive === false).length;
   this.updateGraph();
})
  }

  updateGraph()
  {
     this.graphValues = [
      {
        "name": "Active",
        "value":this.activeUsercount
      },
      {
        "name": "Inactive",
        "value": this.inactiveUsercount
      }
    ]
  }

}
