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

  constructor( public serviceSuperLiga:SuperLigaService) { 
  
  }

  ngOnInit(): void {
    this.filtro$ = this.serviceSuperLiga.getFilter();
    this.filtro$.subscribe(action => this.filtro = action);
  }

  //llamada segun filtro

}
