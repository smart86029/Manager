import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MaterialModule } from '../material/material.module';
import { ChatRoomComponent } from './chat-room/chat-room.component';
import { ComfirmDialogComponent } from './comfirm-dialog/comfirm-dialog.component';
import { InlineEditorComponent } from './inline-editor/inline-editor.component';
import { ThemePickerComponent } from './theme-picker/theme-picker.component';

@NgModule({
  declarations: [
    ChatRoomComponent,
    ComfirmDialogComponent,
    InlineEditorComponent,
    ThemePickerComponent,
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
  ],
  entryComponents: [
    ComfirmDialogComponent,
  ]
})
export class ComponentsModule { }
