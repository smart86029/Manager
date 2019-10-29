import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { TemplatePortal } from '@angular/cdk/portal';
import { Component, OnInit, TemplateRef, ViewChild, ViewContainerRef } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { NavigationStart, Router } from '@angular/router';
import { Member } from 'src/app/core/notification/member';
import { NotificationService } from 'src/app/core/notification/notification.service';
import { Room } from 'src/app/core/notification/room';

@Component({
  selector: 'app-chat-room',
  templateUrl: './chat-room.component.html',
  styleUrls: ['./chat-room.component.scss']
})
export class ChatRoomComponent implements OnInit {
  members: Member[] = [];
  messages: string[] = ['a', 'b', 'c', 'd'];
  message: string;
  rooms: Room[] = [];
  overlayRef: OverlayRef;

  @ViewChild('chatButton', { static: true })
  chatButton: MatButton;

  @ViewChild('chatRoom', { static: true })
  chatRoom: TemplateRef<any>;

  constructor(
    private notificationService: NotificationService,
    private overlay: Overlay,
    private viewContainerRef: ViewContainerRef,
    private router: Router,
  ) { }

  ngOnInit(): void {
    const strategy = this.overlay
      .position()
      .flexibleConnectedTo(this.chatButton._elementRef)
      .withPositions([{ originX: 'start', originY: 'top', overlayX: 'end', overlayY: 'bottom' }]);
    this.overlayRef = this.overlay.create({
      positionStrategy: strategy
    });
    this.notificationService.members$.subscribe({
      next: members => this.members.push(...members)
    });
    this.notificationService.message$.subscribe({
      next: message => this.messages.push(message)
    });
    this.router.events.subscribe({
      next: event => {
        if (event instanceof NavigationStart) {
          this.overlayRef.detach();
        }
      }
    });
  }

  openChatRoom(): void {
    if (!!this.overlayRef && this.overlayRef.hasAttached()) {
      this.overlayRef.detach();
    } else {
      this.overlayRef.attach(new TemplatePortal(this.chatRoom, this.viewContainerRef));
    }
  }

  createRoom(member: Member): void {
    //this.notificationService.createRoom(member.);
  }

  send(): void {
    this.notificationService.send(this.message);
    this.message = '';
  }
}
