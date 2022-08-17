import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PartnersResponse, TeamsInfoResponse } from '../models/ISuperLiga';
import { SuperLigaService } from '../servicios/super-liga.service';

@Component({
  selector: 'app-super-liga',
  templateUrl: './super-liga.component.html',
  styleUrls: ['./super-liga.component.scss']
})
export class SuperLigaComponent implements OnInit {

  public filtro$: Observable<string>;
  public filtro=null;
  public sidebarShow: boolean = false;
  public partners:PartnersResponse[]=[];
  public infoTeams:TeamsInfoResponse[]=[];
  ageAverage: number;
  records: number;
  topFive;
  constructor( public serviceSuperLiga:SuperLigaService) { 
  
  }

  ngOnInit(): void {
    this.filtro$ = this.serviceSuperLiga.getFilter();
    this.filtro$.subscribe(filtro => {
      this.filtro = filtro;
      this.callApi(filtro);
      this.sidebarShow=true
    });
  }

  callApi(filtro: string) {
    
    switch(filtro) { 
      case "records": { 
         this.getRecords();
         break; 
      } 
      case "ageaverage": { 
        this.getAgeAverage(); 
         break; 
      } 
      case "list": { 
        this.getList(); 
        break; 
      } 
      case "topfive": { 
        this.getTopFive();
      break; 
      } 
      case "infoteams": { 
        this.getInfoTeams();
      break; 
      } 
      default: { 
         return; 
         break; 
      } 
   } 
  }

  getRecords() {
    this.serviceSuperLiga.gatRecords().subscribe(
      res=>{
        this.records=res;  
      },
      error=>{
        alert("Error de comunicacion")
      }
    );
  }
  getAgeAverage() {
    this.serviceSuperLiga.getAgeAverage().subscribe(
      res=>{
        this.ageAverage=res; 
      },
      error=>{
        alert("Error de comunicacion")
      }
    );
  }
  getList() {
      this.serviceSuperLiga.getList().subscribe(
        res=>{
          this.partners=res.slice();
        },
        error=>{
          alert("Error de comunicacion")
        }
      );
  }
  getTopFive() {
    this.serviceSuperLiga.getTopFive().subscribe(
      res=>{
        this.topFive=res.slice()
      },
      error=>{
        alert("Error de comunicacion")
      }
    );
  }
  getInfoTeams() {
    this.serviceSuperLiga.getInfoTeams().subscribe(
      res=>{
        this.infoTeams=res.slice();
      },
      error=>{
        alert("Error de comunicacion")
      }
    );
  }


}
