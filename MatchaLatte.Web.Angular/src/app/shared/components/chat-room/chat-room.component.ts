import { Component, OnInit, ViewContainerRef, ViewChild, TemplateRef } from '@angular/core';
import { NotificationService } from 'src/app/core/notification/notification.service';
import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { MatButton } from '@angular/material/button';
import { TemplatePortal } from '@angular/cdk/portal';

@Component({
  selector: 'app-chat-room',
  templateUrl: './chat-room.component.html',
  styleUrls: ['./chat-room.component.scss']
})
export class ChatRoomComponent implements OnInit {
  message: string;
  overlayRef: OverlayRef;

  @ViewChild('chatButton', { static: true })
  chatButton: MatButton;

  @ViewChild('chatRoom', { static: true })
  chatRoom: TemplateRef<any>;

  constructor(
    private notificationService: NotificationService,
    private overlay: Overlay,
    private viewContainerRef: ViewContainerRef,
  ) { }

  ngOnInit(): void {
    const strategy = this.overlay
      .position()
      .flexibleConnectedTo(this.chatButton._elementRef)
      .withPositions([{ originX: 'start', originY: 'top', overlayX: 'end', overlayY: 'bottom' }]);
    this.overlayRef = this.overlay.create({
      positionStrategy: strategy
    });
  }

  send(): void {

  }

  openChatRoom(): void {
    if (this.overlayRef && this.overlayRef.hasAttached()) {
      this.overlayRef.detach();
    } else {
      this.overlayRef.attach(new TemplatePortal(this.chatRoom, this.viewContainerRef));
    }
  }
}
