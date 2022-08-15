import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {

  public title = 'ClientApp';
  public actionsList:Array<string>=["countRegister", "lis100", "tpFive"];
  public action:string;

  constructor(){
  }

  ngOnInit() {}

  search(){
    console.log("aca", this.action)
  }

}
