import { CdkOverlayOrigin, Overlay, OverlayRef } from '@angular/cdk/overlay';
import { TemplatePortal } from '@angular/cdk/portal';
import { Component, EventEmitter, Input, OnInit, Output, TemplateRef, ViewChild, ViewContainerRef } from '@angular/core';
import { SaveMode } from 'src/app/core/save-mode.enum';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-inline-editor',
  templateUrl: './inline-editor.component.html',
  styleUrls: ['./inline-editor.component.scss']
})
export class InlineEditorComponent implements OnInit {
  saveMode = SaveMode.Create;
  overlayRef: OverlayRef;
  newValue: string;

  @Input()
  value: string;

  @Input()
  name: string;

  @Output()
  valueChange: EventEmitter<string> = new EventEmitter<string>();

  @ViewChild(CdkOverlayOrigin, { static: true })
  overlayOrigin: CdkOverlayOrigin;

  @ViewChild('overlayArea', { static: true })
  overlayArea: TemplateRef<any>;

  constructor(private overlay: Overlay, private viewContainerRef: ViewContainerRef) { }

  ngOnInit(): void {
    this.newValue = this.value;
    const strategy = this.overlay
      .position()
      .flexibleConnectedTo(this.overlayOrigin.elementRef)
      .withPositions([{ originX: 'start', originY: 'top', overlayX: 'start', overlayY: 'top' }]);
    this.overlayRef = this.overlay.create({
      positionStrategy: strategy,
      hasBackdrop: true,
      backdropClass: 'cdk-overlay-transparent-backdrop'
    });
    this.overlayRef
      .backdropClick()
      .pipe(
        tap(() => this.back())
      )
      .subscribe();
    if (!this.newValue) {
      this.display();
    } else {
      this.saveMode = SaveMode.Update;
    }
  }

  display(): void {
    if (this.overlayRef && this.overlayRef.hasAttached()) {
      this.overlayRef.detach();
    } else {
      this.overlayRef.attach(new TemplatePortal(this.overlayArea, this.viewContainerRef));
    }
  }

  save(): void {
    this.valueChange.emit(this.newValue);
    this.display();
  }

  back(): void {
    this.newValue = this.value;
    this.display();
  }
}
