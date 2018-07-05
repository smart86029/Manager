import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { TemplatePortal } from '@angular/cdk/portal';
import {
  Component,
  ElementRef,
  EventEmitter,
  Input,
  OnInit,
  Output,
  TemplateRef,
  ViewChild,
  ViewContainerRef,
} from '@angular/core';
import { MatInput } from '@angular/material';

@Component({
  selector: 'app-inline-editor',
  templateUrl: './inline-editor.component.html',
  styleUrls: ['./inline-editor.component.scss']
})
export class InlineEditorComponent implements OnInit {
  overlayRef: OverlayRef;
  newValue: string;

  @Input()
  value: string;

  @Input()
  name: string;

  @ViewChild('overlayArea')
  overlayArea: TemplateRef<any>;

  @ViewChild('originText')
  originText: ElementRef;

  @ViewChild('editor')
  editor: MatInput;

  @Output()
  valueChange: EventEmitter<string> = new EventEmitter<string>();

  constructor(private overlay: Overlay, private viewContainerRef: ViewContainerRef) { }

  ngOnInit() {
    this.newValue = this.value;
    const strategy = this.overlay
      .position()
      .connectedTo(this.originText, { originX: 'start', originY: 'top' }, { overlayX: 'start', overlayY: 'top' });
    this.overlayRef = this.overlay.create({
      hasBackdrop: true,
      backdropClass: 'cdk-overlay-transparent-backdrop',
      positionStrategy: strategy
    });
    this.overlayRef.backdropClick().subscribe(() => {
      this.back();
    });
    if (!this.newValue) {
      this.display();
    }
  }

  display() {
    if (this.overlayRef && this.overlayRef.hasAttached()) {
      this.overlayRef.detach();
    } else {

      this.overlayRef.attach(new TemplatePortal(this.overlayArea, this.viewContainerRef));
      
    }
  }

  save() {
    this.valueChange.emit(this.newValue);
    this.display();
  }

  back() {
    this.newValue = this.value;
    this.display();
  }
}
