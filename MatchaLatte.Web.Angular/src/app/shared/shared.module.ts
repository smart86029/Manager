import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { InlineEditorComponent } from './inline-editor/inline-editor.component';
import { MaterialModule } from './material/material.module';
import { YesNoPipe } from './pipes/yes-no.pipe';
import { ActionNamePipe } from './save-mode/action-name.pipe';
import { ThemePickerComponent } from './components/theme-picker/theme-picker.component';
import { EnumPipe } from './pipes/enum.pipe';
import { ArrayPipe } from './pipes/array.pipe';
import { DictionaryPipe } from './pipes/dictionary.pipe';

@NgModule({
  declarations: [
    ActionNamePipe,
    InlineEditorComponent,
    YesNoPipe,
    ThemePickerComponent,
    DictionaryPipe,
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
  ],
})
export class SharedModule { }
