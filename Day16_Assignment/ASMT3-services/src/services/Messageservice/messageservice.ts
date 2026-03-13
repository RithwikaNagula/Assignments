import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Messageservice {
  private data: string[] = [];   // important

  getData() {
    return this.data;
  }

  addData(msg: string) {
    this.data.push(msg);
  }
}
