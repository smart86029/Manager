import { Injectable } from '@angular/core';
import { HttpTransportType, HubConnection, HubConnectionBuilder, LogLevel, HubConnectionState, HttpClient } from '@aspnet/signalr';
import { Subject } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';
import { Member } from './member';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  members$ = new Subject<Member[]>();
  message$ = new Subject<string>();
  private notificationUrl = 'notification/hub';
  private hubConnection: HubConnection;

  constructor(private authService: AuthService) {
    this.init();
  }

  getMembers(): void {
    this.hubConnection.send('getMembers');
  }

  send(message: string): void {
    this.hubConnection.send('sendMessage', '', message);
  }

  stop(): void {
    this.hubConnection.stop();
  }

  private init(): void {
    // if (this.authService.isAuthorized()) {
    this.register();
    this.establishConnection();
    this.registerHandlers();
    // }
  }

  private register(): void {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.notificationUrl, {
        // transport: HttpTransportType.WebSockets,
        // skipNegotiation: true,
        accessTokenFactory: () => this.authService.getAccessToken()
      })
      .configureLogging(LogLevel.Information)
      .build();
  }

  private establishConnection(): void {
    this.hubConnection
      .start()
      .then(() => {
        console.log('Hub connection started');
        this.getMembers();
      })
      .catch(() => console.log('Error while establishing connection'));
  }

  private registerHandlers(): void {
    this.hubConnection.on('receiveMembers', members => {
      this.members$.next(members);
    });
    this.hubConnection.on('receiveMessage', (user, message) => {
      // this.toastr.success('Updated to status: ' + msg.status, 'Order Id: ' + msg.orderId);
      this.message$.next(message);
    });
  }
}
