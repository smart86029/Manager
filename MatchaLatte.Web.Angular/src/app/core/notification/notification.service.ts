import { Injectable } from '@angular/core';
import { HttpTransportType, HubConnection, HubConnectionBuilder, LogLevel } from '@aspnet/signalr';
import { Subject } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private notificationUrl = 'notification/hub';
  private hubConnection: HubConnection;
  private notification$ = new Subject();

  constructor(private authService: AuthService) {
    this.init();
  }

  public stop(): void {
    this.hubConnection.stop();
  }

  private init(): void {
    if (this.authService.isAuthorized()) {
      this.register();
      this.stablishConnection();
      this.registerHandlers();
    }
  }

  private register(): void {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(`${this.notificationUrl}/hub`, {
        transport: HttpTransportType.LongPolling,
        accessTokenFactory: () => this.authService.getAccessToken()
      })
      .configureLogging(LogLevel.Information)
      .build();
  }

  private stablishConnection(): void {
    this.hubConnection
      .start()
      .then(() => {
        console.log('Hub connection started');
      })
      .catch(() => {
        console.log('Error while establishing connection');
      });
  }

  private registerHandlers(): void {
    this.hubConnection.on('ReceiveMessage', (user, message) => {
      console.log(message);
      // this.toastr.success('Updated to status: ' + msg.status, 'Order Id: ' + msg.orderId);
      this.notification$.next();
    });
  }
}
