import { Injectable } from '@angular/core';
import { HttpTransportType, HubConnection, HubConnectionBuilder, LogLevel, HubConnectionState } from '@aspnet/signalr';
import { Subject } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  message$ = new Subject<string>();
  private notificationUrl = 'notification/hub';
  private hubConnection: HubConnection;

  constructor(private authService: AuthService) {
    this.init();
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
        // accessTokenFactory: () => this.authService.getAccessToken()
      })
      .configureLogging(LogLevel.Information)
      .build();
  }

  private establishConnection(): void {
    this.hubConnection
      .start()
      .then(() => console.log('Hub connection started'))
      .catch(() => console.log('Error while establishing connection'));
  }

  private registerHandlers(): void {
    this.hubConnection.on('receiveMessage', (user, message) => {
      // this.toastr.success('Updated to status: ' + msg.status, 'Order Id: ' + msg.orderId);
      this.message$.next(message);
    });
  }
}
