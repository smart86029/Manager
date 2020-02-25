import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-comfirm-dialog',
  templateUrl: './comfirm-dialog.component.html',
  styleUrls: ['./comfirm-dialog.component.scss']
})
export class ComfirmDialogComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public message: string) { }
}
