import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})

export class SuperLigaService {

  public actionsList = { list: 'Listado de socios', topFive: 'Nombres comunes en River', infoTeams: 'Informacion equipos' }
  private action$ = new Subject<string>();
  private actionToCall;

  constructor() { 
  }

  public setNewAction(action:string){
    this.action$.next(action);
    this.setActionToCall(action)
    console.log("action", this.actionToCall)

  }

  public getAction(): Observable<string> {
    return this.action$.asObservable();
  }

  public setActionToCall(action){
    for (var key in this.actionsList) {
      if(this.actionsList[key]==action.toString()){
        this.actionToCall=key;
      }
    }
  }

  

}
