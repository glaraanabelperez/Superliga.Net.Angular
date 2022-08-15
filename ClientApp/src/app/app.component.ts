import { Component } from '@angular/core';
import { Action } from 'rxjs/internal/scheduler/Action';
import { SuperLigaService } from './servicios/super-liga.service';

// selector: 'app-myview',
// template: `<div *ngFor="let key of objectKeys(items)">{{key + ' : ' + items[key]}}</div>`
// })

// export class MyComponent {
// objectKeys = Object.keys;
// ;


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})


export class AppComponent {

  public title = 'ClientApp';
  public action:string;
  public actionList:Array<string>=[];

  constructor(public serviceSuperLiga:SuperLigaService){
    this.setAction();
  }

  ngOnInit() {}

  setAction(){
    var a = Object.values(this.serviceSuperLiga.actionsList);
    for (var i=0; i<a.length; i++) {
      this.actionList.push(a[i]);
    }
  }

  search(){
    console.log(this.action)
    this.serviceSuperLiga.setNewAction(this.action);
  }

  
  

}
