import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ActionNamePipe } from './action-name/action-name.pipe';
import { DictionaryPipe } from './dictionary/dictionary.pipe';
import { YesNoPipe } from './yes-no/yes-no.pipe';

@NgModule({
  declarations: [
    ActionNamePipe,
    DictionaryPipe,
    YesNoPipe,
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ActionNamePipe,
    DictionaryPipe,
    YesNoPipe,
  ]
})
export class PipesModule { }
