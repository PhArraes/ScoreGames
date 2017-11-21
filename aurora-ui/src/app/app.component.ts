import { Component, OnInit } from '@angular/core';
import { ScoresService } from './scores.service';

import { DiceComponent } from './components/dice/dice.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [ScoresService]
})
export class AppComponent implements OnInit {
  title = 'app';
  dices = [];
  scores = [];
  loading = false;
  constructor(private scoresService: ScoresService) {

  }

  ngOnInit() {
  }

  sort() {
    this.dices = [0, 0, 0, 0, 0]
      .map(() => Math.floor(Math.random() * 6) + 1);
  }

  onSubmit() {
    this.loading = true;
    this.scoresService.getByMove(this.dices)
      .subscribe(sc => {
        this.scores = sc;
        this.loading = false;
      }, () => this.loading = false);
  }
}
