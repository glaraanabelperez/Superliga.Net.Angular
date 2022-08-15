import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-super-liga',
  templateUrl: './super-liga.component.html',
  styleUrls: ['./super-liga.component.scss']
})
export class SuperLigaComponent implements OnInit {

  @Input()actionSelect: string;
  
  constructor() { }

  ngOnInit(): void {
  }

}
