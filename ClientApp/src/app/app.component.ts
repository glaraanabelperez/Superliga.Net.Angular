import { Component } from '@angular/core';
import { Action } from 'rxjs/internal/scheduler/Action';
import { SuperLigaService } from './servicios/super-liga.service';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})


export class AppComponent {

  public title = 'ClientApp';
  public filter:string;
  public filterList:Array<string>=[];

  constructor(public serviceSuperLiga:SuperLigaService){
    this.setFiltersList();
  }

  ngOnInit() {}

  setFiltersList(){
    var a = Object.values(this.serviceSuperLiga.filterList);
    for (var i=0; i<a.length; i++) {
      this.filterList.push(a[i]);
    }
  }

  search(){
    this.serviceSuperLiga.setFilter(this.filter);
  }

  
  

}
