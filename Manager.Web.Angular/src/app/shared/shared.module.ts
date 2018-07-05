import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MaterialModule } from './material.module';
import { ActionNamePipe } from './save-mode/action-name.pipe';
import { YesNoPipe } from './yes-no.pipe';
import { InlineEditorComponent } from './inline-editor/inline-editor.component';

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
    YesNoPipe,
    InlineEditorComponent
  ],
  declarations: [
    ActionNamePipe,
    YesNoPipe,
    InlineEditorComponent
  ]
})
export class SharedModule { }
