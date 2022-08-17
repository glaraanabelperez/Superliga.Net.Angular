import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})

export class SuperLigaService {

  public filterList = { 
                          records: 'Total de registros', 
                          ageaverage: 'Edad promedio', 
                          topfive: 'Nombres comunes en River',
                          list: 'Listado socios (100)', 
                          infoteams: 'Informacion equipos' 
                      }
                      
  private filter$ = new Subject<string>();
  private url="https://localhost:44380/api/Partners/";

  constructor(private http: HttpClient) { 
  }

  //Callas Web api

  public gatRecords(): Observable<number> {
    let url=this.url + "records";
    return this.http.get<number>(url);
  }
  public getAgeAverage(): Observable<number> {
    let url=this.url + "ageAverage";
    return this.http.get<number>(url);
  }
  public getList(): Observable<Array<any>> {
    let url=this.url + "list";
    return this.http.get<Array<any>>(url);
  }
  public getTopFive(): Observable<string> {
    let url=this.url + "topFive";
    return this.http.get<string>(url);
  }
  public getInfoTeams(): Observable<Array<any>> {
    let url=this.url + "infoTeams";
    return this.http.get<Array<any>>(url);
  }
  

 


  //Establece endpoints y renderizado segun el filtro seleccionado 
  public getFilter(): Observable<string> {
    return this.filter$.asObservable();
  }

  public setFilter(action:string){
    this.filter$.next(action);
    console.log(action)
  }

  
  
  

}
