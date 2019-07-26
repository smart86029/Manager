import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { InlineEditorComponent } from './inline-editor/inline-editor.component';
import { MaterialModule } from './material/material.module';
import { YesNoPipe } from './pipes/yes-no.pipe';
import { ActionNamePipe } from './save-mode/action-name.pipe';

@NgModule({
  declarations: [
    ActionNamePipe,
    InlineEditorComponent,
    YesNoPipe,
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
  ],
})
export class SharedModule { }
