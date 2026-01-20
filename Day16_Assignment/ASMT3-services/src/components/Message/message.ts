import { Component,inject} from '@angular/core';
import { Messageservice } from '../../services/Messageservice/messageservice';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-message',
  imports: [CommonModule,FormsModule],
  templateUrl: './message.html',
  styleUrl: './message.css',
})
export class Message {
private msgService = inject(Messageservice);

  messages: string[] = [];
  newMsg = '';

  ngOnInit() {
    this.messages = this.msgService.getData();
  }

  addMessage() {
    this.msgService.addData(this.newMsg);
    this.newMsg = '';
  }
}
