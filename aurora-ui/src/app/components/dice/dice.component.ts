import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-dice',
  templateUrl: './dice.component.html',
  styleUrls: ['./dice.component.css']
})
export class DiceComponent implements OnInit {
  @Input() Number: number;
  @Input() Title: string;
  @Input() Size: number;

  private _dice: string;
  private _size: string;

  private _diceClass: string;
  private _sizeSufix: string;

  constructor() {
    this._diceClass = 'dice dice-';
    this._sizeSufix = 'em';
  }

  ngOnInit() {
    if (this.Number > 0 && this.Number < 7)
      this._dice = this._diceClass + this.Number;
    if (this.Size > 0)
      this._size = this.Size + this._sizeSufix;
  }

}
