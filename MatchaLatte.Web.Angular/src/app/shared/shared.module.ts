import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MaterialModule } from './material.module';
import { InlineEditorComponent } from './inline-editor/inline-editor.component';
import { ActionNamePipe } from './save-mode/action-name.pipe';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    FlexLayoutModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    FlexLayoutModule,
    ActionNamePipe,
    InlineEditorComponent
  ],
  declarations: [
    ActionNamePipe,
    InlineEditorComponent
  ]
})
export class SharedModule { }
