import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

 public success(title: string, text: string = '') {
    Swal.fire({
      icon: 'success',
      title: title,
      text: text,
      toast: true,
      showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
              position: 'top-end',
    });
  }

  public error(title: string, text: string = '') {
    Swal.fire({
      icon: 'error',
      title: title,
      text: text,
      confirmButtonColor: '#d33',
       showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
              position: 'top-end',
    });
  }

 public  warning(title: string, text: string = '') {
    Swal.fire({
      icon: 'warning',
      title: title,
      text: text,
      confirmButtonColor: '#f39c12',
       showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
              position: 'top-end',
    });
  }

  public confirm(title: string, text: string = '') {
    return Swal.fire({
      icon: 'question',
      title: title,
      text: text,
      showCancelButton: true,
      confirmButtonText: 'Sí',
      cancelButtonText: 'Cancelar',
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33'
    });
  }


}
