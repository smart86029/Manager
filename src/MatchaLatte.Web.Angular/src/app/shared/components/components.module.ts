import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MaterialModule } from '../material/material.module';
import { ChatRoomComponent } from './chat-room/chat-room.component';
import { ComfirmDialogComponent } from './comfirm-dialog/comfirm-dialog.component';
import { InlineEditorComponent } from './inline-editor/inline-editor.component';
import { ThemePickerComponent } from './theme-picker/theme-picker.component';
import { CardLoadingComponent } from './card-loading/card-loading.component';

@NgModule({
  declarations: [
    ChatRoomComponent,
    ComfirmDialogComponent,
    InlineEditorComponent,
    ThemePickerComponent,
    CardLoadingComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
  ],
  exports: [
    ChatRoomComponent,
    ComfirmDialogComponent,
    InlineEditorComponent,
    ThemePickerComponent,
    CardLoadingComponent,
  ],
  entryComponents: [
    ComfirmDialogComponent,
  ]
})
export class ComponentsModule { }
