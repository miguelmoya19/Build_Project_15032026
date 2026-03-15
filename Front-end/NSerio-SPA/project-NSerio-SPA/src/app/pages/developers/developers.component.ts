import { Component, OnInit } from '@angular/core';
import { IDeveloper } from 'src/app/interfaces/IDeveloper';
import { MessageService } from 'src/app/services/message-service';
import { NserioApiService } from 'src/app/services/nserio-api.service';
import { responseModel } from 'src/app/Shared/responseModel';

@Component({
  selector: 'app-developers',
  templateUrl: './developers.component.html',
  styleUrls: ['./developers.component.css']
})
export class DevelopersComponent implements OnInit {

  public developers: Partial<IDeveloper>[]=[];
  public displayColumns: string[]=[];
  
  constructor(private readonly api: NserioApiService, private readonly swal: MessageService){}


  ngOnInit(): void {
   this.getdDevelopers();
  }

  private getdDevelopers(): void {
    this.api.getAppNSerio(`Dev/developers`).subscribe({
      next: (res: responseModel<any>) => {
       
        const dataCopy = res.data.map(s => {

           const first = s.Nombre;
           const lastname = s.lastName;
           const email = s.Email.valueEmail;

           delete s.Nombre;
           delete s.lastName;
           delete s.isActive;
           delete s.Email;

           return {
            ...s,
            Nombre: first + " " + lastname,
            Email: email
           }
        });

        this.developers = dataCopy;
        this.displayColumns = Object.keys(this.developers[0]);


        console.log(dataCopy);
        
      },
      error: (err) => {
         this.swal.error(
            'Error',
            'No se pudo obtener la información adecuadamente.',
          );
      },
    })
  }


}


