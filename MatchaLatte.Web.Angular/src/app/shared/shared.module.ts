import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { ThemePickerComponent } from './components/theme-picker/theme-picker.component';
import { InlineEditorComponent } from './inline-editor/inline-editor.component';
import { MaterialModule } from './material/material.module';
import { DictionaryPipe } from './pipes/dictionary.pipe';
import { YesNoPipe } from './pipes/yes-no.pipe';
import { ActionNamePipe } from './save-mode/action-name.pipe';
import { ChatRoomComponent } from './components/chat-room/chat-room.component';

@NgModule({
  declarations: [
    ActionNamePipe,
    InlineEditorComponent,
    YesNoPipe,
    ThemePickerComponent,
    DictionaryPipe,
    ChatRoomComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    MaterialModule,
    ActionNamePipe,
    InlineEditorComponent,
    YesNoPipe,
    ThemePickerComponent,
    DictionaryPipe,
    ChatRoomComponent,
  ],
})
export class SharedModule { }
