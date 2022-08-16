import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { SuperLigaService } from '../servicios/super-liga.service';

@Component({
  selector: 'app-super-liga',
  templateUrl: './super-liga.component.html',
  styleUrls: ['./super-liga.component.scss']
})
export class SuperLigaComponent implements OnInit {

  public action$: Observable<string>;
  public action=null;

  constructor( public serviceSuperLiga:SuperLigaService) { 
  
  }

  ngOnInit(): void {
    this.action$ = this.serviceSuperLiga.getFilter();
    this.action$.subscribe(action => this.action = action);
  }

}
