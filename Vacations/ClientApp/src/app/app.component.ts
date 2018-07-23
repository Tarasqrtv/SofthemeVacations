import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  constructor(private toastr: ToastrService) {}

  showSuccess(message: string) {
    this.toastr.success('Hello world!', message);
  }

  showError(message: string) {
    this.toastr.error('Error message', message);
  }
  
  showInfo(message: string) {
    this.toastr.info('Info message', message);
  }
  
  showWarning(message: string) {
    this.toastr.warning('Warnig message', message);
  }
}
