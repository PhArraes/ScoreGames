import { Injectable } from '@angular/core';

@Injectable()
export class MessageService {

  messages = [];

  add(message: string, details: string) {
    this.messages.push({ message: message, details: details });
  }

  clear() {
    this.messages = [];
  }

}
