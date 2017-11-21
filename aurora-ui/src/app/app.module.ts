import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { FlexLayoutModule } from "@angular/flex-layout";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatToolbarModule, MatCardModule, MatButtonModule,
  MatIconModule, MatInputModule, MatFormFieldModule,
  MatListModule, MatExpansionModule, MatProgressBarModule
} from '@angular/material';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { DiceComponent } from './components/dice/dice.component';
import { MessagesComponent } from './components/messages/messages.component';

import {MessageService} from './message.service';
import { AuroraDicesComponent } from './components/aurora-dices/aurora-dices.component';
import { ScoreListComponent } from './components/score-list/score-list.component';

@NgModule({
  declarations: [
    AppComponent,
    DiceComponent,
    MessagesComponent,
    AuroraDicesComponent,
    ScoreListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FlexLayoutModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule, MatInputModule, MatFormFieldModule,
    MatListModule,
    FormsModule,MatExpansionModule,
    MatProgressBarModule
  ],
  providers: [MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
