import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { InlineEditorComponent } from './inline-editor/inline-editor.component';
import { MaterialModule } from './material.module';
import { YesNoPipe } from './pipes/yes-no.pipe';
import { ActionNamePipe } from './save-mode/action-name.pipe';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,

  ],
  exports: [
    CommonModule,
    FormsModule,
    MaterialModule,

    ActionNamePipe,
    InlineEditorComponent,
    YesNoPipe,
  ],
  declarations: [
    ActionNamePipe,
    InlineEditorComponent,
    YesNoPipe,
  ]
})
export class SharedModule { }
