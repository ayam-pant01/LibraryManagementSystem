import { inject, Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class ToastService {
  matSnackBar = inject(MatSnackBar);
  openSnackBar(message: string, action: string = 'Close', duration: number = 3000): void {
    this.matSnackBar.open(message, action, {
      duration: duration,
      verticalPosition: 'top',
      horizontalPosition: 'center'
    });
  }
}