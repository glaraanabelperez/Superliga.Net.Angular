import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { SuperLigaService } from '../servicios/super-liga.service';

@Component({
  selector: 'app-super-liga',
  templateUrl: './super-liga.component.html',
  styleUrls: ['./super-liga.component.scss']
})
export class SuperLigaComponent implements OnInit {

  // @Input()actionSelect: string;
  public action$: Observable<string>;
  public action=null;
  public service:SuperLigaService;

  constructor( serviceSuperLiga:SuperLigaService) { 
    this.service=serviceSuperLiga;
  
  }

  ngOnInit(): void {
    this.action$ = this.service.getAction();
    this.action$.subscribe(action => this.action = action);
  }

}
