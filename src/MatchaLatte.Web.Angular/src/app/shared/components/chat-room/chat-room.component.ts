import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { TemplatePortal } from '@angular/cdk/portal';
import { Component, OnInit, TemplateRef, ViewChild, ViewContainerRef, OnDestroy } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { NavigationStart, Router } from '@angular/router';
import { Member } from 'src/app/core/notification/member';
import { NotificationService } from 'src/app/core/notification/notification.service';
import { Room } from 'src/app/core/notification/room';
import { tap } from 'rxjs/operators';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-chat-room',
  templateUrl: './chat-room.component.html',
  styleUrls: ['./chat-room.component.scss']
})
export class ChatRoomComponent implements OnInit, OnDestroy {
  members: Member[] = [];
  messages: string[] = ['a', 'b', 'c', 'd'];
  message: string;
  rooms: Room[] = [];
  overlayRef: OverlayRef;

  @ViewChild('chatButton', { static: true })
  chatButton: MatButton;

  @ViewChild('chatRoom', { static: true })
  chatRoom: TemplateRef<any>;

  private subscription = new Subscription();

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
    this.overlayRef = this.overlay.create({ positionStrategy: strategy });
    this.subscription.add(this.notificationService.members$
      .pipe(
        tap(members => this.members.push(...members))
      )
      .subscribe());
    this.subscription.add(this.notificationService.message$
      .pipe(
        tap(message => this.messages.push(message))
      )
      .subscribe());
    this.subscription.add(this.router.events
      .pipe(
        tap(event => {
          if (event instanceof NavigationStart) {
            this.overlayRef.detach();
          }
        }))
      .subscribe());
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  openChatRoom(): void {
    if (!!this.overlayRef && this.overlayRef.hasAttached()) {
      this.overlayRef.detach();
    } else {
      this.overlayRef.attach(new TemplatePortal(this.chatRoom, this.viewContainerRef));
    }
  }

  createRoom(member: Member): void {
    // this.notificationService.createRoom(member.);
  }

  send(): void {
    this.notificationService.send(this.message);
    this.message = '';
  }
}
