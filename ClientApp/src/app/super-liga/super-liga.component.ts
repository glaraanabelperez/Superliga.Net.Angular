import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
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
        console.log(res)  
      },
      error=>{
        console.log(error)  
      }
    );
  }
  getAgeAverage() {
    this.serviceSuperLiga.getAgeAverage().subscribe(
      res=>{
        console.log(res)  
      },
      error=>{
        console.log(error)  
      }
    );
  }
  getList() {
      this.serviceSuperLiga.getList().subscribe(
        res=>{
          console.log(res)  
        },
        error=>{
          console.log(error)  
        }
      );
  }
  getTopFive() {
    this.serviceSuperLiga.getTopFive().subscribe(
      res=>{
        console.log(res)  
      },
      error=>{
        console.log(error)  
      }
    );
  }
  getInfoTeams() {
    this.serviceSuperLiga.getInfoTeams().subscribe(
      res=>{
        console.log(res)  
      },
      error=>{
        console.log(error)  
      }
    );
  }


}
