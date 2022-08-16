import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})

export class SuperLigaService {

  public filterList = { list: 'Listado de socios', topFive: 'Nombres comunes en River', infoTeams: 'Informacion equipos' }
  private filter$ = new Subject<string>();
  private endpoint;
  private url="http://localhost:4380/api/";

  constructor(private http: HttpClient) { 
  }

  //Callas Web api
  // public getList(): Observable<Array<any>> {
  //   let url=this.url + this.endpoint;
  //   return this.http.get<Array<any>>(url);
  // }


  //Establece endpoints y renderizado segun el filtro seleccionado 
  public getFilter(): Observable<string> {
    return this.filter$.asObservable();
  }

  public setFilter(action:string){
    this.filter$.next(action);
    this.setEndpoint(action)
  }

  public setEndpoint(action:string){
    for (var key in this.filterList) {
      if(this.filterList[key]==action.toString()){
        this.endpoint=key.toString();
      }
    }
  }
  //Renderization url
  public showData(value :string): boolean{
    return this.endpoint==value;
  }
  
  

}
