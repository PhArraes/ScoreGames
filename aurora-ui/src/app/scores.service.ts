import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';

import { MessageService } from './message.service';
import { Score } from './model/score';
import { environment } from '../environments/environment';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' })
};

@Injectable()
export class ScoresService {

  private heroesUrl = environment.apiUrl + '/score';  // URL to web api

  constructor(private http: HttpClient,
    private messageService: MessageService) { }

  getByMove(move: number[]): Observable<Score[]> {
    let params = new HttpParams().set('move', JSON.stringify({ move: move }));
    return this.http.post<Score[]>(this.heroesUrl, move)
      .pipe(
        tap(heroes => console.log(`fetched scores`)),
        catchError(this.handleError('Get Scores', [])));
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      this.log(`${operation} failed: ${error.message}`);

      return of(result as T);
    };
  }
  private log(message: string) {
    this.messageService.add('Ocorreu um erro no acesso ao servidor, por favor tente mais tarde.', message);
  }
}
