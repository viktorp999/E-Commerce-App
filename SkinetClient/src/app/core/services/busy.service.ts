import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root',
})
export class BusyService {
  count = 0;

  constructor(private spinnerService: NgxSpinnerService) {}

  busy() {
    this.count++;
    this.spinnerService.show(undefined, {
      type: 'timer',
      bdColor: 'rgba(255,255,255,0.7)',
      color: '#333333',
    });
  }

  idle() {
    this.count--;

    if (this.count <= 0) {
      this.count = 0;
      this.spinnerService.hide();
    }
  }
}